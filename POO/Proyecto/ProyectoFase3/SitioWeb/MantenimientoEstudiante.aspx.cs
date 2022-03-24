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
    public partial class MantenimientoEstudiante : System.Web.UI.Page {
        string mensajeScript;
        EntidadEstudiante datoRegistrado;
        protected void Page_Load(object sender, EventArgs e) {
            EntidadEstudiante estudiante;
            BLEstudiante logica = new BLEstudiante(clsConfiguracion.getConnectionString);
            int identificacion;
            try {

                if (!Page.IsPostBack) {
                    //El iD es un dato que se genera en el otro formulario
                    //se pueden enviar datos de un formulario a otro por QueryString por SESSIION(Existe muchas otras formas de enviar datos
                    //entre paginas web)
                    //Lo enviaremos por sesion, vamos a pregunntar si lo que se viene por sesion trae algo

                    /*
                    FUncionamiento:
                        El formulario defautl le enviara por sesion un valor al formulario FRMClientes,
                        esto permite que de un formulario enviemos valores hasta otro formulario.
                        en este formuilario(FRMClientes) estamos preguntando si en el valor de sesion existe algun valor llamado "ID_del_cliente"
                        esto implica que desde el formulario Defatul (o cualquier otro formulario que invoque a FrmClientes)
                        debemios crear una Variuable de SESION y llamarla "id_del_cliente" asignandole el ID que corresponda
                     */

                    if (Session["id_de_estudiante"] != null) {
                        identificacion = int.Parse(Session["id_de_estudiante"].ToString());
                        CargarEstudiante(identificacion);
                        estudiante = logica.ObtenerEstudiante(identificacion);
                        if (estudiante.Existe) {

                            txtIdEstudiante.Text = estudiante.Identificacion.ToString();
                            txtNombre.Text = estudiante.Nombre.ToString();
                            txtApellido1.Text = estudiante.Apellido1;
                            txtApellido2.Text = estudiante.Apellido2;
                            txtCorreo.Text = estudiante.Correo;
                            txtTelefono.Text = estudiante.Telefono.ToString();

                            datoRegistrado = estudiante;
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
            EntidadEstudiante estudiante;
            BLEstudiante logica = new BLEstudiante(clsConfiguracion.getConnectionString);
            int resultado = 0;

            try {
                estudiante = GenerarEntidad();
                //si el cliente ya existe se modifica
                if (estudiante.Existe) {
                    resultado = logica.Modificar(estudiante);

                }
                else {//Sino existe se crea
                    if (string.IsNullOrEmpty(txtIdEstudiante.Text)) {

                        resultado = logica.Insertar(estudiante);
                    }
                    else {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Debe agregar al menos del nombre')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        resultado = -1;
                    }
                }
                if (resultado > 0) {
                    mensajeScript = string.Format("javascript:mostrarMensaje('Operacion realizada correctamente')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    Response.Redirect("Estudiante.aspx");
                }
                else {
                    mensajeScript = string.Format("javascript:mostrarMensaje('{0}')",logica.mensaje);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                }


            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e) {
            Response.Redirect("Estudiante.aspx");
        }






        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-Principal
        private void CargarEstudiante(int id) {

            EntidadEstudiante estudiante = new EntidadEstudiante();
            BLEstudiante traerDato = new BLEstudiante(clsConfiguracion.getConnectionString);

            try {
                estudiante = traerDato.ObtenerEstudiante(id);

                if (estudiante != null) {
                    txtIdEstudiante.Text = estudiante.Identificacion.ToString();
                    txtNombre.Text = estudiante.Nombre;
                    txtApellido1.Text = estudiante.Apellido1;
                    txtApellido2.Text = estudiante.Apellido2;
                    txtCorreo.Text = estudiante.Correo;
                    txtTelefono.Text = estudiante.Telefono.ToString();

                    datoRegistrado = estudiante;
                }
                else {
                    MessageBox.Show("El Dato no se encuentra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//---------------------------

        //Generar Entidad
        public EntidadEstudiante GenerarEntidad() {

            EntidadEstudiante estudiante= new EntidadEstudiante();

            //si hay algo en la variable de sesion
            if (Session["id_de_estudiante"] != null) {

                estudiante.Identificacion = int.Parse(Session["id_de_estudiante"].ToString());
                estudiante.Existe = true;
            }
            //Si no hay nada en la variable de sesion, es un cliente nuevo
            else {
                estudiante.Identificacion = -1;
                estudiante.Existe = false;
            }

            estudiante.Nombre = txtNombre.Text;
            estudiante.Apellido1 = txtApellido1.Text;
            estudiante.Apellido2 = txtApellido2.Text;
            estudiante.Correo = txtCorreo.Text;
            estudiante.Telefono = int.Parse(txtTelefono.Text);

            return estudiante;
        }//---------------------------------

        public void Limpiar() {
            txtIdEstudiante.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;


        }//-----------------



    }//-*---
}