using CapaEntidades;
using System;

using CapaEntidades;
using System.Data.SqlClient; //nugget instalado

namespace Capa3AccesoDatos {
    public class DAProducto {
        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //Constructor
        public DAProducto(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //propiedades
        public string Mensaje {
            get => _mensaje;
        }

        public int Insertar(EntidadProducto producto) {
            int id = 0;

            //Establecer el objeto conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            //Establecer el objeto command para crear los comandos
            SqlCommand comando = new SqlCommand();
            //Asignar la conexion al command
            comando.Connection = conexion;
            //crear la sentencia
            string sentencia = "INSERT INTO Productos(Descripcion, PrecioCompra, PrecioVenta,Gravado) VALUES " +
                "(@direccion,@precioCompra,@precioVenta,@gravado) select @@identity";
            comando.Parameters.AddWithValue("@direccion", producto.Descripcion);
            comando.Parameters.AddWithValue("@precioCompra", producto.PrecioCompra);
            comando.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
            comando.Parameters.AddWithValue("@gravado", producto.Gravado);

            comando.CommandText = sentencia;
            try {
                conexion.Open();// se abre la conexion
                id = Convert.ToInt32(comando.ExecuteScalar()); // nos devuelve un dato
                conexion.Close();
            } catch (Exception) {
                throw;
            } finally {
                conexion.Dispose();
                comando.Dispose();
            }


            return id;
        }




    }
}
