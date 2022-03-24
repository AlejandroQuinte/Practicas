using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa2LogicaNegocio;
using CapaEntidades;
using System.Data;
using System.Windows.Forms;

namespace SitioWeb {
    public partial class Profesor : System.Web.UI.Page {
        string mensajeScript;
        protected void Page_Load(object sender, EventArgs e) {
            try {
                if (!IsPostBack) {
                    CargarListaDataSet();
                }
            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e) {

            Session["id_de_profesor"] = e.CommandArgument.ToString();

            //redireccionamos el otro formulario ()

            Response.Redirect("MantenimientoProfesor.aspx");
        }

        protected void lnkEliminar_Command1(object sender, CommandEventArgs e) {
            //leemos el ID que envia el commandEvent
            int id = int.Parse(e.CommandArgument.ToString());
            BLProfesor logica = new BLProfesor(clsConfiguracion.getConnectionString);
            EntidadProfesor profesor;
            try {
                profesor = logica.ObtenerProfesor(id);
                if (profesor.Existe) {
                    if (logica.EliminarProfesor(profesor) > 0) {

                        mensajeScript = string.Format("Javascript:mostrarMensaje('Profesor eliminado correctamente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);

                        CargarListaDataSet();
                        txtBuscar.Text = "";
                    }
                }
            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(txtBuscar.Text)) {
                    string condicion = string.Format("Nombre LIKE '%{0}%'", txtBuscar.Text);
                    //Que el nombre contenga lo que este escrito en el cuadro
                    CargarListaDataSet(condicion);
                }else{
                    CargarListaDataSet();
                }

            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e) {
            Session.Remove("id_de_profesor");

            //redireccionamos al otro formulario
            Response.Redirect("MantenimientoProfesor.aspx");
        }


        protected void grdListaProducto_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            grdLista.PageIndex = e.NewPageIndex;
            CargarListaDataSet();
        }






        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLProfesor logica = new BLProfesor(clsConfiguracion.getConnectionString);
            DataSet DS;


            try {
                DS = logica.ListarProfesor(condicion, orden);

                grdLista.DataSource = DS;
                grdLista.DataMember = DS.Tables[0].TableName;

                grdLista.DataBind();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------


    }//--*---
}