using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Entidades;

namespace AccesoDatos
{
    public class DAReservaciones
    {
        // Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedades
        public string Mensaje
        {
            get => _mensaje;
        }

        // Constructor
        public DAReservaciones(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public DataSet ListarReservacionesCliente(string condicion)
        {
            DataSet datos = new DataSet(); //Aqui se guardar la tabla de la consulta del sql
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT NUMRESERVACION, ID_CLIENTE, FECHAINGRESO, FECHASALIDA," +
                            " CANTIDADPERSONAS, TIPOHABITACION, PRECIO_NOCHE, CANCELADA, " +
                            "TOTALPAGAR FROM RESERVACIONES";

            if (!string.IsNullOrEmpty(condicion))
            { //si la condicion no esta vacia entonces concatene esa condicion a la sentencia
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                //se realiza la conexion y se prepara el adaptador para ejecutar la sentencia
                adapter.Fill(datos, "Reservaciones");//el adaptador llena el dataset y le pone nombre 
            }
            catch (Exception)
            {
                throw;
            }
            return datos; //devuelve el dataset
        }// ListarReservacionesCliente


        public int InsertarReservacionCliente(EntidadReservacion reservacion)
        {
            //establecer el objeto de conexión para la bd
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            //establecer el objeto para ejecutar comendos de SQL
            SqlCommand comando = new SqlCommand();
            //variable que guarda el id ingresado en la bd y la función lo devuleve
            int id = 0;
            string sentencia = "INSERT INTO  RESERVACIONES (ID_CLIENTE, FECHAINGRESO," +
                               " FECHASALIDA, CANTIDADPERSONAS, TIPOHABITACION,PRECIO_NOCHE, " +
                               " CANCELADA, TOTALPAGAR) VALUES(@ID_CLIENTE, @FECHAINGRESO, " +
                               " @FECHASALIDA, @CANTIDADPERSONAS, @TIPOHABITACION, " +
                               " @PRECIO_NOCHE, @CANCELADA, @TOTALPAGAR) select @@identity";
            //se le pasa al comando la cadena de conexion 
            comando.Connection = conexion;
            // se especifican las variables que van en la sentencia SQL
            comando.Parameters.AddWithValue("@ID_CLIENTE", reservacion.Idcliente);
            comando.Parameters.AddWithValue("@FECHAINGRESO", reservacion.Fingreso);
            comando.Parameters.AddWithValue("@FECHASALIDA", reservacion.Fsalida);
            comando.Parameters.AddWithValue("@CANTIDADPERSONAS", reservacion.CantPersonas);
            comando.Parameters.AddWithValue("@TIPOHABITACION", reservacion.TipoHab);
            comando.Parameters.AddWithValue("@PRECIO_NOCHE", reservacion.PrecioNoche);
            comando.Parameters.AddWithValue("@CANCELADA", reservacion.Cancelado);
            comando.Parameters.AddWithValue("@TOTALPAGAR", reservacion.Totalpagar);

            comando.CommandText = sentencia;
            //se ejecuta la consulta
            try
            {
                conexion.Open();
                id = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return id;
        }// fin método InsertarReservacionCliente



    }//class DAReservaciones
}//namespace AccesoDatos
