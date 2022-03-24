using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio22
{
    public partial class MantenimientoClientes : System.Web.UI.Page
    {
        string mensajeScript = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["NUM"])==1)
            {
                mostrar();
            }

            Session["NUM"] = 0;

        }

        private void mostrar()
        {
            BD_Portafolio22DataContext dataContext = new BD_Portafolio22DataContext();

            var consulta1 = from cliente in dataContext.CLIENTES
                            where cliente.ID_CLIENTE == Convert.ToInt32(Session["ID"].ToString())
                            select cliente;
            foreach (var item in consulta1)
            {
                TxtId.Enabled = false;
                TxtId.Text = item.ID_CLIENTE.ToString();
                TxtNombre.Text = item.NOMBRE;
                TxtTelefono.Text = item.TELEFONO;
                TxtEmail.Text = item.DIRECCION;

            }
        }

        protected void BtnGuardar_Command(object sender, CommandEventArgs e)
        {
            BD_Portafolio22DataContext dataContext = new BD_Portafolio22DataContext();

            var consulta = from cliente in dataContext.CLIENTES
                           where cliente.ID_CLIENTE == Convert.ToInt32(TxtId.Text)
                           select cliente;
            foreach (var item in consulta)
            {
                item.NOMBRE = TxtNombre.Text;
                item.TELEFONO = TxtTelefono.Text;
                item.DIRECCION = TxtEmail.Text;
            }
            dataContext.SubmitChanges();
            mensajeScript = string.Format("javascript:mostrarMensaje('Accion Competada con Exitp')");
            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmClientes.aspx");
        }
    }
}