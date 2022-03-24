using Capa3AccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
