using Capa3AccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Capa2LogicaNegocio {
    public class BLIdioma {

        //Atributos
        private string _cadenaConexion;
        private string _mensaje;
    
        //Constructor
        public BLIdioma(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            _mensaje = "";
        }

        //Propiedades
        public string mensaje{
            get => _mensaje;
        }

        //MetodoFuncional
        public string Insertar(EntidadIdioma idioma){
            string idIdioma = "";

            DAIdioma accesoDatos = new DAIdioma(_cadenaConexion);//se crea una instancia para la 3er capa

            try{
                idIdioma = accesoDatos.Insertar(idioma);
                _mensaje = accesoDatos.Mensaje;
            }catch(Exception){
                throw;
            }

            return idIdioma;

        }//----------------------

        //Buscar idiomas
        public DataSet ListarIdiomas(string condicion="",string orden = ""){
            DataSet DS;
            DAIdioma accesoDatos = new DAIdioma(_cadenaConexion);

            try{
                DS = accesoDatos.ListarIdioma(condicion, orden);
            }catch(Exception){
                throw;
            }
            return DS;

        }//-----------------------


        //Obtener un objeto idioma mediante un ID
        public EntidadIdioma ObtenerIdioma(string id){
            EntidadIdioma idioma;
            DAIdioma accesoDatos = new DAIdioma(_cadenaConexion);

            try{
                idioma = accesoDatos.ObtenerIdioma(id);   

            }catch(Exception){
                throw;
            }

            return idioma;
        }//-------------------------------


        //--Eliminar

        public int EliminarIdioma(EntidadIdioma idioma){
            int resultado;
            DAIdioma accesoDatos = new DAIdioma(_cadenaConexion);

            try{
                resultado = accesoDatos.EliminarIdioma(idioma);
            }catch(Exception){
                throw;
            }
            return resultado;
        }//-------------------------------



        //--Modificar

        public int Modificar(EntidadIdioma idioma){
            int filasAfectadas = 0;
            DAIdioma accesoDatos = new DAIdioma(_cadenaConexion);

            try {
                filasAfectadas = accesoDatos.Modificar(idioma);
            } catch (Exception){
                throw;
            }

            return filasAfectadas;

        }//--------------------------------------
        















    }
}
