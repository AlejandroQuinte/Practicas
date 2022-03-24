using Capa3AccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Capa2LogicaNegocio {
    public class BLNotaMateria {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        //Constructor
        public BLNotaMateria(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //Propiedades
        public string mensaje {
            get => _mensaje;
        }

        //MetodoFuncional INSERTAR
        public int Insertar(EntidadNotaMateria notaMateria) {
            int idProfesor = 0;

            DANotaMateria accesoDatos = new DANotaMateria(_cadenaConexion);//se crea una instancia para la 3er capa

            try {
                idProfesor = accesoDatos.Insertar(notaMateria);
                _mensaje = accesoDatos.Mensaje;
            } catch (Exception) {
                throw;
            }

            return idProfesor;

        }//----------------------

        //Buscar idiomas
        public DataSet ListarMateria(string condicion = "", string orden = "") {
            DataSet DS;
            DANotaMateria accesoDatos = new DANotaMateria(_cadenaConexion);

            try {
                DS = accesoDatos.ListarNotas(condicion, orden);
            } catch (Exception) {
                throw;
            }
            return DS;

        }//-----------------------


        //Obtener un objeto idioma mediante un ID
        public EntidadNotaMateria ObtenerMateria(int id) {
            EntidadNotaMateria notaMateria;
            DANotaMateria accesoDatos = new DANotaMateria(_cadenaConexion);

            try {
                notaMateria = accesoDatos.ObtenerNotas(id);

            } catch (Exception) {
                throw;
            }

            return notaMateria;
        }//-------------------------------


        //--Eliminar

        public int EliminarMateria(EntidadNotaMateria notaMateria) {
            int resultado;
            DANotaMateria accesoDatos = new DANotaMateria(_cadenaConexion);

            try {
                resultado = accesoDatos.EliminarNotas(notaMateria);
            } catch (Exception) {
                throw;
            }
            return resultado;
        }//-------------------------------



        //--Modificar

        public int Modificar(EntidadNotaMateria notaMateria) {
            int filasAfectadas = 0;
            DANotaMateria accesoDatos = new DANotaMateria(_cadenaConexion);

            try {
                filasAfectadas = accesoDatos.Modificar(notaMateria);
            } catch (Exception) {
                throw;
            }

            return filasAfectadas;

        }//--------------------------------------
    }
}
