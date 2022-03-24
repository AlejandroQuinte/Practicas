using System;
using System.Data;
using CapaEntidades;
using System.Data.SqlClient; //nugget instalado
using System.Linq;
using System.Collections.Generic;

namespace Capa3AccesoDatos {
    public class DAHorarioProfesor {

        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //constructor
        public DAHorarioProfesor(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //propiedades
        public string Mensaje {
            get => _mensaje;
        }


        //Metodos Funcionales

        //----INSERTAR-------
        public int Insertar(EntidadHorarioProfesor horarioProfesor) {
            int id = 0;
            int retorno;

            //Establecer el objeto conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto command para crear los comandos
            SqlCommand comando = new SqlCommand();

            //Se coloca el tipo de commandText es
            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "INSERTARHORARIOPROFESOR";//Asignamos el nombre del SP(Procedimiento almacenado)
            //Sele indica que el tipo de comando a ejecutar es PROCEDIMIENTO ALMACENEADO

            //asignar la conexion al command
            comando.Connection = conexion;

            //Luego agregamos los datos de la entidad para enviarlos
            comando.Parameters.AddWithValue("@idProfesor", horarioProfesor.Id_profesor);
            comando.Parameters.AddWithValue("@horaInicio", horarioProfesor.HoraInicio);
            comando.Parameters.AddWithValue("@horaFinal", horarioProfesor.HoraFinal);
            comando.Parameters.AddWithValue("@fechaInicio", horarioProfesor.FechaInicio);
            comando.Parameters.AddWithValue("@fechaFinal", horarioProfesor.FechaFinal);
            comando.Parameters.AddWithValue("@estado", horarioProfesor.Estado);

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

            return id;

        }//-------


        //-----Llamado de datos(Mostrar)-------

        //Devuelve un DATASET con datos de clientes, SOLO para ser mostrados con el DataGridView
        public DataSet ListarHorarioP(string condicion = "", string orden = "") {
            DataSet datos = new DataSet();  //en "datos" se va a guardar los resultados del select
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;

            string sentencia = "Select * from HorarioProfesor";

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
                adapter.Fill(datos, "HorarioProfesor");
            } catch (Exception) {
                throw;
            }

            return datos;//Devuelve el DataSet

        }//------------

        //------Obtener un dato mediante un ID-------

        public EntidadHorarioProfesor ObtenerHorarioP(int id) {
            EntidadHorarioProfesor horarioProfesor = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//el data reader no tiene constructor se llena mediante un excecute
                                     //si el id es texto se debe de escribir entre comillas '{0}' en el string
            string sentencia = string.Format("Select ID_HorarioProfesor,ID_Profesor,HoraInicio,HoraFinal,FechaInicio,FechaFinal," +
            "Estado from HorarioProfesor where ID_HorarioProfesor = {0}", id);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows) {
                    horarioProfesor = new EntidadHorarioProfesor();
                    dataReader.Read();//Empieza a leer la informacion
                    horarioProfesor.Id_horarioProfesor = dataReader.GetInt32(0);
                    horarioProfesor.Id_profesor = dataReader.GetInt32(1);
                    horarioProfesor.HoraInicio = dataReader.GetString(2);
                    horarioProfesor.HoraFinal = dataReader.GetString(3);
                    horarioProfesor.FechaInicio = dataReader.GetString(4);
                    horarioProfesor.FechaFinal = dataReader.GetString(5);
                    horarioProfesor.Existe = true;
                }
                conexion.Close();

            } catch (Exception) {
                throw;
            }
            return horarioProfesor;
        }//---------------------------


        //--Eliminar 
        public int EliminarHorarioP(EntidadHorarioProfesor horarioProfesor) {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "delete HorarioProfesor ";
            sentencia = string.Format("{0} where ID_HorarioProfesor = {1}", sentencia, horarioProfesor.Id_horarioProfesor);
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

        public int Modificar(EntidadHorarioProfesor horarioProfesor) {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            string sentencia = "update HorarioProfesor set ID_Profesor=@idProfesor, HoraInicio=@horaInicio, " +
            "HoraFinal=@horaFinal,FechaInicio=@fechaInicio,FechaFinal=@fechaFinal,Estado=@estado" +
            " where ID_HorarioProfesor=@idHorarioP";
            //----se envia el dato pero no se modifica ese dato
            comando.Parameters.AddWithValue("@idHorarioP", horarioProfesor.Id_horarioProfesor);
            comando.Parameters.AddWithValue("@idProfesor", horarioProfesor.Id_profesor);
            comando.Parameters.AddWithValue("@horaInicio", horarioProfesor.HoraInicio);
            comando.Parameters.AddWithValue("@HoraFinal", horarioProfesor.HoraFinal);
            comando.Parameters.AddWithValue("@fechaInicio", horarioProfesor.FechaInicio);
            comando.Parameters.AddWithValue("@fechaFinal", horarioProfesor.FechaFinal);
            comando.Parameters.AddWithValue("@estado", horarioProfesor.Estado);

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
