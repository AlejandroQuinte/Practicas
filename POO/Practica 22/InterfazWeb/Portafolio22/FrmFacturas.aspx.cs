using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio22
{
    public partial class FrmFacturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarFacturas();
        }
        private void cargarFacturas()
        {
            //--------------------- Codigo LINQ -------------------

            BD_Portafolio22DataContext dataContext = new BD_Portafolio22DataContext();
            var consulta = from fact in dataContext.ENCABEZADO_FACTURA
                           select fact;
            //--------------------- Fin Codigo LINQ -------------------

            GrdFacturas.DataSource = consulta;
            GrdFacturas.DataBind();
        }
        private void cargarDetalle()
        {
            //--------------------- Codigo LINQ -------------------

            BD_Portafolio22DataContext dataContext = new BD_Portafolio22DataContext();
            var consulta = from dfact in dataContext.DETALLE_FACTURA
                           join product in dataContext.PRODUCTOS
                           on dfact.ID_PRODUCTO equals product.ID_PRODUCTO
                           where dfact.ID_FACTURA == Convert.ToInt32(Session["ID_FACTURA"].ToString())
                           select new {dfact.ID_FACTURA,product.DESCRIPCION,dfact.CANTIDAD };
            //--------------------- Fin Codigo LINQ -------------------

            GrdFacturas.DataSource = consulta;
            GrdFacturas.DataBind();
        }

        protected void LnkDesglose_Command(object sender, CommandEventArgs e)
        {
            Session["ID_FACTURA"] = e.CommandArgument.ToString();
            cargarDetalle();
        }

        protected void BtnAtras_Click(object sender, EventArgs e)
        {
            cargarFacturas();
        }
    }
}