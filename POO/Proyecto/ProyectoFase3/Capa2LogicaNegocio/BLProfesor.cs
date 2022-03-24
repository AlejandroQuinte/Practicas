using Capa3AccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Capa2LogicaNegocio {
    public class BLProfesor {


        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        //Constructor
        public BLProfesor(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //Propiedades
        public string mensaje {
            get => _mensaje;
        }

        //MetodoFuncional INSERTAR
        public int Insertar(EntidadProfesor profesor) {
            int idProfesor = 0;

            DAProfesor accesoDatos = new DAProfesor(_cadenaConexion);//se crea una instancia para la 3er capa

            try {
                idProfesor = accesoDatos.Insertar(profesor);
                _mensaje = accesoDatos.Mensaje;
            } catch (Exception) {
                throw;
            }

            return idProfesor;

        }//----------------------

        //Buscar idiomas
        public DataSet ListarProfesor(string condicion = "", string orden = "") {
            DataSet DS;
            DAProfesor accesoDatos = new DAProfesor(_cadenaConexion);

            try {
                DS = accesoDatos.ListarProfesor(condicion, orden);
            } catch (Exception) {
                throw;
            }
            return DS;

        }//-----------------------


        //Obtener un objeto idioma mediante un ID
        public EntidadProfesor ObtenerProfesor(int id) {
            EntidadProfesor profesor;
            DAProfesor accesoDatos = new DAProfesor(_cadenaConexion);

            try {
                profesor = accesoDatos.ObtenerProfesor(id);

            } catch (Exception) {
                throw;
            }

            return profesor;
        }//-------------------------------


        //--Eliminar

        public int EliminarProfesor(EntidadProfesor profesor) {
            int resultado;
            DAProfesor accesoDatos = new DAProfesor(_cadenaConexion);

            try {
                resultado = accesoDatos.EliminarProfesor(profesor);
            } catch (Exception) {
                throw;
            }
            return resultado;
        }//-------------------------------



        //--Modificar

        public int Modificar(EntidadProfesor profesor) {
            int filasAfectadas = 0;
            DAProfesor accesoDatos = new DAProfesor(_cadenaConexion);

            try {
                filasAfectadas = accesoDatos.Modificar(profesor);
            } catch (Exception) {
                throw;
            }

            return filasAfectadas;

        }//--------------------------------------


    }
}
