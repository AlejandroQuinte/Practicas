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
    public partial class MantenimientoCurso : System.Web.UI.Page {
        string mensajeScript;
        EntidadCurso CursoRegistrado;
        protected void Page_Load(object sender, EventArgs e) {
            EntidadCurso curso;
            BLCurso logica = new BLCurso(clsConfiguracion.getConnectionString);
            string identificacion;
            try {

                if (!Page.IsPostBack) {
                    

                    if (Session["id_de_curso"] != null) {
                        identificacion = Session["id_de_curso"].ToString();
                        CargarCurso(identificacion);
                        curso = logica.ObtenerCurso(identificacion);
                        if (curso.Existe) {

                            txtIdCurso.Text = curso.Id_curso;
                            txtIdIdioma.Text = curso.Id_idioma;
                            txtIdNota.Text = curso.Id_nota.ToString();
                            txtNombreCurso.Text = curso.NombreCurso;
                            txtCantCursos.Text = curso.CantidadCursos.ToString();
                            txtHorasCurso.Text = curso.HorasCurso.ToString();
                            txtPrecio.Text = curso.Precio.ToString();


                        }
                        else {
                            mensajeScript = String.Format("javascript:mostrarMensaje('Matricula no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        }
                    }
                    else {
                        Limpiar();
                    }
                }
            } catch (Exception ex) {

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e) {
            EntidadCurso curso;
            BLCurso logica = new BLCurso(clsConfiguracion.getConnectionString);
            string resultado;
            int resultadoM = 0;

            try {
                curso = GenerarEntidadCurso();
                //si el cliente ya existe se modifica
                if (curso.Existe) {
                    resultadoM = logica.Modificar(curso);
                    if (resultadoM != 0) {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Operacion Realizada correctamente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        Limpiar();
                    }

                }
                else {
                    resultado = logica.Insertar(curso);
                    if (string.IsNullOrEmpty(resultado)) {
                        mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", logica.mensaje);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        Response.Redirect("Curso.aspx");
                    }
                    else {
                        if (resultadoM == 0) {
                            mensajeScript = string.Format("javascript:mostrarMensaje('Insertado correctamente')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                            Response.Redirect("Curso.aspx");
                            
                        }else{
                            mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", logica.mensaje);
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        }

                    }

                }


            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e) {
            Response.Redirect("Curso.aspx");
        }


        //---*-*-*-----


        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-idioma
        private void CargarCurso(string id) {

            EntidadCurso curso = new EntidadCurso();
            BLCurso traerCurso = new BLCurso(clsConfiguracion.getConnectionString);

            try {
                curso = traerCurso.ObtenerCurso(id);

                if (curso != null) {
                    txtIdCurso.Text = curso.Id_curso;
                    txtIdIdioma.Text = curso.Id_idioma;
                    txtIdNota.Text = curso.Id_nota.ToString();
                    txtNombreCurso.Text = curso.NombreCurso;
                    txtCantCursos.Text = curso.CantidadCursos.ToString();
                    txtHorasCurso.Text = curso.HorasCurso.ToString();
                    txtPrecio.Text = curso.Precio.ToString();


                    CursoRegistrado = curso;
                }
                else {
                    MessageBox.Show("El cliente no se encuentra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//---------------------------


        //Generar Entidad
        public EntidadCurso GenerarEntidadCurso() {

            EntidadCurso curso= new EntidadCurso();
            if (Session["id_de_curso"] != null) {

                curso.Id_curso = Session["id_de_curso"].ToString();
                curso.Existe = true;
            }
            //Si no hay nada en la variable de sesion, es un cliente nuevo
            else {
                curso.Id_curso = "-1";
                curso.Existe = false;
            }

            curso.Id_curso = txtIdCurso.Text;
            curso.Id_nota = Convert.ToInt32(txtIdNota.Text);
            curso.Id_idioma = txtIdIdioma.Text;
            curso.NombreCurso = txtNombreCurso.Text;
            curso.CantidadCursos = Convert.ToInt32(txtCantCursos.Text);
            curso.HorasCurso = Convert.ToInt32(txtHorasCurso.Text);
            int horas = Convert.ToInt32(txtHorasCurso.Text);
            curso.HorasSincronicas = (int)(horas / 100) * 25;
            curso.HorasAsincronicas = (int)(horas / 100) * 75;
            curso.Precio = float.Parse(txtPrecio.Text);

            return curso;
        }//---------------------------------


        public void Limpiar() {
            txtIdCurso.Text = string.Empty;
            txtIdIdioma.Text = string.Empty;
            txtIdNota.Text = string.Empty;
            txtNombreCurso.Text = string.Empty;
            txtCantCursos.Text = string.Empty;
            txtHorasCurso.Text = string.Empty;
            txtPrecio.Text = string.Empty;


        }//-----------------


    }//----*---
}