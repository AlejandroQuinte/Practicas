using System;

namespace Entidades {
    public class entidadProducto {
        #region atributos

        private int idProducto;
        private string descripcion;
        private float precioCompra;
        private float precioVenta;
        private string gravado;
        private bool existe;



        #endregion

        #region Propiedades
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public float PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public float PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public string Gravado { get => gravado; set => gravado = value; }
        public bool Existe { get => existe; set => existe = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }

        #endregion

        #region Constructores

        public entidadProducto() {
            this.IdProducto = 0;
            this.descripcion = string.Empty;
            this.precioCompra = 0;
            this.precioVenta = 0;
            this.gravado = string.Empty;
            this.Existe = false;
        }
        public entidadProducto(int idProducto, string descripcion, float precioCompra, float precioVenta, string gravado, bool existe) {
            this.IdProducto = idProducto;
            this.descripcion = descripcion;
            this.precioCompra = precioCompra;
            this.precioVenta = precioVenta;
            this.gravado = gravado;
            this.Existe = existe;
        }






        #endregion

        #region Metodos 
        public override string ToString() {
            return string.Format("{0} - {1}", IdProducto, descripcion);
        }

        #endregion


    }//EntidadClientes
}//Entidades
