using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitioWeb {
    public partial class FrmClientes : System.Web.UI.Page {
        string mensajeScript;
        protected void Page_Load(object sender, EventArgs e) {
            EntidadCliente cliente;
            BLCliente logica = new BLCliente(clsConfiguracion.getConnectionString);
            int identificacion;
            try{
                if(!Page.IsPostBack){
                    //El iD es un dato que se ghenera en el otro formulario
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

                    if(Session["id_del_cliente"] != null){
                        identificacion = int.Parse(Session["id_del_cliente"].ToString());
                        cliente = logica.ObtenerCliente(identificacion);
                        if(cliente.Existe){
                            txtId.Text = cliente.Id_cliente.ToString();
                            txtNombre.Text = cliente.Nombre;
                            txtTelefono.Text = cliente.Telefono;
                            txtDireccion.Text = cliente.Direccion;

                            lblid.Visible = true;
                            txtId.Visible = true;   
                        }
                        else{
                            mensajeScript = String.Format("javascript:mostrarMensaje('Cliente no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        }
                    }else{
                        Limpiar();
                        txtId.Text="-1";
                        lblid.Visible = false;
                        txtId.Visible = false;
                    }
                }
            }catch(Exception ex){

            }
        }

        public void Limpiar(){
            txtId.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
        }


        private EntidadCliente GenerarEntidadCliente() {
            EntidadCliente cliente = new EntidadCliente();
            //si hay algo en la variable de sesion
            if (Session["id_del_cliente"] != null) {
                cliente.Id_cliente = int.Parse(Session["id_del_cliente"].ToString());
                cliente.Existe = true;
            }
            //Si no hay nada en la variable de sesion, es un cliente nuevo
            else {
                cliente.Id_cliente = -1;
                cliente.Existe = false;
            }

            cliente.Nombre = txtNombre.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Direccion = txtDireccion.Text;

            return cliente;
        }

        protected void btnGuardar_Click(object sender, EventArgs e) {
            EntidadCliente cliente;
            BLCliente logica = new BLCliente(clsConfiguracion.getConnectionString);
            int resultado = 0;

            try{
                cliente = GenerarEntidadCliente();
                //si el cliente ya existe se modifica
                if(cliente.Existe){
                    resultado = logica.Modificar(cliente);

                }else{//Sino existe se crea
                    if(!string.IsNullOrEmpty(txtNombre.Text)){

                        resultado = logica.Insertar(cliente);
                    }
                    else{
                        mensajeScript = string.Format("javascript:mostrarMensaje('Debe agregar al menos del nombre del cliente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        resultado = -1;
                    }
                }
                if(resultado >0){
                    mensajeScript = string.Format("javascript:mostrarMensaje('Operacion realizada correctamente')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    Response.Redirect("Default.aspx");
                }else{
                    mensajeScript = string.Format("javascript:mostrarMensaje('No se pudo ejecutar la operacion')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                }


            }catch(Exception ex){
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')",ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e) {

            Response.Redirect("Default.aspx");
        }
    }//----
}