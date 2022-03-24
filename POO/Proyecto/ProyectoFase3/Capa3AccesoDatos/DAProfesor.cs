using System;
using System.Data;
using CapaEntidades;
using System.Data.SqlClient; //nugget instalado
using System.Linq;
using System.Collections.Generic;

namespace Capa3AccesoDatos {
    public class DAProfesor {

        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //constructor
        public DAProfesor(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //propiedades
        public string Mensaje {
            get => _mensaje;
        }


        //Metodos Funcionales

        //----INSERTAR-------
        public int Insertar(EntidadProfesor profesor) {
            int id = 0;
            int retorno;

            //Establecer el objeto conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto command para crear los comandos
            SqlCommand comando = new SqlCommand();

            //Se coloca el tipo de commandText es
            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "INSERTARPROFESOR";//Asignamos el nombre del SP(Procedimiento almacenado)
            //Sele indica que el tipo de comando a ejecutar es PROCEDIMIENTO ALMACENEADO

            //asignar la conexion al command
            comando.Connection = conexion;

            //Luego agregamos los datos de la entidad para enviarlos
            //comando.Parameters.AddWithValue("@idEstudiante", estudiante.Id_estudiante);
            comando.Parameters.AddWithValue("@nombre", profesor.Nombre);
            comando.Parameters.AddWithValue("@apellido1", profesor.Apellido1);
            comando.Parameters.AddWithValue("@apellido2", profesor.Apellido2);
            comando.Parameters.AddWithValue("@correo", profesor.Correo);
            comando.Parameters.AddWithValue("@telefono", profesor.Telefono);

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
        public DataSet ListarProfesor(string condicion = "", string orden = "") {
            DataSet datos = new DataSet();  //en "datos" se va a guardar los resultados del select
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;

            string sentencia = "Select * from Profesores";

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
                adapter.Fill(datos, "Profesores");
            } catch (Exception) {
                throw;
            }

            return datos;//Devuelve el DataSet

        }//------------

        //------Obtener un dato mediante un ID-------

        public EntidadProfesor ObtenerProfesor(int id) {
            EntidadProfesor profersor = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//el data reader no tiene constructor se llena mediante un excecute
                                     //si el id es texto se debe de escribir entre comillas '{0}' en el string
            string sentencia = string.Format("Select ID_Profesor,Nombre,Apellido1,Apellido2,Correo,Telefono " +
            "from Profesores where ID_Profesor = {0}", id);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows) {
                    profersor = new EntidadProfesor();
                    dataReader.Read();//Empieza a leer la informacion
                    profersor.Identificacion = dataReader.GetInt32(0);
                    profersor.Nombre = dataReader.GetString(1);
                    profersor.Apellido1 = dataReader.GetString(2);
                    profersor.Apellido2 = dataReader.GetString(3);
                    profersor.Correo = dataReader.GetString(4);
                    profersor.Telefono = dataReader.GetInt32(5);
                    profersor.Existe = true;
                }
                conexion.Close();

            } catch (Exception) {
                throw;
            }
            return profersor;
        }//---------------------------


        //--Eliminar 
        public int EliminarProfesor(EntidadProfesor profesor) {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "delete Profesores ";
            sentencia = string.Format("{0} where ID_Profesor = {1}", sentencia, profesor.Identificacion);
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

        public int Modificar(EntidadProfesor profesor) {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "update Profesores set Nombre=@nombre, Apellido1=@apellido1, " +
            "Apellido2=@apellido2,Correo=@correo,Telefono=@telefono where ID_Profesor=@idProfesor";
            //----
            comando.Parameters.AddWithValue("@idProfesor", profesor.Identificacion);
            comando.Parameters.AddWithValue("@nombre", profesor.Nombre);
            comando.Parameters.AddWithValue("@apellido1", profesor.Apellido1);
            comando.Parameters.AddWithValue("@apellido2", profesor.Apellido2);
            comando.Parameters.AddWithValue("@correo", profesor.Correo);
            comando.Parameters.AddWithValue("@telefono", profesor.Telefono);

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
