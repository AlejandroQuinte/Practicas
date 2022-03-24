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
    public partial class Matricula : System.Web.UI.Page {


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


        protected void btnBuscarProducto_Click(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(txtBuscarMatricula.Text)) {
                    string condicion = string.Format("ID_Matricula LIKE %{0}%", Convert.ToInt32(txtBuscarMatricula.Text));
                    //Que el nombre contenga lo que este escrito en el cuadro
                    CargarListaDataSet(condicion);
                }

            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e) {
            //removemos la session informacion que con ella guardamos la informacion de la pagina dado caso que 
            //hayamos dado en seleccionar a un estudiante

            Session.Remove("informacion");

            Session["id_de_matricula"] = e.CommandArgument.ToString();

            //redireccionamos el otro formulario ()

            Response.Redirect("MantenimientoMatricula.aspx");
        }

        protected void lnkEliminar_Command1(object sender, CommandEventArgs e) {
            //leemos el ID que envia el commandEvent
            int id = int.Parse(e.CommandArgument.ToString());
            BLMatricula logica = new BLMatricula(clsConfiguracion.getConnectionString);
            EntidadMatricula matricula;
            try {
                matricula = logica.ObtenerMatricula(id);
                if (matricula.Existe) {
                    if (logica.EliminarMatricula(matricula) > 0) {

                        mensajeScript = string.Format("Javascript:mostrarMensaje('Matricula eliminado correctamente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);

                        CargarListaDataSet();
                        txtBuscarMatricula.Text = "";
                    }
                }
            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void grdListaProducto_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            grdListaMatricula.PageIndex = e.NewPageIndex;
            CargarListaDataSet();
        }

        protected void btnAgregar_Click(object sender, EventArgs e) {
            //removemos la mayoria de session porque en ella guardamos informacion que afectaria a la hora de seleccionar
            //agregar la matricula

            Session.Remove("id_de_matricula");
            Session.Remove("informacion");
            Session.Remove("id_estudianteSeleccionado");
            Session.Remove("id_CursoSeleccionado");

            //redireccionamos al otro formulario
            Response.Redirect("MantenimientoMatricula.aspx");
        }


        //metodos
        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLMatricula logica = new BLMatricula(clsConfiguracion.getConnectionString);
            DataSet DS;


            try {
                DS = logica.ListarMatricula(condicion, orden);

                grdListaMatricula.DataSource = DS;
                grdListaMatricula.DataMember = DS.Tables[0].TableName;

                grdListaMatricula.DataBind();

            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }

        }//------------------------------



    }//-----------------
}