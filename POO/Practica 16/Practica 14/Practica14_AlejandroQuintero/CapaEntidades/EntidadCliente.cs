using System;

namespace CapaEntidades {
    public class EntidadCliente {

        //Atributos
        #region atributos
        private int id_cliente;
        private string nombre;
        private string telefono;
        private string direccion;
        private bool existe;
        #endregion atributos

        #region propiedades
        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public bool Existe { get => existe; set => existe = value; }

        public int getIdCliente() {
            return id_cliente;
        }

        public string getNombre() {
            return nombre;
        }
        public string getTelefono() {
            return telefono;
        }
        public string getDireccion() {
            return direccion;
        }
        public bool getExiste() {
            return existe;
        }
        //sets
        public void setIdCliente(int id_cliente) {
            this.id_cliente = id_cliente;
        }
        public void setNombre(string nombre) {
            this.nombre = nombre;
        }
        public void setTelefono(string telefono) {
            this.telefono = telefono;
        }
        public void setDireccion(string direccion) {
            this.direccion = direccion;
        }
        public void setExiste(bool existe) {
            this.existe = existe;
        }

        #endregion propiedades

        #region constructor
        public EntidadCliente(int id_cliente, string nombre, string telefono, string direccion, bool existe) {
            this.id_cliente = id_cliente;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            this.existe = existe;
        }

        public EntidadCliente() {
            this.id_cliente = 0;
            this.nombre = string.Empty;
            this.telefono = string.Empty;
            this.direccion = string.Empty;
            this.existe = false;
        }
        #endregion constructor

        #region Metodos Funcionales
        public override string ToString() // override es SOBREESCRIBIR
        {
            return string.Format("{0} - {1}", id_cliente, nombre);
        }
        #endregion Metodos Funcionales
    }
}
