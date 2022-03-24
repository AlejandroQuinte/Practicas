using System;
using System.Data;
using CapaEntidades;
using System.Data.SqlClient; //nugget instalado
using System.Linq;
using System.Collections.Generic;

namespace Capa3AccesoDatos {
    public class DACurso {

        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //constructor
        public DACurso(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //propiedades
        public string Mensaje {
            get => _mensaje;
        }


        //Metodos Funcionales

        //----INSERTAR-------
        public string Insertar(EntidadCurso Curso) {
            string id = "";
            int retorno;

            //Establecer el objeto conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto command para crear los comandos
            SqlCommand comando = new SqlCommand();

            //Se coloca el tipo de commandText es
            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "INSERTARCURSO";//Asignamos el nombre del SP(Procedimiento almacenado)
            //Sele indica que el tipo de comando a ejecutar es PROCEDIMIENTO ALMACENEADO

            //asignar la conexion al command
            comando.Connection = conexion;

            //Luego agregamos los datos de la entidad para enviarlos
            comando.Parameters.AddWithValue("@idCurso", Curso.Id_curso);
            comando.Parameters.AddWithValue("@idNota", Curso.Id_nota);
            comando.Parameters.AddWithValue("@idIdioma", Curso.Id_idioma);
            comando.Parameters.AddWithValue("@nombreCurso", Curso.NombreCurso);
            comando.Parameters.AddWithValue("@cantidadCurso", Curso.CantidadCursos);
            comando.Parameters.AddWithValue("@horasCurso", Curso.HorasCurso);
            comando.Parameters.AddWithValue("@horasSincronicas", Curso.HorasSincronicas);
            comando.Parameters.AddWithValue("@horasAsincronicas", Curso.HorasAsincronicas);
            comando.Parameters.AddWithValue("@precio", Curso.Precio);

            //absorbemos el mensaje que soltara el SP de la BD
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            try {
                conexion.Open();//se abre la conexion
                comando.ExecuteNonQuery();

                //Los dos datos que devuelve lo guardamos en variables para usarlaas luego
                retorno = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@msj"].Value.ToString();


                //El valor del retorno puede ser diferentes, 1 si fue todo correcto y se agrego el nuevo Curso
                //0=ID_CURSO ya existe
                //1=Se agrego todo correcto
                //2=El ID_NOTA no se encuentra en la base de datos
                //3=El ID_IDIOMA no se encuentra en la base de datos

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
        public DataSet ListarCurso(string condicion = "", string orden = "") {
            DataSet datos = new DataSet();  //en "datos" se va a guardar los resultados del select
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;

            string sentencia = "Select * from Cursos";

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
                adapter.Fill(datos, "Cursos");
            } catch (Exception) {
                throw;
            }

            return datos;//Devuelve el DataSet

        }//------------

        //------Obtener un dato mediante un ID-------

        public EntidadCurso ObtenerCurso(string id) {
            EntidadCurso Curso = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//el data reader no tiene constructor se llena mediante un excecute
                                     //si el id es texto se debe de escribir entre comillas '{0}' en el string
            string sentencia = string.Format("Select ID_Curso,ID_Nota,ID_Idioma,NombreCurso,CantidadCursos,HorasCurso," +
            "HorasSincronicas,HorasAsincronicas,Precio from Cursos where ID_Curso = '{0}'", id);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows) {
                    Curso = new EntidadCurso();
                    dataReader.Read();//Empieza a leer la informacion
                    Curso.Id_curso = dataReader.GetString(0);
                    Curso.Id_nota = dataReader.GetInt32(1);
                    Curso.Id_idioma = dataReader.GetString(2);
                    Curso.NombreCurso = dataReader.GetString(3);
                    Curso.CantidadCursos = dataReader.GetInt32(4);
                    Curso.HorasCurso = dataReader.GetInt32(5);
                    Curso.HorasSincronicas = dataReader.GetInt32(6);
                    Curso.HorasAsincronicas = dataReader.GetInt32(7);
                    //Se pide el dato del tippo double luego se convierte, ocurre un fallo si se hace directamente
                    double num = dataReader.GetDouble(8);
                    Curso.Precio = (float)num;
                    Curso.Existe = true;
                }
                conexion.Close();

            } catch (Exception) {
                throw;
            }
            return Curso;
        }//---------------------------


        //--Eliminar 
        public int EliminarCurso(EntidadCurso curso) {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "delete Cursos ";
            sentencia = string.Format("{0} where ID_Curso = '{1}'", sentencia, curso.Id_curso);
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

        public int Modificar(EntidadCurso curso) {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "update Cursos set ID_Curso=@idCurso,ID_Nota=@idNota, ID_Idioma=@idIdioma, " +
            "NombreCurso=@nombreCurso,CantidadCursos=@cantCurso,HorasCurso=@horasCurso," +
            "HorasSincronicas=@horasSinc,HorasAsincronicas=@horasAsinc,Precio=@precio where ID_Curso=@idCurso";
            //----
            comando.Parameters.AddWithValue("@idCurso", curso.Id_curso);
            comando.Parameters.AddWithValue("@idNota", curso.Id_nota);
            comando.Parameters.AddWithValue("@idIdioma", curso.Id_idioma);
            comando.Parameters.AddWithValue("@nombreCurso", curso.NombreCurso);
            comando.Parameters.AddWithValue("@cantCurso", curso.CantidadCursos);
            comando.Parameters.AddWithValue("@horasCurso", curso.HorasCurso);
            comando.Parameters.AddWithValue("@horasSinc", curso.HorasSincronicas);
            comando.Parameters.AddWithValue("@horasAsinc", curso.HorasAsincronicas);
            comando.Parameters.AddWithValue("@precio", curso.Precio);

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
