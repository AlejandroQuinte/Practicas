using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio22
{
    public partial class MantenimientoProductos : System.Web.UI.Page
    {
        string mensajeScript = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["NUM"]) == 1)
            {
                mostrar();
            }

            Session["NUM"] = 0;
        }

        private void mostrar()
        {
            BD_Portafolio22DataContext dataContext = new BD_Portafolio22DataContext();

            var consulta1 = from product in dataContext.PRODUCTOS
                            where product.ID_PRODUCTO == Convert.ToInt32(Session["ID"].ToString())
                            select product;
            foreach (var item in consulta1)
            {
                TxtId.Enabled = false;
                TxtId.Text = item.ID_PRODUCTO.ToString();
                TxtDescripcion.Text = item.DESCRIPCION;
                TxtCompra.Text = item.PRECIOCOMPRA.ToString();
                TxtVenta.Text = item.PRECIOVENTA.ToString();

            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            BD_Portafolio22DataContext dataContext = new BD_Portafolio22DataContext();

            var consulta = from prodct in dataContext.PRODUCTOS
                           where prodct.ID_PRODUCTO == Convert.ToInt32(TxtId.Text)
                           select prodct;
            foreach (var item in consulta)
            {
                item.DESCRIPCION = TxtDescripcion.Text;
                item.PRECIOCOMPRA = Convert.ToDecimal(TxtCompra.Text);
                item.PRECIOVENTA = Convert.ToDecimal(TxtVenta.Text);
            }
            dataContext.SubmitChanges();
            mensajeScript = string.Format("javascript:mostrarMensaje('Accion Competada con Exito')");
            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmProductos.aspx");
        }
    }
}