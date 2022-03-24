using Capa3AccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Capa2LogicaNegocio {
    public class BLHorarioProfesor {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        //Constructor
        public BLHorarioProfesor(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //Propiedades
        public string mensaje {
            get => _mensaje;
        }

        //MetodoFuncional INSERTAR
        public int Insertar(EntidadHorarioProfesor horarioProfesor) {
            int idhorarioProfesor = 0;

            DAHorarioProfesor accesoDatos = new DAHorarioProfesor(_cadenaConexion);//se crea una instancia para la 3er capa

            try {
                idhorarioProfesor = accesoDatos.Insertar(horarioProfesor);
                _mensaje = accesoDatos.Mensaje;
            } catch (Exception) {
                throw;
            }

            return idhorarioProfesor;

        }//----------------------

        //Buscar idiomas
        public DataSet ListarHorarioProfesor(string condicion = "", string orden = "") {
            DataSet DS;
            DAHorarioProfesor accesoDatos = new DAHorarioProfesor(_cadenaConexion);

            try {
                DS = accesoDatos.ListarHorarioP(condicion, orden);
            } catch (Exception) {
                throw;
            }
            return DS;

        }//-----------------------


        //Obtener un objeto idioma mediante un ID
        public EntidadHorarioProfesor ObtenerHorarioProfesor(int id) {
            EntidadHorarioProfesor horarioProfesor;
            DAHorarioProfesor accesoDatos = new DAHorarioProfesor(_cadenaConexion);

            try {
                horarioProfesor = accesoDatos.ObtenerHorarioP(id);

            } catch (Exception) {
                throw;
            }

            return horarioProfesor;
        }//-------------------------------


        //--Eliminar

        public int EliminarHorarioProfesor(EntidadHorarioProfesor horarioProfesor) {
            int resultado;
            DAHorarioProfesor accesoDatos = new DAHorarioProfesor(_cadenaConexion);

            try {
                resultado = accesoDatos.EliminarHorarioP(horarioProfesor);
            } catch (Exception) {
                throw;
            }
            return resultado;
        }//-------------------------------



        //--Modificar

        public int Modificar(EntidadHorarioProfesor horarioProfesor) {
            int filasAfectadas = 0;
            DAHorarioProfesor accesoDatos = new DAHorarioProfesor(_cadenaConexion);

            try {
                filasAfectadas = accesoDatos.Modificar(horarioProfesor);
            } catch (Exception) {
                throw;
            }

            return filasAfectadas;

        }//--------------------------------------
    }
}
