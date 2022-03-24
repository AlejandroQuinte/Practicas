using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CapaEntidades;
using System.Data.SqlClient; //nugget instalado
using System.Linq;




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


        public List<EntidadCliente> ListarClientes(string condicion = " ") {
            //devuelve una lista de clientes en lugar de un dataset
            DataSet DS = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            List<EntidadCliente> clientes; //La lista de clientes que se va a devolver
            string sentencia = "SELECT ID_CLIENTE, NOMBRE, TELEFONO, DIRECCION FROM CLIENTES";

            if (!string.IsNullOrEmpty(condicion)) {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }
            try {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(DS, "Clientes"); //se llena el dataset y se le pone nombre
                //sentencia linQ para convertir en dataset en una lista "USING SYSTEM.LINQ"
                clientes = (from DataRow fila in DS.Tables["Clientes"].Rows
                            select new EntidadCliente() {
                                //se llama a los GET y SET RAPIDOS
                                Id_cliente = (int)fila[0],
                                Nombre = fila[1].ToString(),
                                Telefono = fila[2].ToString(),
                                Direccion = fila[3].ToString(),
                                Existe = true
                            }).ToList(); //al final convierte los datos de un dataset en instancias de clientes y llena la lista con clientes que hay en las tablas

            } catch (Exception) {
                throw;
            }
            return clientes;

        }




        public DataSet ListarClientes(string condicion = "", string orden = "") {
            DataSet datos = new DataSet(); //en "datos" se va aguardar los resultados del select
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;

            string sentencia = "SELECT ID_CLIENTE, NOMBRE, TELEFONO, DIRECCION FROM CLIENTES";

            //Si el parametro de condicion no esta vacio, lo concatena a la sentencia
            if (!string.IsNullOrEmpty(condicion)) {
                sentencia = string.Format("{0} whrere {1}", sentencia, condicion);
            }
            //para orden
            if (!string.IsNullOrEmpty(orden)) {
                sentencia = string.Format("{0} order by {1}", sentencia, orden);
            }
            //se ejecuta
            try {
                adapter = new SqlDataAdapter(sentencia, conexion);
                //el adapter .fill llena "adapter" con los datos del dataset "datos" y le asigna el nombre "clientes
                //"
                adapter.Fill(datos, "Clientes");
            } catch (Exception) {
                throw;
            }
            return datos; //devuelve el dataset

        }//FIN LISTAR CLIENTES




        //Obtener un unico cliente
        public EntidadCliente ObtenerCliente(int id) {
            EntidadCliente cliente = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader; //el data reader no tiene constructor se llena mediante un excecute
            string sentencia = string.Format("Select ID_CLIENTE, NOMBRE, TELEFONO, DIRECCION FROM CLIENTES WHERE ID_CLIENTE = {0}", id);
            //si el id es texto se debe de escribir entre comillas '{0}' en el string
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows) {
                    cliente = new EntidadCliente();
                    dataReader.Read(); //lee fila por fila el data rader
                    cliente.Id_cliente = dataReader.GetInt32(0);
                    cliente.Nombre = dataReader.GetString(1);
                    cliente.Telefono = dataReader.GetString(2);
                    cliente.Direccion = dataReader.GetString(3);
                    cliente.Existe = true;
                }
                conexion.Close();
            } catch (Exception) {
                throw;
            }
            return cliente;
        }








    }
}
