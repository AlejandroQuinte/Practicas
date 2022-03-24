using System;
using System.Collections.Generic;
using System.Data;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio {
    public class blProducto {
        // Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedades
        public string Mensaje {
            get => _mensaje;
        }

        // Constructor
        public blProducto(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        // métodos
        // método para llamar a insertar de la capaAcceso a Datos
        public int Insertar(entidadProducto producto) {
            int idProducto = 0;
            DAProducto accesoDatos = new DAProducto(_cadenaConexion);
            try {
                idProducto = accesoDatos.Insertar(producto);
            } catch (Exception) {
                throw;
            }
            return idProducto;
        }// Fin Class Insertar


        //llama al metodo listar clientes y trae los datos en un dataSet
        public DataSet ListarProductosDS(string condicion, string orden) {
            DataSet DS;
            DAProducto accesoDatos = new DAProducto(_cadenaConexion);
            //se instancia el acceso a los datos
            try {
                DS = accesoDatos.ListarProductoDS(condicion, orden);
            } catch (Exception) {
                throw;
            }

            return DS;
        }// ListarClientes


        public List<entidadProducto> ListarProductos(string condicion = "") {
            List<entidadProducto> listaProducto;
            DAProducto accesoDatos = new DAProducto(_cadenaConexion);
            try {
                listaProducto = accesoDatos.ListarProductos(condicion);
            } catch (Exception) {
                throw;
            }

            return listaProducto;
        }//fin ListarClientes

        public entidadProducto ObtenerProducto(int id) {
            entidadProducto producto;
           DAProducto accesoDatos = new DAProducto(_cadenaConexion);
            try {
                producto = accesoDatos.ObtenerProducto(id);
            } catch (Exception) {
                throw;
            }
            return producto;
        }//ObtenerCliente


        //public int EliminarConSP(EntidadCliente cliente) 
        //{
        //    int resultado;
        //    DAClientes accesoDatos = new DAClientes(_cadenaConexion);
        //    try
        //    {
        //        // aqui antes de eliminar se podria verificar si es posible eliminar
        //         resultado = accesoDatos.EliminarRegistroConSP(cliente);
        //        _mensaje = accesoDatos.Mensaje;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return resultado;
        //}//EliminarConSP


        public int EliminarProducto(entidadProducto producto) {
            int resultado;
            DAProducto accesoDatos = new DAProducto(_cadenaConexion);
            try {
                resultado = accesoDatos.EliminarProducto(producto);
            } catch (Exception) {
                throw;
            }
            return resultado;
        }//EliminarCliente


        public int Modificar(entidadProducto producto) {
            int filasAfectadas = 0;
            DAProducto accesoDatos = new DAProducto(_cadenaConexion);
            try {
                filasAfectadas = accesoDatos.Modificar(producto);
            } catch (Exception) {
                throw;
            }
            return filasAfectadas;
        }// fin Modificar




    }// Fin class BLPRODUCTO
}//FIn namespace LogicaNegocio


