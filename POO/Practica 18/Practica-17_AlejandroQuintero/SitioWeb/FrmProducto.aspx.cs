using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitioWeb {
    public partial class FrmProducto : System.Web.UI.Page {
        string mensajeScript;
        protected void Page_Load(object sender, EventArgs e) {
            entidadProducto producto;
            blProducto logica = new blProducto(clsConfiguracion.getConnectionString);
            int identificacion;
            try {
                if (!Page.IsPostBack) {
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

                    if (Session["id_del_producto"] != null) {
                        identificacion = int.Parse(Session["id_del_producto"].ToString());
                        producto = logica.ObtenerProducto(identificacion);
                        if (producto.Existe) {
                            txtIdProducto.Text = producto.IdProducto.ToString();
                            txtDescripcion.Text = producto.Descripcion;
                            txtPrecioCompra.Text = producto.PrecioCompra.ToString();
                            txtPrecioVenta.Text = producto.PrecioVenta.ToString();
                            txtGravado.Text = producto.Gravado;

                            lblidProducto.Visible = true;
                            txtIdProducto.Visible = true;
                        }
                        else {
                            mensajeScript = String.Format("javascript:mostrarMensaje('Cliente no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        }
                    }
                    else {
                        Limpiar();
                        txtIdProducto.Text = "-1";
                        lblidProducto.Visible = false;
                        txtIdProducto.Visible = false;
                    }
                }
            } catch (Exception ex) {
                mensajeScript = String.Format("javascript:mostrarMensaje('Cliente no encontrado')");
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }


        private entidadProducto GenerarEntidadProducto() {
            entidadProducto producto = new entidadProducto();
            //si hay algo en la variable de sesion
            if (Session["id_del_producto"] != null) {
                producto.IdProducto = int.Parse(Session["id_del_producto"].ToString());
                producto.Existe = true;
            }
            //Si no hay nada en la variable de sesion, es un cliente nuevo
            else {
                producto.IdProducto = -1;
                producto.Existe = false;
            }

            producto.Descripcion = txtDescripcion.Text;
            producto.PrecioCompra = float.Parse(txtPrecioCompra.Text);
            producto.PrecioVenta = float.Parse(txtPrecioVenta.Text);
            producto.Gravado = txtGravado.Text;
            return producto;
        }

        protected void btnGuardar_Click(object sender, EventArgs e) {
            entidadProducto producto;
            blProducto logica = new blProducto(clsConfiguracion.getConnectionString);
            int resultado = 0;

            try {
                producto = GenerarEntidadProducto();
                //si el cliente ya existe se modifica
                if (producto.Existe) {
                    resultado = logica.Modificar(producto);

                }
                else {//Sino existe se crea
                    if (!string.IsNullOrEmpty(txtDescripcion.Text)) {

                        resultado = logica.Insertar(producto);
                    }
                    else {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Debe agregar al menos la descripcion del producto')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        resultado = -1;
                    }
                }
                if (resultado > 0) {
                    mensajeScript = string.Format("javascript:mostrarMensaje('Operacion realizada correctamente')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    Response.Redirect("Default.aspx");
                }
                else {
                    mensajeScript = string.Format("javascript:mostrarMensaje('No se pudo ejecutar la operacion')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                }


            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }//--------------------


        public void Limpiar() {
            txtIdProducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtGravado.Text = "";
        }

    }//-------------
}