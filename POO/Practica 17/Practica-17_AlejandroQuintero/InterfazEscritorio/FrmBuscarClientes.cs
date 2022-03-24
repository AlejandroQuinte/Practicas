using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace InterfazEscritorio
{
    public partial class FrmBuscarClientes : Form
    {
        // Crear el evento EventHandler para enviar valores
        // Al formulario FrmClientes
        public event EventHandler Aceptar;

        //Variable global para accederla de todos los metodos de la clase
        int vgn_id_cliente;


        public FrmBuscarClientes()
        {
            InitializeComponent();
        }

        //llamar metodo cargar clientes, para mostralos en el DataGridView

        private void CargarListaArray(string condicion = "")
        { //carga el datagridview con la informacion de la lista 
            BLCliente logica = new BLCliente(Configuracion.getConnectionString);
            List<EntidadCliente> clientes;

            try
            {
                clientes = logica.ListarClientes(condicion);
                if (clientes.Count > 0) //si la lista tiene algo entonces...
                {
                    grdLista.DataSource = clientes;//cargue en el datagridview lo que tiene la lista
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }// fin CargarListaArray



        //llamar metodo cargar clientes, para mostralos en el DataGridView

        //private void CargarListaDataSet(string condicion = "", string orden = "")
        //{
        //    //carga el datagridview con el dataset
        //    BLCliente logica = new BLCliente(Configuracion.getConnectionString);
        //    DataSet DSClientes;

        //    try
        //    {
        //        DSClientes = logica.ListarClientes(condicion, orden);
        //        grdLista.DataSource = DSClientes;
        //        grdLista.DataMember = DSClientes.Tables["Clientes"].TableName;
        //        //en la tabla con nombre Clientes del dataset
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);
        //    }
        //}// fin CargarListaDataSet



        private void FrmBuscarClientes_Load(object sender, EventArgs e)
        {
            try
            {
                CargarListaArray(); //en el load del formulario se llama a carga el gridview
                //CargarListaDataSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }// fin FrmBuscarClientes_Load

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Condicion para filtrar los datos y recuperar el cliente deseado
            string condicion = string.Empty; 
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))//si no esta vacio
                {
                    //Lo se escriba en el txtNombre el trim lo usa para quitar espacios
                    condicion = string.Format("Nombre like '%{0}%'", txtNombre.Text.Trim()); 
                }
                else{
                    MessageBox.Show("Debe escribir el nombre a buscar", "Atención", 
                        MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txtNombre.Focus();
                }
                CargarListaArray(condicion);
                //CargarListaDataSet(condicion);
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }// fin btnBuscar_Click


        //Método que permite seleccionar el id de la fila del datagridview que se escoja
        private void Seleccionar()
        {
            if (grdLista.SelectedRows.Count > 0) //si ha seleccionado una fila
            {
                vgn_id_cliente = (int)grdLista.SelectedRows[0].Cells[0].Value;
                Aceptar(vgn_id_cliente, null);
                //le manda el id al evento aceptar que esta en frmClientes
                Close();
            }
        }//Fin Seleccionar

        private void grdLista_DoubleClick(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Aceptar(-1, null);
            Close();
        }
    }// fin class FrmBuscarClientes : Form
}// Fin InterfazEscritorio
