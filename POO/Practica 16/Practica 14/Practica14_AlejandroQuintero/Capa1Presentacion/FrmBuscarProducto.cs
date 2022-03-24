using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Capa2LogicaNegocio;
using CapaEntidades;


namespace Capa1Presentacion {
    public partial class FrmBuscarProducto : Form {
        public FrmBuscarProducto() {
            InitializeComponent();
        }
        //Crea el evento handler para enviar valores al frmClientes
        public event EventHandler Aceptar;

        //Crea el evento handler para enviar valores al frmClientes


        //Variable global para accederla de todos los metodos de la clase
        int vgn_idproducto; //vgn = Variable Global Numerica 

        private void FrmBuscarProducto_Load(object sender, EventArgs e) {
            try {
                CargarListaDataSet();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void seleccionar() {
            if (GrdProductos.SelectedRows.Count > 0) {
                vgn_idproducto = (int)GrdProductos.SelectedRows[0].Cells[0].Value;
                //Le manda el id al evento aceptar que esta en frmClientes
                Aceptar(vgn_idproducto, null);
                Close();

            }
        }


        private void CargarListaDataSet(string condicion = "", string orden = "") {
            //cargar el datagridview con los datos del dataset
            BLProducto logica = new BLProducto(Configuracion.getConnectionString);
            DataSet DSProductos;

            try {
                DSProductos = logica.ListarProductos(condicion, orden);
                GrdProductos.DataSource = DSProductos;
                GrdProductos.DataMember = DSProductos.Tables["Productos"].TableName;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//---------------------------------------

        private void GrdProductos_DoubleClick(object sender, EventArgs e) {
            seleccionar();
        }

        private void BtnAceptar_Click(object sender, EventArgs e) {
            seleccionar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e) {
            string condicion = string.Empty;

            try {
                if (!string.IsNullOrEmpty(TxtNombre.Text)) {
                    //lo que escriba en el txt nombre, el TRIM le quita los pesacios en blanco
                    condicion = string.Format("Descripcion like '%{0}%'", TxtNombre.Text.Trim());
                }
                else {
                    MessageBox.Show("Debe escribir parte del nombre a buscar", "Atencion",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtNombre.Focus();
                }
                CargarListaDataSet(condicion);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//------------------------------------------












    }
}
