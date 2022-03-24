using System;
using System.Data;
using CapaEntidades;
using System.Data.SqlClient; //nugget instalado
using System.Linq;
using System.Collections.Generic;

namespace Capa3AccesoDatos {
    public class DAClaseSincronica {

        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //constructor
        public DAClaseSincronica(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //propiedades
        public string Mensaje {
            get => _mensaje;
        }


        //Metodos Funcionales

        //----INSERTAR-------
        public int Insertar(EntidadClaseSincronica claseSinc) {
            int id = 0;
            int retorno;

            //Establecer el objeto conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto command para crear los comandos
            SqlCommand comando = new SqlCommand();

            //Se coloca el tipo de commandText es
            //comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "insert into ClaseSincronica(ID_Estudiante,ID_Profesor,ID_Curso,FechaClase,HoraInicio,HoraFinal)"+
                                    "values(@idEstudiante, @idProfesor, @idCurso, @fechaClase, @horaInicio, @horaFinal); ";
            //Sele indica que el tipo de comando a ejecutar es PROCEDIMIENTO ALMACENEADO

            //asignar la conexion al command
            comando.Connection = conexion;

            //Luego agregamos los datos de la entidad para enviarlos
            comando.Parameters.AddWithValue("@idEstudiante", claseSinc.Id_estudiante);
            comando.Parameters.AddWithValue("@idProfesor", claseSinc.Id_profesor);
            comando.Parameters.AddWithValue("@idCurso", claseSinc.Id_curso);
            comando.Parameters.AddWithValue("@fechaClase", claseSinc.FechaClase);
            comando.Parameters.AddWithValue("@horaInicio", claseSinc.HoraInicio);
            comando.Parameters.AddWithValue("@horaFinal", claseSinc.HoraFinal);

            //absorbemos el mensaje que soltara el SP de la BD
            //comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            //comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            try {
                conexion.Open();//se abre la conexion
                comando.ExecuteNonQuery();

                //Los dos datos que devuelve lo guardamos en variables para usarlaas luego
               // retorno = Convert.ToInt32(comando.Parameters["@retorno"].Value);
               // _mensaje = comando.Parameters["@msj"].Value.ToString();


                //if (retorno == 1) {
                    id = Convert.ToInt32(comando.ExecuteNonQuery());
                //}

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

            string sentencia = "Select * from ClaseSincronica";

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
                adapter.Fill(datos, "ClaseSincronica");
            } catch (Exception) {
                throw;
            }

            return datos;//Devuelve el DataSet

        }//------------

        //------Obtener un dato mediante un ID-------

        public EntidadClaseSincronica ObtenerClaseSincronica(int id) {
            EntidadClaseSincronica claseSinc = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//el data reader no tiene constructor se llena mediante un excecute
                                     //si el id es texto se debe de escribir entre comillas '{0}' en el string
            string sentencia = string.Format("Select ID_ClaseSincronica,ID_Estudiante,ID_Profesor,ID_Curso,FechaClase,HoraInicio,HoraFinal" +
            " from ClaseSincronica where ID_ClaseSincronica = {0}", id);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows) {
                    claseSinc = new EntidadClaseSincronica();
                    dataReader.Read();//Empieza a leer la informacion
                    claseSinc.Id_claseSincronica = dataReader.GetInt32(0);
                    claseSinc.Id_estudiante = dataReader.GetInt32(1);
                    claseSinc.Id_profesor = dataReader.GetInt32(2);
                    claseSinc.Id_curso = dataReader.GetString(3);
                    claseSinc.FechaClase = dataReader.GetDateTime(4);
                    claseSinc.HoraInicio =dataReader.GetDateTime(5);
                    claseSinc.HoraFinal =dataReader.GetDateTime(6);
                    claseSinc.Existe = true;
                }
                conexion.Close();

            } catch (Exception) {
                throw;
            }
            return claseSinc;
        }//---------------------------




        public string[] ObtenerEstudianteClaseSincronica(int id) {
            string[] claseSinc = new string[4];
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//el data reader no tiene constructor se llena mediante un excecute
                                     //si el id es texto se debe de escribir entre comillas '{0}' en el string
            string sentencia = string.Format("select Estudiantes.ID_Estudiantes,Cursos.ID_Curso,Profesores.ID_Profesor,NombreCurso from Estudiantes inner join Matricula on " +
            "Matricula.ID_Estudiantes = Estudiantes.ID_Estudiantes inner join Cursos on Cursos.ID_Curso = Matricula.ID_Curso inner join Certificaciones " +
            "on Certificaciones.Materia = Cursos.NombreCurso inner join Profesores on Certificaciones.ID_Profesor = Profesores.ID_Profesor where Estudiantes.ID_Estudiantes = {0}", id);

            
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows) {
                    dataReader.Read();//Empieza a leer la informacion
                    claseSinc[0] = dataReader.GetInt32(0).ToString();
                    claseSinc[1] = dataReader.GetString(1);
                    claseSinc[2] = dataReader.GetInt32(2).ToString();
                    claseSinc[3] = dataReader.GetString(3);
                }
                conexion.Close();

            } catch (Exception) {
                throw;
            }
            return claseSinc;
        }//---------------------------





        //--Eliminar 
        public int EliminarClaseSincronica(EntidadClaseSincronica claseSinc) {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "delete ClaseSincronica ";
            sentencia = string.Format("{0} where ID_ClaseSincronica = {1}", sentencia, claseSinc.Id_claseSincronica);
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

        public int Modificar(EntidadClaseSincronica claseSinc) {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "update ClaseSincronica set ID_ClaseSincronica=@idClaseSinc,ID_Estudiante=@idEstudiantes,ID_Profesor=@idProfesor, ID_Curso=@idCurso, " +
            "FechaClase=@fechaClase,HoraInicio=@horaInicio,HoraFinal=@horaFinal" +
            " where ID_ClaseSincronica=@idClaseSinc";
            //----
            comando.Parameters.AddWithValue("@idClaseSinc", claseSinc.Id_claseSincronica);
            comando.Parameters.AddWithValue("@idEstudiantes", claseSinc.Id_estudiante);
            comando.Parameters.AddWithValue("@idProfesor", claseSinc.Id_profesor);
            comando.Parameters.AddWithValue("@idCurso", claseSinc.Id_curso);
            comando.Parameters.AddWithValue("@fechaClase", claseSinc.FechaClase);
            comando.Parameters.AddWithValue("@horaInicio", claseSinc.HoraInicio);
            comando.Parameters.AddWithValue("@horaFinal", claseSinc.HoraFinal);

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
