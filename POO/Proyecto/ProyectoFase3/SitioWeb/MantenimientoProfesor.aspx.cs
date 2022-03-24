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
    public partial class MantenimientoProfesor : System.Web.UI.Page {
        string mensajeScript;
        EntidadProfesor datoRegistrado;
        protected void Page_Load(object sender, EventArgs e) {
            EntidadProfesor profesor;
            BLProfesor logica = new BLProfesor(clsConfiguracion.getConnectionString);
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

                    if (Session["id_de_profesor"] != null) {
                        identificacion = int.Parse(Session["id_de_profesor"].ToString());
                        CargarProfesor(identificacion);
                        profesor = logica.ObtenerProfesor(identificacion);
                        if (profesor.Existe) {

                            txtIdProfesor.Text = profesor.Identificacion.ToString();
                            txtNombre.Text = profesor.Nombre.ToString();
                            txtApellido1.Text = profesor.Apellido1;
                            txtApellido2.Text = profesor.Apellido2;
                            txtCorreo.Text = profesor.Correo;
                            txtTelefono.Text = profesor.Telefono.ToString();


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
            EntidadProfesor profesor;
            BLProfesor logica = new BLProfesor(clsConfiguracion.getConnectionString);
            int resultado = 0;

            try {
                profesor = GenerarEntidad();
                //si el cliente ya existe se modifica
                if (profesor.Existe) {
                    resultado = logica.Modificar(profesor);

                }
                else {//Sino existe se crea
                    if (string.IsNullOrEmpty(txtIdProfesor.Text)) {

                        resultado = logica.Insertar(profesor);
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
                    Response.Redirect("Profesor.aspx");
                }
                else {
                    mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", logica.mensaje);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                }


            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e) {
            Response.Redirect("Profesor.aspx");
        }



        //Generar Entidad
        public EntidadProfesor GenerarEntidad() {

            EntidadProfesor profesor = new EntidadProfesor();
            if (Session["id_de_profesor"] != null) {

                profesor.Identificacion = int.Parse(Session["id_de_profesor"].ToString());
                profesor.Existe = true;
            }
            //Si no hay nada en la variable de sesion, es un cliente nuevo
            else {
                profesor.Identificacion = -1;
                profesor.Existe = false;
            }

            profesor.Nombre = txtNombre.Text;
            profesor.Apellido1 = txtApellido1.Text;
            profesor.Apellido2 = txtApellido2.Text;
            profesor.Correo = txtCorreo.Text;
            profesor.Telefono = int.Parse(txtTelefono.Text);

            return profesor;
        }//---------------------------------


        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-Principal
        private void CargarProfesor(int id) {

            EntidadProfesor profesor = new EntidadProfesor();
            BLProfesor traerDato = new BLProfesor(clsConfiguracion.getConnectionString);

            try {
                profesor = traerDato.ObtenerProfesor(id);

                if (profesor != null) {
                    txtIdProfesor.Text = profesor.Identificacion.ToString();
                    txtNombre.Text = profesor.Nombre;
                    txtApellido1.Text = profesor.Apellido1;
                    txtApellido2.Text = profesor.Apellido2;
                    txtCorreo.Text = profesor.Correo;
                    txtTelefono.Text = profesor.Telefono.ToString();

                    datoRegistrado = profesor;
                }
                else {
                    MessageBox.Show("El Dato no se encuentra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//---------------------------

        public void Limpiar() {
            txtIdProfesor.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }//-----------------


    }//--
}