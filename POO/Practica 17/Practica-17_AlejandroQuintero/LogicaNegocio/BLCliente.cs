using System;
using System.Collections.Generic;
using System.Data;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class BLCliente
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
        public BLCliente(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        // métodos
        // método para llamar a insertar de la capaAcceso a Datos
        public int Insertar(EntidadCliente cliente) {
            int id_cliente = 0;
            DAClientes accesoDatos = new DAClientes(_cadenaConexion);
            try
            {
                id_cliente = accesoDatos.Insertar(cliente);
            }
            catch (Exception)
            {
                throw;
            }
            return id_cliente;
        }// Fin Class Insertar


        //llama al metodo listar clientes y trae los datos en un dataSet
        public DataSet ListarClientesDS(string condicion, string orden) {
            DataSet DS;
            DAClientes accesoDatos = new DAClientes(_cadenaConexion);
            //se instancia el acceso a los datos
            try {
                DS = accesoDatos.ListarClientesDS(condicion, orden);
            } catch (Exception) {
                throw;
            }

            return DS;
        }// ListarClientes


        public List<EntidadCliente> ListarClientes(string condicion = "")
        {
            List<EntidadCliente> listaClientes;
            DAClientes accesoDatos = new DAClientes(_cadenaConexion);
            try
            {
                listaClientes = accesoDatos.ListarClientes(condicion);
            }
            catch (Exception)
            {
                throw;
            }

            return listaClientes;
        }//fin ListarClientes

        public EntidadCliente ObtenerCliente(int id)
        {
            EntidadCliente cliente;
            DAClientes accesoDatos = new DAClientes(_cadenaConexion);
            try
            {
                cliente = accesoDatos.ObtenerCliente(id);
            }
            catch (Exception)
            {
                throw;
            }
            return cliente;
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


        public int EliminarCliente(EntidadCliente cliente)
        {
            int resultado;
            DAClientes accesoDatos = new DAClientes(_cadenaConexion);
            try
            {
                resultado = accesoDatos.EliminarCliente(cliente);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }//EliminarCliente

        
        public int Modificar(EntidadCliente cliente)
        {
            int filasAfectadas = 0;
            DAClientes accesoDatos = new DAClientes(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.Modificar(cliente);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }// fin Modificar




    }// Fin class BLCliente
}//FIn namespace LogicaNegocio


