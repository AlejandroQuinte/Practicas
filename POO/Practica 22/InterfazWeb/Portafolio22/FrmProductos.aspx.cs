using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio22
{
    public partial class FrmProductos : System.Web.UI.Page
    {
        string mensajeScript="";
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarFacturas();
        }
        private void cargarFacturas()
        {
            //--------------------- Codigo LINQ -------------------

            BD_Portafolio22DataContext dataContext = new BD_Portafolio22DataContext();
            var consulta = from product in dataContext.PRODUCTOS
                           select product;
            //--------------------- Fin Codigo LINQ -------------------

            GrdProductos.DataSource = consulta;
            GrdProductos.DataBind();
        }

        protected void LnkEliminar_Command(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            BD_Portafolio22DataContext dataContext = new BD_Portafolio22DataContext();


            var delete = (from x in dataContext.PRODUCTOS
                          where x.ID_PRODUCTO == int.Parse(id)
                          select x).ToList();
            foreach (var item in delete)
            {
                dataContext.PRODUCTOS.DeleteOnSubmit(item);
            }
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('No se pudo completar la accion')");
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);


            }
            mensajeScript = string.Format("javascript:mostrarMensaje('Accion completada con exito')");
            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);



            cargarFacturas();
        }

        protected void LnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["ID"] = e.CommandArgument.ToString();
            Session["NUM"] = 1;
            Response.Redirect("MantenimientoProductos.aspx");
        }
    }
}