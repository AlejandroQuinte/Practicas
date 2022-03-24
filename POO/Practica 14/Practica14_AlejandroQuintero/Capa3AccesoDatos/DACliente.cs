using System;
using System.Collections.Generic;
using System.Text;

using CapaEntidades;
using System.Data.SqlClient; //nugget instalado

namespace Capa3AccesoDatos {
    public class DACliente {
        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //Constructor
        public DACliente(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //propiedades
        public string Mensaje {
            get => _mensaje;
        }


        public int Insertar(EntidadCliente cliente) {
            int id = 0;

            //Establecer el objeto conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            //Establecer el objeto command para crear los comandos
            SqlCommand comando = new SqlCommand();
            //Asignar la conexion al command
            comando.Connection = conexion;
            //crear la sentencia
            string sentencia = "INSERT INTO CLIENTES(NOMBRE, TELEFONO, DIRECCION) VALUES " +
                "(@NOMBRE,@TELEFONO,@DIRECCION) select @@identity";
            comando.Parameters.AddWithValue("@NOMBRE", cliente.getNombre());
            comando.Parameters.AddWithValue("@TELEFONO", cliente.getTelefono());
            comando.Parameters.AddWithValue("@DIRECCION", cliente.getDireccion());

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
