using Capa3AccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient; //nugget instalado
using System.Linq;

namespace Capa2LogicaNegocio {
    public class BLProducto {
        //atributos
        private string _cadenaConexion;
        private string _mensaje;


        //constructor
        public BLProducto(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            this._mensaje = "";
        }
        //Propiedades
        public string Mensaje {
            get => _mensaje;
        }

        public int Insertar(EntidadProducto producto) {
            int id_cliente = 0;
            DAProducto accesoDatos = new DAProducto(_cadenaConexion); //se crea una instancia para la 3er
            try {
                id_cliente = accesoDatos.Insertar(producto);
            } catch (Exception ex) {
                throw;
            }
            return id_cliente;
        }




        //Buscar Productos
        public DataSet ListarProductos(string condicion = "", string orden = "") {
            DataSet DS;
            DAProducto accesodatos = new DAProducto(_cadenaConexion);
            try {
                DS = accesodatos.ListarProductos(condicion, orden);
            } catch (Exception) {
                throw;
            }
            return DS;

        }// FIN Listar Productos


        public EntidadProducto ObtenerProducto(int id) {
            EntidadProducto producto;
            DAProducto accesoDatos = new DAProducto(_cadenaConexion);
            try {
                producto = accesoDatos.ObtenerProducto(id);
            } catch (Exception) {
                throw;
            }
            return producto;
        }//-------------------------


        public int EliminarProducto(EntidadProducto producto){
            int resultado;
            DAProducto accesoDatos = new DAProducto(_cadenaConexion);

            try{

                resultado = accesoDatos.EliminarProducto(producto);
                _mensaje = accesoDatos.Mensaje;

            }catch(Exception){
                throw;
            }

            return resultado;

        }//------------------------------


        public int Modificar(EntidadProducto producto){
            int filasAfectadas;
            DAProducto accesoDatos = new DAProducto(_cadenaConexion);

            try{
                filasAfectadas = accesoDatos.Modificar(producto);
            }catch(Exception){
                throw;
            }
            return filasAfectadas;
        }


    }
}
