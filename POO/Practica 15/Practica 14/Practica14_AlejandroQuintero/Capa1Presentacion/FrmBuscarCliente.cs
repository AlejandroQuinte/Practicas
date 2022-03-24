using Capa2LogicaNegocio;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Capa1Presentacion {
    public partial class FrmBuscarCliente : Form {
        public FrmBuscarCliente() {
            InitializeComponent();
        }


        //Crea el evento handler para enviar valores al frmClientes
        public event EventHandler Aceptar;
        //Variable global para accederla de todos los metodos de la clase
        int vgn_idcliente; //vgn = Variable Global Numerica 

        private void BtnBuscar_Click(object sender, EventArgs e) {
            string condicion = string.Empty;

            try{
                if(!string.IsNullOrEmpty(TxtNombre.Text)){
                    //lo que escriba en el txt nombre, el TRIM le quita los pesacios en blanco
                    condicion = string.Format("Nombre like '%{0}%'", TxtNombre.Text.Trim());
                }else{
                    MessageBox.Show("Debe escribir parte del nombre a buscar", "Atencion",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtNombre.Focus();
                }
                CargarListaArray(condicion);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void CargarListaArray(string condicion =""){
            BLCliente logica = new BLCliente(Configuracion.getConnectionString);
            List<EntidadCliente> clientes;

            try{

                clientes = logica.ListarClientes(condicion);
                if(clientes.Count>0){
                    GrdClientes.DataSource = clientes;//carguelo al datagridview
                }

            }catch (Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void seleccionar() {
            if (GrdClientes.SelectedRows.Count > 0) {
                vgn_idcliente = (int)GrdClientes.SelectedRows[0].Cells[0].Value;
                //Le manda el id al evento aceptar que esta en frmClientes
                Aceptar(vgn_idcliente, null);
                Close();

            }
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e) {
            CargarListaArray();
        }

        private void BtnAceptar_Click(object sender, EventArgs e) {
            seleccionar();
        }

        private void BtnCancelar_Click(object sender, EventArgs e) {
            Close();
        }

        private void GrdClientes_DoubleClick(object sender, EventArgs e) {
            seleccionar();
        }
    }
}
