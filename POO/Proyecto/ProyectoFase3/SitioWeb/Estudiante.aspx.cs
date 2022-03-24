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
using System.Collections;

namespace SitioWeb {
    public partial class Estudiante : System.Web.UI.Page {
        string mensajeScript;
        protected void Page_Load(object sender, EventArgs e) {
            try {

                if (!IsPostBack) {
                    CargarListaDataSet();
                    //si session tiene algo significa que viene desde mantenimiento matricula que lo quiere seleccionar
                    //ponemos los datos como visibles
                    if (Session["visible"] != null){
                        btnVolver.Visible = true;
                        grdLista.Columns[2].Visible = true; 
                    }else{
                        grdLista.Columns[2].Visible = false;
                        btnVolver.Visible = false;
                    }
                        
                    
                }
                
            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(txtBuscarEstudiante.Text)) {
                    string condicion = string.Format("Nombre LIKE '%{0}%'", txtBuscarEstudiante.Text);
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
            Session.Remove("id_de_estudiante");

            //redireccionamos al otro formulario
            Response.Redirect("MantenimientoEstudiante.aspx");
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e) {
            //removemos id curso porque este lo traiamos desde modificar, si se intenta agregar nuevo, se borra el id_de_estudiante 
            //para que no afecte ningun dato
            Session["id_de_estudiante"] = e.CommandArgument.ToString();

            //redireccionamos al otro formulario
            Response.Redirect("MantenimientoEstudiante.aspx");
        }

        protected void lnkEliminar_Command1(object sender, CommandEventArgs e) {
            //leemos el ID que envia el commandEvent
            int id = int.Parse(e.CommandArgument.ToString());
            BLEstudiante logica = new BLEstudiante(clsConfiguracion.getConnectionString);
            EntidadEstudiante estudiante;
            try {
                estudiante = logica.ObtenerEstudiante(id);
                if (estudiante.Existe) {
                    if (logica.EliminarEstudiante(estudiante) > 0) {

                        mensajeScript = string.Format("Javascript:mostrarMensaje('Estudiante eliminado correctamente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);

                        CargarListaDataSet();
                        txtBuscarEstudiante.Text = "";
                    }
                }
            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void grdListaProducto_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            grdLista.PageIndex = e.NewPageIndex;
            CargarListaDataSet();
        }




        //Metodos

        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLEstudiante logica = new BLEstudiante(clsConfiguracion.getConnectionString);
            DataSet DS;


            try {
                DS = logica.ListarEstudiante(condicion, orden);

                grdLista.DataSource = DS;
                grdLista.DataMember = DS.Tables[0].TableName;

                grdLista.DataBind();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------

        protected void btnVolver_Click(object sender, EventArgs e) {
            //removemos la session visible para que el boton de volver y el de seleccionar no aparezcan
            Session.Remove("visible");
            //redireccionamos hacia el mantenimiento matricula porque ahi estamos haciendo la seleccion
            Response.Redirect("MantenimientoMatricula.aspx");
        }

        protected void lnkSeleccionar_Command(object sender, CommandEventArgs e) {
            //si seleccionamos algun dato, obtenemos su ID y lo guardamos en una session para utilizarlo despues
            Session["id_estudianteSeleccionado"] = int.Parse(e.CommandArgument.ToString());
            Session.Remove("visible");

            Response.Redirect("MantenimientoMatricula.aspx");
        }
    }//---------------
}