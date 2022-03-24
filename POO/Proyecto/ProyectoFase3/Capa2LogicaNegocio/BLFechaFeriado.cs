using Capa3AccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Capa2LogicaNegocio {
    public class BLFechaFeriado {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        //Constructor
        public BLFechaFeriado(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //Propiedades
        public string mensaje {
            get => _mensaje;
        }

        //MetodoFuncional INSERTAR
        public string Insertar(EntidadFechaFeriado fechaFeriado) {
            string idProfesor = "";

            DAFechaFeriado accesoDatos = new DAFechaFeriado(_cadenaConexion);//se crea una instancia para la 3er capa

            try {
                idProfesor = accesoDatos.Insertar(fechaFeriado);
                _mensaje = accesoDatos.Mensaje;
            } catch (Exception) {
                throw;
            }

            return idProfesor;

        }//----------------------

        //Buscar idiomas
        public DataSet ListarFechaFeriado(string condicion = "", string orden = "") {
            DataSet DS;
            DAFechaFeriado accesoDatos = new DAFechaFeriado(_cadenaConexion);//se crea una instancia para la 3er capa

            try {
                DS = accesoDatos.ListarFechaFeriado(condicion, orden);
            } catch (Exception) {
                throw;
            }
            return DS;

        }//-----------------------


        //Obtener un objeto idioma mediante un ID
        public EntidadFechaFeriado ObtenerFechaFeriado(string id) {
            EntidadFechaFeriado fechaFeriado;
            DAFechaFeriado accesoDatos = new DAFechaFeriado(_cadenaConexion);

            try {
                fechaFeriado = accesoDatos.ObtenerFechaFeriado(id);

            } catch (Exception) {
                throw;
            }

            return fechaFeriado;
        }//-------------------------------


        //--Eliminar

        public int EliminarFechaFeriado(EntidadFechaFeriado fechaFeriado) {
            int resultado;
            DAFechaFeriado accesoDatos = new DAFechaFeriado(_cadenaConexion);

            try {
                resultado = accesoDatos.EliminarFechaFeriado(fechaFeriado);
            } catch (Exception) {
                throw;
            }
            return resultado;
        }//-------------------------------



        //--Modificar

        public int Modificar(EntidadFechaFeriado fechaFeriado) {
            int filasAfectadas = 0;
            DAFechaFeriado accesoDatos = new DAFechaFeriado(_cadenaConexion);

            try {
                filasAfectadas = accesoDatos.Modificar(fechaFeriado);
            } catch (Exception) {
                throw;
            }

            return filasAfectadas;

        }//--------------------------------------
    }
}
