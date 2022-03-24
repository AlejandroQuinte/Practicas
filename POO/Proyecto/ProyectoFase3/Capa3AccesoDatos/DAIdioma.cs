using System;
using System.Data;
using CapaEntidades;
using System.Data.SqlClient; //nugget instalado
using System.Linq;
using System.Collections.Generic;

namespace Capa3AccesoDatos {
    public class DAIdioma {

        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //constructor
        public DAIdioma(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //propiedades
        public string Mensaje{
            get => _mensaje;
        }

        //Metodos Funcionales

        //----INSERTAR-------
        public string Insertar(EntidadIdioma idioma){
            string id = "";
            int retorno;

            //Establecer el objeto conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto command para crear los comandos
            SqlCommand comando = new SqlCommand();

            //Se coloca el tipo de commandText es
            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "INSERTARIDIOMA";//Asignamos el nombre del SP(Procedimiento almacenado)
            //Sele indica que el tipo de comando a ejecutar es PROCEDIMIENTO ALMACENEADO

            //asignar la conexion al command
            comando.Connection = conexion;

            //Luego agregamos los datos de la entidad para enviarlos
            comando.Parameters.AddWithValue("@ididioma", idioma.IdIdioma);
            comando.Parameters.AddWithValue("@nombreidioma", idioma.NombreIdioma);

            //absorbemos el mensaje que soltara el SP de la BD
            comando.Parameters.Add("@msj", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            try{
                conexion.Open();//se abre la conexion
                comando.ExecuteNonQuery();

                //Los dos datos que devuelve lo guardamos en variables para usarlaas luego
                retorno = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@msj"].Value.ToString();
                
                if(retorno == 1){
                    id = Convert.ToString(comando.ExecuteScalar());
                }
                
                conexion.Close();

            }catch(Exception){
                throw;
            }
            finally{
                conexion.Dispose();
                comando.Dispose();
            }

            return id;

        }//-------


        //-----Llamado de datos(Mostrar)-------

        //Devuelve un DATASET con datos de clientes, SOLO para ser mostrados con el DataGridView
        public DataSet ListarIdioma(string condicion = "", string orden = ""){
            DataSet datos = new DataSet();  //en "datos" se va a guardar los resultados del select
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;

            string sentencia = "Select ID_Idioma,NombreIdioma from Idiomas";

            //Si el parametro de condicion no esta vacio, lo concatena a la sentencia
            if(!string.IsNullOrEmpty(condicion)){
                sentencia = string.Format("{0} where {1}", sentencia,condicion);
            }
            //Para orden
            if(!string.IsNullOrEmpty(orden)){
                sentencia = string.Format("{0} order by {1}", sentencia, orden);
            }

            //Se ejecuta
            try{
                adapter = new SqlDataAdapter(sentencia, conexion);
                //el adapter .fill llena "adapter" con los datos del dataset "datos" y le asigna el nombre "Idiomas"
                adapter.Fill(datos, "Idiomas");
            }catch(Exception){
                throw;
            }

            return datos;//Devuelve el DataSet

        }//------------

        //------Obtener un dato mediante un ID-------

        public EntidadIdioma ObtenerIdioma(string id){
            EntidadIdioma idioma = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//el data reader no tiene constructor se llena mediante un excecute
                                      //si el id es texto se debe de escribir entre comillas '{0}' en el string
            string sentencia = string.Format("Select ID_Idioma,NombreIdioma from Idiomas where ID_Idioma = '{0}'", id);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try{
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if(dataReader.HasRows){
                    idioma= new EntidadIdioma();
                    dataReader.Read();//Empieza a leer la informacion
                    idioma.IdIdioma = dataReader.GetString(0);
                    idioma.NombreIdioma = dataReader.GetString(1);
                    idioma.Existe = true;
                }
                conexion.Close();

            }catch(Exception){
                throw;
            }
            return idioma;
        }//---------------------------


        //--Eliminar 
        public int EliminarIdioma(EntidadIdioma idioma){
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "delete Idiomas ";
            sentencia = string.Format("{0} where ID_Idioma = '{1}'", sentencia,idioma.IdIdioma);
            comando.CommandText =sentencia; 
            comando.Connection = conexion;

            try{
                conexion.Open();
                afectado = comando.ExecuteNonQuery();
                conexion.Close();
            }catch(Exception){
                throw;
            }
            finally{
                conexion.Dispose();
                comando.Dispose();
            }
            return afectado;

        }//-----------------------------------------------



        //---Modificar

        public int Modificar(EntidadIdioma idioma){
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "update Idiomas set NombreIdioma=@nombreIdioma where ID_Idioma=@idIdioma";
            comando.Parameters.AddWithValue("@nombreIdioma",idioma.NombreIdioma);
            comando.Parameters.AddWithValue("@idIdioma", idioma.IdIdioma);
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            
            try{
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }catch(Exception){
                throw;
            }
            finally{
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;
        }//----------------------------------










    }
}
