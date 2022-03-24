using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades {
    public class EntidadProducto {

        #region atributos
        private int id_producto;
        private string descripcion;
        private float precioCompra;
        private float precioVenta;
        private string gravado;
        private bool existe;
        #endregion atributos


        #region propiedades
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public float PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public float PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public string Gravado { get => gravado; set => gravado = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion propiedades


        #region constructor
        public EntidadProducto(int id_producto, string descripcion, float precioCompra, float precioVenta, string gravado, bool existe) {
            this.id_producto = id_producto;
            this.descripcion = descripcion;
            this.precioCompra = precioCompra;
            this.precioVenta = precioVenta;
            this.gravado = gravado;
            this.existe = existe;
        }

        public EntidadProducto() {
            this.id_producto = 0;
            this.descripcion = string.Empty;
            this.precioCompra = 0;
            this.precioVenta = 0;
            this.gravado = string.Empty;
            this.existe = false;
        }
        #endregion constructor



        #region Metodos Funcionales
        public override string ToString() // override es SOBREESCRIBIR
        {
            return string.Format("{0} - {1}", id_producto, descripcion);
        }
        #endregion Metodos Funcionales

    }
}
