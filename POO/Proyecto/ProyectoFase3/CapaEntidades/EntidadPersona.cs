using System;
using System.Collections.Generic;
using System.Text;


namespace CapaEntidades {
    public class EntidadPersona {

        #region atributos
        private int identificacion;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private string correo;
        private int telefono;
        private bool existe;

        #endregion atributos

        #region propiedades
        public int Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido1; set => apellido1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion propiedades


        #region constructor
        public EntidadPersona(int identificacion, string nombre, string apellido1, string apellido2, string correo, int telefono, bool existe) {
            this.identificacion = identificacion;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.correo = correo;
            this.telefono = telefono;
            this.existe = existe;
        }
        public EntidadPersona() {
            this.identificacion = 0;
            this.nombre = string.Empty;
            this.apellido1 = string.Empty;
            this.apellido2 = string.Empty;
            this.correo = string.Empty;
            this.telefono = 0;
            this.existe = false;
        }
        #endregion constructor
    }
}
