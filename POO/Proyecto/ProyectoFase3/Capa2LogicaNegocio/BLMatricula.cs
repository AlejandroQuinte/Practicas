using Capa3AccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Capa2LogicaNegocio {
    public class BLMatricula {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        //Constructor
        public BLMatricula(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //Propiedades
        public string mensaje {
            get => _mensaje;
        }

        //MetodoFuncional INSERTAR
        public int Insertar(EntidadMatricula matricula) {
            int idMatricula = 0;

            DAMatricula accesoDatos = new DAMatricula(_cadenaConexion);//se crea una instancia para la 3er capa

            try {
                idMatricula = accesoDatos.Insertar(matricula);
                _mensaje = accesoDatos.Mensaje;
            } catch (Exception) {
                throw;
            }

            return idMatricula;

        }//----------------------

        //Buscar idiomas
        public DataSet ListarMatricula(string condicion = "", string orden = "") {
            DataSet DS;
            DAMatricula accesoDatos = new DAMatricula(_cadenaConexion);

            try {
                DS = accesoDatos.ListarMatricula(condicion, orden);
            } catch (Exception) {
                throw;
            }
            return DS;

        }//-----------------------


        //Obtener un objeto idioma mediante un ID
        public EntidadMatricula ObtenerMatricula(int id) {
            EntidadMatricula matricula;
            DAMatricula accesoDatos = new DAMatricula(_cadenaConexion);

            try {
                matricula = accesoDatos.ObtenerMatricula(id);

            } catch (Exception) {
                throw;
            }

            return matricula;
        }//-------------------------------


        //--Eliminar

        public int EliminarMatricula(EntidadMatricula matricula) {
            int resultado;
            DAMatricula accesoDatos = new DAMatricula(_cadenaConexion);

            try {
                resultado = accesoDatos.EliminarMatricula(matricula);
            } catch (Exception) {
                throw;
            }
            return resultado;
        }//-------------------------------



        //--Modificar

        public int Modificar(EntidadMatricula matricula) {
            int filasAfectadas = 0;
            DAMatricula accesoDatos = new DAMatricula(_cadenaConexion);

            try {
                filasAfectadas = accesoDatos.Modificar(matricula);
            } catch (Exception) {
                throw;
            }

            return filasAfectadas;

        }//--------------------------------------



        public string[] ObtenerCursoMatricula(string nombre) {
            string[] idCurso;
            DAMatricula accesoDatos = new DAMatricula(_cadenaConexion);

            try {
                idCurso = accesoDatos.ObtenerCursoMatricula(nombre);

            } catch (Exception) {
                throw;
            }

            return idCurso;
        }//-------------------------------






    }
}
