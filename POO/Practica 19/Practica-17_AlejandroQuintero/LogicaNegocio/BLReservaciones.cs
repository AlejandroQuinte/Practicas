using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entidades;

namespace LogicaNegocio
{
    public class BLReservaciones
    {
        // Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedades
        public string Mensaje
        {
            get => _mensaje;
        }

        // Constructor
        public BLReservaciones(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        // llama al método para listar la reservaciones de un cliente
        public DataSet ListarReservacionesCliente(string condicion)
        {
            DataSet DS;
            DAReservaciones accesoDatos = new DAReservaciones(_cadenaConexion);
            //se instancia el acceso a los datos
            try
            {
                DS = accesoDatos.ListarReservacionesCliente(condicion);
            }
            catch (Exception)
            {
                throw;
            }

            return DS;
        }// ListarReservacionesCliente


        // método para llamar a insertar de la capaAcceso a Datos
        public int InsertarReservacionCliente(EntidadReservacion reservacion)
        {
            int id_reservacion = 0;
            DAReservaciones accesoDatos = new DAReservaciones(_cadenaConexion);
            try
            {
                id_reservacion = accesoDatos.InsertarReservacionCliente(reservacion);
            }
            catch (Exception)
            {
                throw;
            }
            return id_reservacion;
        }// Fin Class InsertarReservacionCliente


    }//class BLReservaciones
}//namespace LogicaNegocio
