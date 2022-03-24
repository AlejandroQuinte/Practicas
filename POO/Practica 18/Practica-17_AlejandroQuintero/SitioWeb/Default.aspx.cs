using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using System.Data;
using Entidades;

namespace SitioWeb {
    public partial class Default : System.Web.UI.Page {

        string mensajeScript;
        protected void Page_Load(object sender, EventArgs e) {
            try { 
                if(!IsPostBack){
                    CargarListaDataSetCliente();
                    CargarListaDataSetProducto();
                }
            }catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        private void CargarListaDataSetCliente(string condicion="", string orden="") {
            //carga el datagridview con el dataset
            BLCliente logica = new BLCliente(clsConfiguracion.getConnectionString);
            DataSet DSClientes;

            try {
                DSClientes = logica.ListarClientesDS(condicion, orden);
                grdListaCliente.DataSource = DSClientes;
                grdListaCliente.DataMember = DSClientes.Tables[0].TableName;
                //en la tabla con nombre Clientes del dataset
                grdListaCliente.DataBind();
            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }// fin CargarListaDataSet

        private void CargarListaDataSetProducto(string condicion = "", string orden = "") {
            //carga el datagridview con el dataset
            blProducto logica = new blProducto(clsConfiguracion.getConnectionString);
            DataSet DSProducto;

            try {
                DSProducto = logica.ListarProductosDS(condicion, orden);
                grdListaProducto.DataSource = DSProducto;
                grdListaProducto.DataMember = DSProducto.Tables[0].TableName;
                //en la tabla con nombre Clientes del dataset
                grdListaProducto.DataBind();
            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }// fin CargarListaDataSet


        //cambio de pagina

        protected void grdListaCliente_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            grdListaCliente.PageIndex = e.NewPageIndex;
            CargarListaDataSetCliente();
        }
        protected void grdListaProducto_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            grdListaProducto.PageIndex = e.NewPageIndex;
            CargarListaDataSetProducto();
        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e) {
            try{
                if(!string.IsNullOrEmpty(txtBuscarCliente.Text)){
                    string condicion = string.Format("NOMBRE LIKE '%{0}%'", txtBuscarCliente.Text);
                    //Que el nombre contenga lo que este escrito en el cuadro
                    CargarListaDataSetCliente(condicion);
                }
                
            }catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(txtBuscarProduto.Text)) {
                    string condicion = string.Format("DESCRIPCION LIKE '%{0}%'", txtBuscarProduto.Text);
                    //Que el nombre contenga lo que este escrito en el cuadro
                    CargarListaDataSetProducto(condicion);
                }

            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e) {
            //leemos el ID que envia el commandEvent
            int id = int.Parse(e.CommandArgument.ToString());
            blProducto logica = new blProducto(clsConfiguracion.getConnectionString);
            entidadProducto producto;
            try{
                producto = logica.ObtenerProducto(id);
                if(producto.Existe){
                    if(logica.EliminarProducto(producto) >0){

                        mensajeScript = string.Format("Javascript:mostrarMensaje('Producto eliminado correctamente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);

                        CargarListaDataSetProducto();
                        txtBuscarProduto.Text = "";
                    }
                }
            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void lnkEliminar_Command1(object sender, CommandEventArgs e) {
            //leemos el ID que envia el commandEvent
            int id = int.Parse(e.CommandArgument.ToString());
            BLCliente logica = new BLCliente(clsConfiguracion.getConnectionString);
            EntidadCliente cliente;
            try {
                cliente = logica.ObtenerCliente(id);
                if (cliente.Existe) {
                    if (logica.EliminarCliente(cliente) > 0) {

                        mensajeScript = string.Format("javascript:mostrarMensaje('Cliente eliminado correctamente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, false);

                        CargarListaDataSetCliente();
                        txtBuscarCliente.Text = "";
                    }
                }
            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", logica.Mensaje);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, false);
            }
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e) {
            //aqui vamos a asignar el valor de seion y redireccionar la pagina
            //En el valor de sesion colocamos el valor que ocntenga el command
            //(el ID del cliente) al se le dio click)

            Session["id_del_cliente"] = e.CommandArgument.ToString();

            //redireccionamos el otro formulario (FrmClientes)

            Response.Redirect("FrmClientes.aspx");


        }

        protected void btnAgregar_Click(object sender, EventArgs e) {
            //Eliminamos la variable de sesion, asi cuando el otro formulario pregunte si esta vacia determinará que 
            //efectivamente está vacia, lo cual significa que debemos agregar un nuevo cliente

            Session.Remove("id_del_cliente");

            //redireccionamos al otro formulario
            Response.Redirect("FrmClientes.aspx");

        }

        protected void lnkModificar_Command1(object sender, CommandEventArgs e) {
            //aqui vamos a asignar el valor de seion y redireccionar la pagina
            //En el valor de sesion colocamos el valor que ocntenga el command
            //(el ID del cliente) al se le dio click)

            Session["id_del_producto"] = e.CommandArgument.ToString();

            //redireccionamos el otro formulario (FrmClientes)

            Response.Redirect("FrmProducto.aspx");
        }

        protected void btnAgregarProducto_Click1(object sender, EventArgs e) {
            //Eliminamos la variable de sesion, asi cuando el otro formulario pregunte si esta vacia determinará que 
            //efectivamente está vacia, lo cual significa que debemos agregar un nuevo cliente

            Session.Remove("id_del_producto");

            //redireccionamos al otro formulario
            Response.Redirect("FrmProducto.aspx");
        }
    }//-----------
}