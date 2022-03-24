using Capa3AccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Capa2LogicaNegocio {
    public class BLCerticacion {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        //Constructor
        public BLCerticacion(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //Propiedades
        public string mensaje {
            get => _mensaje;
        }

        //MetodoFuncional INSERTAR
        public string Insertar(EntidadCertificacion certificacion) {
            string idProfesor = "";

            DACertificacion accesoDatos = new DACertificacion(_cadenaConexion);//se crea una instancia para la 3er capa

            try {
                idProfesor = accesoDatos.Insertar(certificacion);
                _mensaje = accesoDatos.Mensaje;
            } catch (Exception) {
                throw;
            }

            return idProfesor;

        }//----------------------

        //Buscar idiomas
        public DataSet ListarCertificacion(string condicion = "", string orden = "") {
            DataSet DS;
            DACertificacion accesoDatos = new DACertificacion(_cadenaConexion);

            try {
                DS = accesoDatos.ListarMatricula(condicion, orden);
            } catch (Exception) {
                throw;
            }
            return DS;

        }//-----------------------


        //Obtener un objeto idioma mediante un ID
        public EntidadCertificacion ObtenerCertificacion(string id) {
            EntidadCertificacion profesor;
            DACertificacion accesoDatos = new DACertificacion(_cadenaConexion);

            try {
                profesor = accesoDatos.ObtenerCertificacion(id);

            } catch (Exception) {
                throw;
            }

            return profesor;
        }//-------------------------------


        //--Eliminar

        public int EliminarCertificacion(EntidadCertificacion certificacion) {
            int resultado;
            DACertificacion accesoDatos = new DACertificacion(_cadenaConexion);

            try {
                resultado = accesoDatos.EliminarCertificado(certificacion);
            } catch (Exception) {
                throw;
            }
            return resultado;
        }//-------------------------------



        //--Modificar

        public int Modificar(EntidadCertificacion certificacion) {
            int filasAfectadas = 0;
            DACertificacion accesoDatos = new DACertificacion(_cadenaConexion);

            try {
                filasAfectadas = accesoDatos.Modificar(certificacion);
            } catch (Exception) {
                throw;
            }

            return filasAfectadas;

        }//--------------------------------------
    }
}
