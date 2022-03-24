using System;
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


    }
}
