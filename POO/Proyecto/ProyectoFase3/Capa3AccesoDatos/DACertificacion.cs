using System;
using System.Data;
using CapaEntidades;
using System.Data.SqlClient; //nugget instalado
using System.Linq;
using System.Collections.Generic;

namespace Capa3AccesoDatos {
    public class DACertificacion {

        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //constructor
        public DACertificacion(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //propiedades
        public string Mensaje {
            get => _mensaje;
        }


        //Metodos Funcionales

        //----INSERTAR-------
        public string Insertar(EntidadCertificacion certificacion) {
            string id = "";
            int retorno;

            //Establecer el objeto conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto command para crear los comandos
            SqlCommand comando = new SqlCommand();

            //Se coloca el tipo de commandText es
            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "INSERTARCERTIFICADO";//Asignamos el nombre del SP(Procedimiento almacenado)
            //Sele indica que el tipo de comando a ejecutar es PROCEDIMIENTO ALMACENEADO

            //asignar la conexion al command
            comando.Connection = conexion;

            //Luego agregamos los datos de la entidad para enviarlos
            comando.Parameters.AddWithValue("@idCertificado", certificacion.Id_certificado);
            comando.Parameters.AddWithValue("@idProfesor", certificacion.Id_profesor);
            comando.Parameters.AddWithValue("@materia", certificacion.Materia);

            //absorbemos el mensaje que soltara el SP de la BD
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            try {
                conexion.Open();//se abre la conexion
                comando.ExecuteNonQuery();

                //Los dos datos que devuelve lo guardamos en variables para usarlaas luego
                retorno = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@msj"].Value.ToString();


                if (retorno == 1) {
                    id = Convert.ToString(comando.ExecuteScalar());
                }

                //devolvemos el valor para saber que sucedio y que se puede hacer despues
                //vg_Retorno = retorno;
                conexion.Close();//se cierra la conexion

            } catch (Exception) {
                throw;
            } finally {
                conexion.Dispose();
                comando.Dispose();
            }

            return id;

        }//-------


        //-----Llamado de datos(Mostrar)-------

        //Devuelve un DATASET con datos de clientes, SOLO para ser mostrados con el DataGridView
        public DataSet ListarMatricula(string condicion = "", string orden = "") {
            DataSet datos = new DataSet();  //en "datos" se va a guardar los resultados del select
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;

            string sentencia = "Select * from Certificaciones";

            //Si el parametro de condicion no esta vacio, lo concatena a la sentencia
            if (!string.IsNullOrEmpty(condicion)) {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }
            //Para orden
            if (!string.IsNullOrEmpty(orden)) {
                sentencia = string.Format("{0} order by {1}", sentencia, orden);
            }

            //Se ejecuta
            try {
                adapter = new SqlDataAdapter(sentencia, conexion);
                //el adapter .fill llena "adapter" con los datos del dataset "datos" y le asigna el nombre "Idiomas"
                adapter.Fill(datos, "Certificaciones");
            } catch (Exception) {
                throw;
            }

            return datos;//Devuelve el DataSet

        }//------------

        //------Obtener un dato mediante un ID-------

        public EntidadCertificacion ObtenerCertificacion(string id) {
            EntidadCertificacion certificacion = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//el data reader no tiene constructor se llena mediante un excecute
                                     //si el id es texto se debe de escribir entre comillas '{0}' en el string
            string sentencia = string.Format("Select ID_Certificado,ID_Profesor,Materia" +
            " from Certificaciones where ID_Certificado = '{0}'", id);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows) {
                    certificacion = new EntidadCertificacion();
                    dataReader.Read();//Empieza a leer la informacion
                    certificacion.Id_certificado = dataReader.GetString(0);
                    certificacion.Id_profesor = dataReader.GetInt32(1);
                    certificacion.Materia = dataReader.GetString(2);
                    certificacion.Existe = true;
                }
                conexion.Close();

            } catch (Exception) {
                throw;
            }
            return certificacion;
        }//---------------------------


        //--Eliminar 
        public int EliminarCertificado(EntidadCertificacion certificacion) {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "delete Certificaciones ";
            sentencia = string.Format("{0} where ID_Certificado = '{1}'", sentencia, certificacion.Id_certificado);
            comando.CommandText = sentencia;
            comando.Connection = conexion;

            try {
                conexion.Open();
                afectado = comando.ExecuteNonQuery();
                conexion.Close();
            } catch (Exception) {
                throw;
            } finally {
                conexion.Dispose();
                comando.Dispose();
            }
            return afectado;

        }//-----------------------------------------------



        //---Modificar

        public int Modificar(EntidadCertificacion certificacion) {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "update Certificaciones set ID_Certificado=@idCertificado,ID_Profesor=@idProfesor, Materia=@materia " +
            "where ID_Certificado=@idCertificado";
            //----
            comando.Parameters.AddWithValue("@idCertificado", certificacion.Id_certificado);
            comando.Parameters.AddWithValue("@idProfesor", certificacion.Id_profesor);
            comando.Parameters.AddWithValue("@materia", certificacion.Materia);

            comando.CommandText = sentencia;
            comando.Connection = conexion;

            try {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            } catch (Exception) {
                throw;
            } finally {
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;
        }//----------------------------------
    }
}
