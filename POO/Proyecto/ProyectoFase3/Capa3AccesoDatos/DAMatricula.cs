using System;
using System.Data;
using CapaEntidades;
using System.Data.SqlClient; //nugget instalado
using System.Linq;
using System.Collections.Generic;

namespace Capa3AccesoDatos {
    public class DAMatricula {

        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //constructor
        public DAMatricula(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //propiedades
        public string Mensaje {
            get => _mensaje;
        }


        //Metodos Funcionales

        //----INSERTAR-------
        public int Insertar(EntidadMatricula matricula) {
            int id=0;
            int retorno;

            //Establecer el objeto conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto command para crear los comandos
            SqlCommand comando = new SqlCommand();

            //Se coloca el tipo de commandText es
            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "INSERTARMATRICULA";//Asignamos el nombre del SP(Procedimiento almacenado)
            //Sele indica que el tipo de comando a ejecutar es PROCEDIMIENTO ALMACENEADO

            //asignar la conexion al command
            comando.Connection = conexion;

            //Luego agregamos los datos de la entidad para enviarlos
            //comando.Parameters.AddWithValue("@idMatricula", matricula.Id_matricula);
            comando.Parameters.AddWithValue("@idEstudiante", matricula.Id_estudiantes);
            comando.Parameters.AddWithValue("@idCurso", matricula.Id_curso);
            comando.Parameters.AddWithValue("@intensidad", matricula.Intensidad);
            comando.Parameters.AddWithValue("@fechaMatricula", matricula.Fechamatricula);
            comando.Parameters.AddWithValue("@totalPago", matricula.Totalpago);
            comando.Parameters.AddWithValue("@estadoPago", matricula.Estadopago);
            
            //absorbemos el mensaje que soltara el SP de la BD
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            try {
                conexion.Open();//se abre la conexion
                comando.ExecuteNonQuery();

                //Los dos datos que devuelve lo guardamos en variables para usarlaas luego
                retorno = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@msj"].Value.ToString();


               if(retorno == 1){
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
        public DataSet ListarMatricula(string condicion = "", string orden = "") {
            DataSet datos = new DataSet();  //en "datos" se va a guardar los resultados del select
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;

            string sentencia = "Select * from Matricula";

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
                adapter.Fill(datos, "Matricula");
            } catch (Exception) {
                throw;
            }

            return datos;//Devuelve el DataSet

        }//------------

        //------Obtener un dato mediante un ID-------

        public EntidadMatricula ObtenerMatricula(int id) {
            EntidadMatricula matricula = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//el data reader no tiene constructor se llena mediante un excecute
                                     //si el id es texto se debe de escribir entre comillas '{0}' en el string
            string sentencia = string.Format("Select ID_Matricula,ID_Estudiantes,ID_Curso,Intensidad,FechaMatricula,TotalPago," +
            "EstadoPago from Matricula where ID_Matricula = {0}", id);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows) {
                    matricula = new EntidadMatricula();
                    dataReader.Read();//Empieza a leer la informacion
                    matricula.Id_matricula = dataReader.GetInt32(0);
                    matricula.Id_estudiantes = dataReader.GetInt32(1);
                    matricula.Id_curso = dataReader.GetString(2);
                    matricula.Intensidad = dataReader.GetInt32(3);
                    matricula.Fechamatricula = dataReader.GetDateTime(4);
                    //Se pide el dato del tippo double luego se convierte, ocurre un fallo si se hace directamente
                    double num = dataReader.GetDouble(5);
                    matricula.Totalpago = (float)num;
                    matricula.Estadopago = dataReader.GetString(6);
                    matricula.Existe = true;
                }
                conexion.Close();

            } catch (Exception) {
                throw;
            }
            return matricula;
        }//---------------------------


        //--Eliminar 
        public int EliminarMatricula(EntidadMatricula matricula) {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "delete Matricula ";
            sentencia = string.Format("{0} where ID_Matricula = {1}", sentencia, matricula.Id_matricula);
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

        public int Modificar(EntidadMatricula matricula) {
            int retorno = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "update Matricula set ID_Curso=@idCurso, " +
            "Intensidad=@intensidad,FechaMatricula=@fechaMatricula,TotalPago=@totalPago," +
            "EstadoPago=@estadoPago where ID_Matricula=@idMatricula";
            //----
            

            comando.CommandType = CommandType.StoredProcedure ;
            comando.CommandText = "MODIFICARMATRICULA";

            comando.Parameters.AddWithValue("@idMatricula", matricula.Id_matricula);
            //comando.Parameters.AddWithValue("@idEstudiantes", matricula.Id_estudiantes);
            comando.Parameters.AddWithValue("@idCurso", matricula.Id_curso);
            comando.Parameters.AddWithValue("@intensidad", matricula.Intensidad);
            comando.Parameters.AddWithValue("@fechaMatricula", matricula.Fechamatricula);
            comando.Parameters.AddWithValue("@totalPago", matricula.Totalpago);
            comando.Parameters.AddWithValue("@estadoPago", matricula.Estadopago);

            //absorbemos el mensaje que soltara el SP de la BD
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            comando.Connection = conexion;

            try {
                conexion.Open();
                comando.ExecuteNonQuery();
                //Los dos datos que devuelve lo guardamos en variables para usarlaas luego
                retorno = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@msj"].Value.ToString();
                conexion.Close();
            } catch (Exception) {
                throw;
            } finally {
                conexion.Dispose();
                comando.Dispose();
            }
            return retorno;
        }//----------------------------------


        public string[] ObtenerCursoMatricula(string idCurso) {
            string[] Curso= new string[9];
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//el data reader no tiene constructor se llena mediante un excecute
                                     //si el id es texto se debe de escribir entre comillas '{0}' en el string
            string sentencia = string.Format("Select ID_Curso,ID_Nota,ID_Idioma,NombreCurso,CantidadCursos,HorasCurso,HorasSincronicas," +
            "HorasAsincronicas,Precio from Cursos where ID_Curso = '{0}'", idCurso);

            comando.Connection = conexion;
            comando.CommandText = sentencia;



            try {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows) {

                    dataReader.Read();//Empieza a leer la informacion
                    double num;
                    Curso[0] = dataReader.GetString(0);
                    Curso[1] = dataReader.GetInt32(1).ToString();
                    Curso[2] = dataReader.GetString(2);
                    Curso[3] = dataReader.GetString(3);
                    Curso[4] = dataReader.GetInt32(4).ToString();
                    Curso[5] = dataReader.GetInt32(5).ToString();
                    Curso[6] = dataReader.GetInt32(6).ToString();
                    Curso[7] = dataReader.GetInt32(7).ToString();
                    num = dataReader.GetDouble(8);
                    Curso[8] = num.ToString();

                }
                conexion.Close();

            } catch (Exception) {
                throw;
            }
            return Curso;
        }//---------------------------


    }
}
