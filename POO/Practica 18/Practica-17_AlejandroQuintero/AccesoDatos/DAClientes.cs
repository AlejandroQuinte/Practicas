using System;
using Entidades;
using System.Data.SqlClient;
using System.Data; // el using que se va a utilizar para realizar el acceso a la base de datos
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos
{
    public class DAClientes
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
        public DAClientes(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        // Metodos

        // inserta y devuelve el id generado en la insersion en la tabla
        public int Insertar(EntidadCliente cliente)
        {
            //establecer el objeto de conexión para la bd
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            //establecer el objeto para ejecutar comendos de SQL
            SqlCommand comando = new SqlCommand();
            //variable que guarda el id ingresado en la bd y la función lo devuleve
            int id = 0;
            string sentencia = "INSERT INTO CLIENTES(NOMBRE,TELEFONO,DIRECCION) " +
                    "VALUES(@NOMBRE,@TELEFONO,@DIRECCION) select @@identity";
            //se le pasa al comando la cadena de conexion 
            comando.Connection = conexion;
            // se especifican las variables que van en la sentencia SQL
            comando.Parameters.AddWithValue("@NOMBRE", cliente.getNombre());
            comando.Parameters.AddWithValue("@TELEFONO", cliente.getTelefono());
            comando.Parameters.AddWithValue("@DIRECCION", cliente.getDireccion());
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
        }// fin método insertar


        //devuelve un dataset de clientes para mostrarlo en un datagridView
        public DataSet ListarClientesDS(string condicion, string orden) {
            DataSet datos = new DataSet(); //Aqui se guardar la tabla de la consulta del sql
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_CLIENTE, NOMBRE, TELEFONO, DIRECCION FROM CLIENTES";

            if (!string.IsNullOrEmpty(condicion)) { //si la condicion no esta vacia entonces concatene esa condicion a la sentencia
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }

            if (!string.IsNullOrEmpty(orden)) {//si orden no esta vacia entonces concatene ese orden a la sentencia
                sentencia = string.Format("{0} order by {1}", sentencia, orden);
            }
            try {
                adapter = new SqlDataAdapter(sentencia, conexion);
                //se realiza la conexion y se prepara el adaptador para ejecutar la sentencia
                adapter.Fill(datos, "Clientes");//el adaptador llena el dataset y le pone nombre 
            } catch (Exception) {
                throw;
            }
            return datos; //devuelve el dataset
        }//DataSet ListarClientes

        public List<EntidadCliente> ListarClientes(string condicion = "")
        {//devuelve una lista de clientes en lugar de un dataset 
            DataSet DS = new DataSet();//dataset donde se almacenara la informacion de la tabla de sql
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            List<EntidadCliente> clientes;//la lista de clientes que se devolvera
            //List<EntidadCliente> clientes = new List<EntidadCliente>();
            string sentencia = "SELECT ID_CLIENTE, NOMBRE,TELEFONO,DIRECCION FROM CLIENTES";

            if (!string.IsNullOrEmpty(condicion)) //si la condicion tiene valores concatenela con la sentencia
            {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(DS, "Clientes");//se llena el dataset y se le pone nombre
                                             //sentencia linQ para convertir el dataset en una lista "using System.Linq;"
                clientes = (from DataRow fila in DS.Tables["Clientes"].Rows
                             select new EntidadCliente()
                             {
                                 Id_cliente = (int)fila[0],
                                 Nombre = fila[1].ToString(),
                                 Telefono = fila[2].ToString(),
                                 Direccion = fila[3].ToString(),
                                 Existe = true
                             }).ToList();//al final convierte lo del dataset en instancias de
                                         //clientes y llena la lista con clientes que hay en las tablas
               /*  
                // Cargar la Lista con el DataSet sin usar LinQ
               
                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    clientes.Add(new EntidadCliente
                    {
                        Id_cliente = Convert.ToInt32(dr["Id_cliente"]),
                        Nombre = Convert.ToString(dr["Nombre"]),
                        Telefono = Convert.ToString(dr["Telefono"]),
                        Direccion = Convert.ToString(dr["Direccion"])
                    });
                }*/
            }
            catch (Exception)
            {
                throw;
            }
            return clientes;//devuelve la lista con los clientes
        }// fin  List<EntidadCliente> ListarClientes


        public EntidadCliente ObtenerCliente(int id)
        {  //devuelve un cliente cuando se busca
            EntidadCliente cliente = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//el data reader no tiene constructor se lenna mediante un execute
            string sentencia = string.Format("SELECT ID_CLIENTE,NOMBRE,TELEFONO,DIRECCION FROM " +
                "CLIENTES WHERE ID_CLIENTE ={0}", id);
            //si el id es texto se escribr entre comillas '{0}' en el string
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    cliente = new EntidadCliente();
                    dataReader.Read();//lee fila por fila del data reader
                    cliente.Id_cliente = dataReader.GetInt32(0);
                    cliente.Nombre = dataReader.GetString(1);
                    cliente.Telefono = dataReader.GetString(2);
                    cliente.Direccion = dataReader.GetString(3);
                    cliente.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)  { throw; }
            return cliente;
        }//fin ObtenerCliente

        public int EliminarRegistroConSP(EntidadCliente cliente)
        { //eliminar registro con Stored Procedure
            int resultado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "EliminarCliente"; //nombre del procedimiento almacenado
            //se especifica que tipo de comando es, en este caso es un procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexion;
            //parametro de entrada para el SP
            comando.Parameters.AddWithValue("@idcliente", cliente.Id_cliente);
            //parametro de salida del SP
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            //se declara otro parametro de retorno del SP que obtenga el retorno del SP
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery(); //ejecuta el SP y se llenan las variables de retorno del SP
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value); //obtengo la variable de retorno
                //se va a leer el parametro de salida del SP
                _mensaje = comando.Parameters["@msj"].Value.ToString();//obtiene el mensaje que se devolvio del SP
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }//EliminarRegistroConSP


        public int EliminarCliente(EntidadCliente cliente) {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM CLIENTES";
            sentencia = string.Format("{0} WHERE ID_CLIENTE ={1}", sentencia, cliente.Id_cliente);
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                afectado = comando.ExecuteNonQuery();
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
            return afectado;
        }// fin EliminarCliente


         public int Modificar(EntidadCliente cliente)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE CLIENTES SET NOMBRE=@NOMBRE, TELEFONO=@TELEFONO, " +
                "DIRECCION=@DIRECCION WHERE ID_CLIENTE=@ID_CLIENTE";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_CLIENTE", cliente.Id_cliente);
            comando.Parameters.AddWithValue("@NOMBRE", cliente.Nombre);
            comando.Parameters.AddWithValue("@TELEFONO", cliente.Telefono);
            comando.Parameters.AddWithValue("@DIRECCION", cliente.Direccion);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
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
            return filasAfectadas;
        }//Modificar

    }// fin class DAClientes
}// fin namespace AccesoDatos


