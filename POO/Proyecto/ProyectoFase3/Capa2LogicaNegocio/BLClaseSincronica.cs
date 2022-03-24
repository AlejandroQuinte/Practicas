using Capa3AccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Capa2LogicaNegocio {
    public class BLClaseSincronica {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        //Constructor
        public BLClaseSincronica(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //Propiedades
        public string mensaje {
            get => _mensaje;
        }

        //MetodoFuncional INSERTAR
        public int Insertar(EntidadClaseSincronica claseSinc) {
            int retorno = 0;

            DAClaseSincronica accesoDatos = new DAClaseSincronica(_cadenaConexion);//se crea una instancia para la 3er capa

            try {
                retorno = accesoDatos.Insertar(claseSinc);
                _mensaje = accesoDatos.Mensaje;
            } catch (Exception) {
                throw;
            }

            return retorno;

        }//----------------------

        //Buscar idiomas
        public DataSet ListarClaseSincronica(string condicion = "", string orden = "") {
            DataSet DS;
            DAClaseSincronica accesoDatos = new DAClaseSincronica(_cadenaConexion);//se crea una instancia para la 3er capa

            try {
                DS = accesoDatos.ListarMatricula(condicion, orden);
            } catch (Exception) {
                throw;
            }
            return DS;

        }//-----------------------


        //Obtener un objeto idioma mediante un ID
        public EntidadClaseSincronica ObtenerClaseSincronica(int id) {
            EntidadClaseSincronica claseSinc;
            DAClaseSincronica accesoDatos = new DAClaseSincronica(_cadenaConexion);

            try {
                claseSinc = accesoDatos.ObtenerClaseSincronica(id);

            } catch (Exception) {
                throw;
            }

            return claseSinc;
        }//-------------------------------



        //Obtener un objeto idioma mediante un ID
        public string[] ObtenerEstudianteClaseSincronica(int id) {
            string[] EstudianteClaseSinc = new string[4];
            DAClaseSincronica accesoDatos = new DAClaseSincronica(_cadenaConexion);

            try {
                EstudianteClaseSinc = accesoDatos.ObtenerEstudianteClaseSincronica(id);

            } catch (Exception) {
                throw;
            }

            return EstudianteClaseSinc;
        }//-------------------------------


        //--Eliminar

        public int EliminarClaseSincronica(EntidadClaseSincronica claseSincronica) {
            int resultado;
            DAClaseSincronica accesoDatos = new DAClaseSincronica(_cadenaConexion);

            try {
                resultado = accesoDatos.EliminarClaseSincronica(claseSincronica);
            } catch (Exception) {
                throw;
            }
            return resultado;
        }//-------------------------------



        //--Modificar

        public int Modificar(EntidadClaseSincronica claseSincronica) {
            int filasAfectadas = 0;
            DAClaseSincronica accesoDatos = new DAClaseSincronica(_cadenaConexion);

            try {
                filasAfectadas = accesoDatos.Modificar(claseSincronica);
            } catch (Exception) {
                throw;
            }

            return filasAfectadas;

        }//--------------------------------------
    }
}
