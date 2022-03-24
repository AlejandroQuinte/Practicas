using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using System.Data;

namespace SitioWeb {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            try { 
                if(!IsPostBack){
                    CargarListaDataSetCliente();
                    CargarListaDataSetProducto();
                }
            }catch {
                //throw;
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
            } catch (Exception) {
                throw;
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
            } catch (Exception) {
                throw;
            }
        }// fin CargarListaDataSet



    }
}