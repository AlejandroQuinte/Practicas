using System;

namespace Entidades
{
    public class EntidadCliente
    {
        #region atributos
        
        private int id_cliente;
        private string nombre;
        private string telefono;
        private string direccion;
        private bool existe;



        #endregion

        #region Propiedades

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public bool Existe { get => existe; set => existe = value; }

        public int getId_cliente() { return id_cliente; }
        public void setId_cliente(int id_cliente) { this.id_cliente = id_cliente; }
        public string getNombre() { return nombre; }
        public void setNombre(string nombre) { this.nombre = nombre; }
        public string getTelefono() { return telefono; }
        public void setTelefono(string telefono) { this.telefono = telefono; }
        public string getDireccion() { return direccion; }
        public void setDireccion(string direccion) { this.direccion = direccion; }
        public bool getExiste() { return existe; }
        public void setExiste(bool existe) { this.existe = existe; }
        #endregion

        #region Constructores

        public EntidadCliente()
        {
            this.id_cliente = 0;
            this.nombre = string.Empty;
            this.telefono = string.Empty;
            this.direccion = string.Empty;
            this.existe = false;
        }
        public EntidadCliente(int id_cliente, string nombre, string telefono, string direccion, bool existe)
        {
            this.id_cliente = id_cliente;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            this.existe = existe;
        }

        #endregion

        #region Metodos 
        public override string ToString()
        {
            return string.Format("{0} - {1}", id_cliente, nombre);
        }

        #endregion


    }//EntidadClientes
}//Entidades
