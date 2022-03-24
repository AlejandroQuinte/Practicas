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
    public partial class Curso : System.Web.UI.Page {
        string mensajeScript;
        protected void Page_Load(object sender, EventArgs e) {
            try {
                if (!IsPostBack) {
                    CargarListaDataSet();
                    //si session tiene algo significa que viene desde mantenimiento matricula que lo quiere seleccionar
                    //ponemos los datos como visibles
                    if (Session["visible"] != null) {
                        btnVolver.Visible = true;
                        grdLista.Columns[2].Visible = true;
                    }
                    else {                   
                        grdLista.Columns[2].Visible = false;
                        btnVolver.Visible = false;
                    }
                }
            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e) {
            //si se modifica enviamos el id del que queremos modificar o lo guardamos en un session para luego utilizarlo
            Session["id_de_curso"] = e.CommandArgument.ToString();

            //redireccionamos el otro formulario ()

            Response.Redirect("MantenimientoCurso.aspx");
        }

        protected void lnkEliminar_Command1(object sender, CommandEventArgs e) {
            //leemos el ID que envia el commandEvent
            string id = e.CommandArgument.ToString();
            BLCurso logica = new BLCurso(clsConfiguracion.getConnectionString);
            EntidadCurso curso;
            try {
                curso = logica.ObtenerCurso(id);
                if (curso.Existe) {
                    if (logica.EliminarCurso(curso) > 0) {

                        mensajeScript = string.Format("Javascript:mostrarMensaje('Curso eliminado correctamente')");
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
                }

            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e) {
            //removemos id curso porque este lo traiamos desde modificar, si se intenta agregar nuevo, se borra el id_de_curso 
            //para que no afecte ningun dato
            Session.Remove("id_de_curso");

            //redireccionamos al otro formulario
            Response.Redirect("MantenimientoCurso.aspx");
        }

        protected void grdLista_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            grdLista.PageIndex = e.NewPageIndex;
            CargarListaDataSet();
        }


        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLCurso logica = new BLCurso(clsConfiguracion.getConnectionString);
            DataSet DSCurso;


            try {
                DSCurso = logica.ListarCursos(condicion, orden);

                grdLista.DataSource = DSCurso;
                grdLista.DataMember = DSCurso.Tables[0].TableName;

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

        protected void lnkSeleccionar_Command1(object sender, CommandEventArgs e) {
            //si seleccionamos algun dato, obtenemos su ID y lo guardamos en una session para utilizarlo despues
            Session["id_CursoSeleccionado"] = e.CommandArgument.ToString();
            Session.Remove("visible");
            //redireccionamos hacia mantenimeitno mtraicula
            Response.Redirect("MantenimientoMatricula.aspx");
        }
    }//---*----
}