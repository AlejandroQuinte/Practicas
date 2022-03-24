using Capa3AccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Capa2LogicaNegocio {
    public class BLCurso {

        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        //Constructor
        public BLCurso(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //Propiedades
        public string mensaje {
            get => _mensaje;
        }

        //MetodoFuncional INSERTAR
        public string Insertar(EntidadCurso curso) {
            string idCurso = "";

            DACurso accesoDatos = new DACurso(_cadenaConexion);//se crea una instancia para la 3er capa

            try {
                idCurso = accesoDatos.Insertar(curso);
                _mensaje = accesoDatos.Mensaje;
            } catch (Exception) {
                throw;
            }

            return idCurso;

        }//----------------------

        //Buscar idiomas
        public DataSet ListarCursos(string condicion = "", string orden = "") {
            DataSet DS;
            DACurso accesoDatos = new DACurso(_cadenaConexion);

            try {
                DS = accesoDatos.ListarCurso(condicion, orden);
            } catch (Exception) {
                throw;
            }
            return DS;

        }//-----------------------


        //Obtener un objeto idioma mediante un ID
        public EntidadCurso ObtenerCurso(string id) {
            EntidadCurso curso;
            DACurso accesoDatos = new DACurso(_cadenaConexion);

            try {
                curso = accesoDatos.ObtenerCurso(id);

            } catch (Exception) {
                throw;
            }

            return curso;
        }//-------------------------------


        //--Eliminar

        public int EliminarCurso(EntidadCurso curso) {
            int resultado;
            DACurso accesoDatos = new DACurso(_cadenaConexion);

            try {
                resultado = accesoDatos.EliminarCurso(curso);
            } catch (Exception) {
                throw;
            }
            return resultado;
        }//-------------------------------



        //--Modificar

        public int Modificar(EntidadCurso curso) {
            int filasAfectadas = 0;
            DACurso accesoDatos = new DACurso(_cadenaConexion);

            try {
                filasAfectadas = accesoDatos.Modificar(curso);
            } catch (Exception) {
                throw;
            }

            return filasAfectadas;

        }//--------------------------------------





    }
}
