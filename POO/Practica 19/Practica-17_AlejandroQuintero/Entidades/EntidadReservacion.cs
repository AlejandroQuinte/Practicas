using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EntidadReservacion
    {
        //atributos
        private int idressevacion;
        private int idcliente;
        private DateTime? fingreso;
        private DateTime? fsalida;
        private int cantPersonas;
        private string tipoHab;
        private double precioNoche;
        private bool cancelado;
        private double totalpagar;
        private bool existe;

        // Constructor con parametros
        public EntidadReservacion(int idressevacion, int idcliente, DateTime? fingreso, DateTime? fsalida, int cantPersonas, string tipoHab, double precioNoche, bool cancelado, double totalpagar, bool existe)
        {
            this.idressevacion = idressevacion;
            this.idcliente = idcliente;
            this.fingreso = fingreso;
            this.fsalida = fsalida;
            this.cantPersonas = cantPersonas;
            this.tipoHab = tipoHab;
            this.precioNoche = precioNoche;
            this.cancelado = cancelado;
            this.totalpagar = totalpagar;
            this.existe = existe;
        }
        public EntidadReservacion()
        {
            this.idressevacion = 0;
            this.idcliente = 0;
            this.fingreso = Convert.ToDateTime("01/01/1900");
            this.fsalida = Convert.ToDateTime("01/01/1900");
            this.cantPersonas = 0;
            this.tipoHab = string.Empty;
            this.precioNoche = 0.0;
            this.cancelado = false;
            this.totalpagar = 0.0;
            this.existe = false;
        }
        //Metodos de acceso
        public int Idressevacion { get => idressevacion; set => idressevacion = value; }
        public int Idcliente { get => idcliente; set => idcliente = value; }
        public DateTime? Fingreso { get => fingreso; set => fingreso = value; }
        public DateTime? Fsalida { get => fsalida; set => fsalida = value; }
        public int CantPersonas { get => cantPersonas; set => cantPersonas = value; }
        public string TipoHab { get => tipoHab; set => tipoHab = value; }
        public double PrecioNoche { get => precioNoche; set => precioNoche = value; }
        public bool Cancelado { get => cancelado; set => cancelado = value; }
        public double Totalpagar { get => totalpagar; set => totalpagar = value; }
        public bool Existe { get => existe; set => existe = value; }
    }//class EntidadReservacion
}//namespace Entidades
