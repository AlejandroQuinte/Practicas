using System;
using System.Collections.Generic;
using Capa3AccesoDatos;
using CapaEntidades;

namespace Capa2LogicaNegocio {
    public class BLCliente {
        // Atributos
        private string _cadenaConexion;
        private string _mensaje;

        //constructor
        public BLCliente(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            this._mensaje = "";
        }

        //propiedades
        public string Mensaje {
            get => _mensaje;
        }

        public int Insertar(EntidadCliente cliente){
            int id_cliente = 0;
            DACliente accesoDatos = new DACliente(_cadenaConexion); //se crea una instancia para la 3er
            try{
                id_cliente = accesoDatos.Insertar(cliente);
            }catch(Exception ex){
                throw;
            }
            return id_cliente;
        }

        public List<EntidadCliente> ListarClientes(string condicion = "") {
            List<EntidadCliente> listaClientes;
            DACliente accesoDatos = new DACliente(_cadenaConexion);
            try {
                listaClientes = accesoDatos.ListarClientes(condicion);
            } catch (Exception) {
                throw;
            }
            return listaClientes;
        }
        


        public EntidadCliente ObtenerCliente(int id){
            EntidadCliente cliente;
            DACliente accesoDatos = new DACliente(_cadenaConexion);
            try{
                cliente = accesoDatos.ObtenerCliente(id);
            }catch (Exception){
                throw;
            }
            return cliente;

        }//-------------------------


        public int EliminarCliente(EntidadCliente cliente) {
            int resultado;
            DACliente accesoDatos = new DACliente(_cadenaConexion);
            try {
                resultado = accesoDatos.EliminarCliente(cliente);

            } catch (Exception) {
                throw;
            }
            return resultado;

        }//--------------------------------



        public int Modificar(EntidadCliente cliente) {
            int filasAfectadas = 0;
            DACliente accesoDatos = new DACliente(_cadenaConexion);
            try {
                filasAfectadas = accesoDatos.Modificar(cliente);
            } catch (Exception) {
                throw;
            }
            return filasAfectadas;
        }









    }
}
