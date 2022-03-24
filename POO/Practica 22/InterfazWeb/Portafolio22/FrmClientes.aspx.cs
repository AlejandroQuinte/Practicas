using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio22
{
    public partial class FrmClientes : System.Web.UI.Page
    {
        string mensajeScript = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }
        private void cargarClientes ()
        {
            //--------------------- Codigo LINQ -------------------

            BD_Portafolio22DataContext dataContext = new BD_Portafolio22DataContext();
            var consulta = from cliente in dataContext.CLIENTES
                           select cliente;
            //--------------------- Fin Codigo LINQ -------------------

            GrdClientes.DataSource = consulta;
            GrdClientes.DataBind();
        }

        protected void LnkEliminar_Command(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            BD_Portafolio22DataContext dataContext = new BD_Portafolio22DataContext();


            var delete = (from x in dataContext.CLIENTES
                          where x.ID_CLIENTE == int.Parse(id)
                          select x).ToList();
            foreach (var item in delete)
            {
                dataContext.CLIENTES.DeleteOnSubmit(item);
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



            cargarClientes();
        }

        protected void LnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["ID"] = e.CommandArgument.ToString();
            Session["NUM"] = 1;
            Response.Redirect("MantenimientoClientes.aspx");
        }
    }
}