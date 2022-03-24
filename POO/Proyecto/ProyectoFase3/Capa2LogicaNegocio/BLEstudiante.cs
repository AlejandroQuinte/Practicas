using Capa3AccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Capa2LogicaNegocio {
    public class BLEstudiante {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        //Constructor
        public BLEstudiante(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //Propiedades
        public string mensaje {
            get => _mensaje;
        }

        //MetodoFuncional INSERTAR
        public int Insertar(EntidadEstudiante estudiante) {
            int idProfesor = 0;

            DAEstudiante accesoDatos = new DAEstudiante(_cadenaConexion);//se crea una instancia para la 3er capa

            try {
                idProfesor = accesoDatos.Insertar(estudiante);
                _mensaje = accesoDatos.Mensaje;
            } catch (Exception) {
                throw;
            }

            return idProfesor;

        }//----------------------

        //Buscar idiomas
        public DataSet ListarEstudiante(string condicion = "", string orden = "") {
            DataSet DS;
            DAEstudiante accesoDatos = new DAEstudiante(_cadenaConexion);

            try {
                DS = accesoDatos.ListarEstudiante(condicion, orden);
            } catch (Exception) {
                throw;
            }
            return DS;

        }//-----------------------


        //Obtener un objeto idioma mediante un ID
        public EntidadEstudiante ObtenerEstudiante(int id) {
            EntidadEstudiante estudiante;
            DAEstudiante accesoDatos = new DAEstudiante(_cadenaConexion);

            try {
                estudiante = accesoDatos.ObtenerEstudiante(id);

            } catch (Exception) {
                throw;
            }

            return estudiante;
        }//-------------------------------


        //--Eliminar

        public int EliminarEstudiante(EntidadEstudiante estudiante) {
            int resultado;
            DAEstudiante accesoDatos = new DAEstudiante(_cadenaConexion);

            try {
                resultado = accesoDatos.EliminarEstudiante(estudiante);
            } catch (Exception) {
                throw;
            }
            return resultado;
        }//-------------------------------



        //--Modificar

        public int Modificar(EntidadEstudiante estudiante) {
            int filasAfectadas = 0;
            DAEstudiante accesoDatos = new DAEstudiante(_cadenaConexion);

            try {
                filasAfectadas = accesoDatos.Modificar(estudiante);
            } catch (Exception) {
                throw;
            }

            return filasAfectadas;

        }//--------------------------------------
    }
}
