using System;
using System.Data;
using CapaEntidades;
using System.Data.SqlClient; //nugget instalado
using System.Linq;
using System.Collections.Generic;

namespace Capa3AccesoDatos {
    public class DAEstudiante {

        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //constructor
        public DAEstudiante(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //propiedades
        public string Mensaje {
            get => _mensaje;
        }


        //Metodos Funcionales

        //----INSERTAR-------
        public int Insertar(EntidadEstudiante estudiante) {
            int id = 0;
            int retorno;

            //Establecer el objeto conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto command para crear los comandos
            SqlCommand comando = new SqlCommand();

            //Se coloca el tipo de commandText es
            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "INSERTARESTUDIANTE";//Asignamos el nombre del SP(Procedimiento almacenado)
            //Sele indica que el tipo de comando a ejecutar es PROCEDIMIENTO ALMACENEADO

            //asignar la conexion al command
            comando.Connection = conexion;

            //Luego agregamos los datos de la entidad para enviarlos
            //comando.Parameters.AddWithValue("@idEstudiante", estudiante.Id_estudiante);
            comando.Parameters.AddWithValue("@nombre", estudiante.Nombre);
            comando.Parameters.AddWithValue("@apellido1", estudiante.Apellido1);
            comando.Parameters.AddWithValue("@apellido2", estudiante.Apellido2);
            comando.Parameters.AddWithValue("@correo", estudiante.Correo);
            comando.Parameters.AddWithValue("@telefono", estudiante.Telefono);

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
                    id = Convert.ToInt32(comando.ExecuteScalar());
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

            return retorno;

        }//-------


        //-----Llamado de datos(Mostrar)-------

        //Devuelve un DATASET con datos de clientes, SOLO para ser mostrados con el DataGridView
        public DataSet ListarEstudiante(string condicion = "", string orden = "") {
            DataSet datos = new DataSet();  //en "datos" se va a guardar los resultados del select
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;

            string sentencia = "Select * from Estudiantes";

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
                adapter.Fill(datos, "Estudiantes");
            } catch (Exception) {
                throw;
            }

            return datos;//Devuelve el DataSet

        }//------------

        //------Obtener un dato mediante un ID-------

        public EntidadEstudiante ObtenerEstudiante(int id) {
            EntidadEstudiante estudiante = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//el data reader no tiene constructor se llena mediante un excecute
                                     //si el id es texto se debe de escribir entre comillas '{0}' en el string
            string sentencia = string.Format("Select ID_Estudiantes,Nombre,Apellido1,Apellido2,Correo,Telefono " +
            "from Estudiantes where ID_Estudiantes = {0}", id);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows) {
                    estudiante = new EntidadEstudiante();
                    dataReader.Read();//Empieza a leer la informacion
                    estudiante.Identificacion = dataReader.GetInt32(0);
                    estudiante.Nombre = dataReader.GetString(1);
                    estudiante.Apellido1 = dataReader.GetString(2);
                    estudiante.Apellido2 = dataReader.GetString(3);
                    estudiante.Correo = dataReader.GetString(4);
                    estudiante.Telefono = dataReader.GetInt32(5);
                    estudiante.Existe = true;
                }
                conexion.Close();

            } catch (Exception) {
                throw;
            }
            return estudiante;
        }//---------------------------


        //--Eliminar 
        public int EliminarEstudiante(EntidadEstudiante estudiante) {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "delete Estudiantes ";
            sentencia = string.Format("{0} where ID_Estudiantes = {1}", sentencia, estudiante.Identificacion);
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

        public int Modificar(EntidadEstudiante estudiante) {
            int filasAfectadas = -1,retorno;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            string sentencia = "update Estudiantes set Nombre=@nombre, Apellido1=@apellido1, " +
            "Apellido2=@apellido2,Correo=@correo,Telefono=@telefono where ID_Estudiantes=@idEstudiante";
            //----
            comando.Parameters.AddWithValue("@idEstudiante", estudiante.Identificacion);
            comando.Parameters.AddWithValue("@nombre", estudiante.Nombre);
            comando.Parameters.AddWithValue("@apellido1", estudiante.Apellido1);
            comando.Parameters.AddWithValue("@apellido2", estudiante.Apellido2);
            comando.Parameters.AddWithValue("@correo", estudiante.Correo);
            comando.Parameters.AddWithValue("@telefono", estudiante.Telefono);

            comando.CommandText = "MODIFICARESTUDIANTE";
            comando.Connection = conexion;

            //absorbemos el mensaje que soltara el SP de la BD
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            try {
                conexion.Open();
                comando.ExecuteNonQuery();
                //Los dos datos que devuelve lo guardamos en variables para usarlaas luego
                retorno = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@msj"].Value.ToString();

                //filasAfectadas = (int)comando.ExecuteScalar();
                conexion.Close();
            } catch (Exception) {
                throw;
            } finally {
                conexion.Dispose();
                comando.Dispose();
            }
            return retorno;
        }//----------------------------------
    }
}
