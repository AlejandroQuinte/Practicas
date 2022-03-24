using Capa2LogicaNegocio;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitioWeb {
    public partial class ClaseSincronica : System.Web.UI.Page {
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

        protected void btnBuscarclase_Click(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(txtBuscarClaseSincronica.Text)) {
                    string condicion = string.Format("ID_ClaseSincronica LIKE '%{0}%'", txtBuscarClaseSincronica.Text);
                    //Que el nombre contenga lo que este escrito en el cuadro
                    CargarListaDataSet(condicion);
                }
                else {
                    CargarListaDataSet();
                }

            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e) {
            Session.Remove("id_de_claseS");

            //redireccionamos al otro formulario
            Response.Redirect("MantenimientoClaseSincronica.aspx");
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e) {
            //removemos id curso porque este lo traiamos desde modificar, si se intenta agregar nuevo, se borra el id_de_estudiante 
            //para que no afecte ningun dato
            Session["id_de_claseS"] = e.CommandArgument.ToString();

            //redireccionamos al otro formulario
            Response.Redirect("MantenimientoClaseSincronica.aspx");
        }

        protected void lnkEliminar_Command1(object sender, CommandEventArgs e) {
            //leemos el ID que envia el commandEvent
            int id = int.Parse(e.CommandArgument.ToString());
            BLClaseSincronica logica = new BLClaseSincronica(clsConfiguracion.getConnectionString);
            EntidadClaseSincronica claseSincronica;
            try {
                claseSincronica = logica.ObtenerClaseSincronica(id);
                if (claseSincronica.Existe) {
                    if (logica.EliminarClaseSincronica(claseSincronica) > 0) {

                        mensajeScript = string.Format("Javascript:mostrarMensaje('Estudiante eliminado correctamente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);

                        CargarListaDataSet();
                        txtBuscarClaseSincronica.Text = "";
                    }
                }
            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        

        protected void grdListaClaseS_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            grdListaClaseS.PageIndex = e.NewPageIndex;
            CargarListaDataSet();
        }






        //metodos
        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLClaseSincronica logica = new BLClaseSincronica(clsConfiguracion.getConnectionString);
            DataSet DS;


            try {
                DS = logica.ListarClaseSincronica(condicion, orden);

                grdListaClaseS.DataSource = DS;
                grdListaClaseS.DataMember = DS.Tables[0].TableName;

                grdListaClaseS.DataBind();
            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }

        }//------------------------------





    }//--**-*-
}