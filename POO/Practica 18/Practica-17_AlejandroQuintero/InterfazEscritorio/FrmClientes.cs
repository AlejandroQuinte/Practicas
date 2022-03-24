using System.Windows.Forms;
using LogicaNegocio;
using Entidades;
using System;
using System.Data;
using System.Collections.Generic;

namespace InterfazEscritorio
{
    public partial class FrmClientes : Form
    {
        // variable global.
        FrmBuscarClientes formularioBuscar;


        /*variable global, esto si el campo txtIdCliente.Text
        tiene algún valor, significa que el cleinte existe
        no se debe insertar se debe modificar*/ 
        EntidadCliente clienteRegistrado;
        

        public FrmClientes()
        {
            InitializeComponent();
        }//FrmClientes()

        //Limpiar los campos del formulario
        private void Limpiar()
        {
            txtIdCliente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txttelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtNombre.Focus();
        }

        //generar entidad para crear la informacion 
        private EntidadCliente GenerarEntidad()
        {
            EntidadCliente cliente;
            if (!string.IsNullOrEmpty(txtIdCliente.Text))
            {
                cliente = clienteRegistrado;
            }
            else
            {
                cliente = new EntidadCliente();
            }
            cliente.setNombre(txtNombre.Text);
            cliente.setTelefono(txttelefono.Text);
            cliente.setDireccion(txtDireccion.Text);
            return cliente;
        }//fin GenerarEntidad

        //Metodo para guardar un cliente
        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            BLCliente logica = new BLCliente(Configuracion.getConnectionString);
            EntidadCliente cliente;
            int resultado;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) &&
                    !string.IsNullOrEmpty(txttelefono.Text) &&
                    !string.IsNullOrEmpty(txtDireccion.Text))
                {
                    cliente = GenerarEntidad();
                    if (!cliente.Existe)
                    {
                        resultado = logica.Insertar(cliente);
                    }
                    else {
                        resultado = logica.Modificar(cliente);
                    }
                    if (resultado > 0)
                    {
                        Limpiar();
                        MessageBox.Show("Operacion Realizada con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarListaArray();
                    }
                    else {
                        MessageBox.Show("No se realizaron cambios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Los datos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }// fin btnGuardar_Click

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


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

        private void CargarListaArray(string condicion = "")
        {
            BLCliente logica = new BLCliente(Configuracion.getConnectionString);
            List<EntidadCliente> clientes;
            try
            {
                clientes = logica.ListarClientes(condicion);
                if (clientes.Count > 0) //si la lista tiene algo entonces...
                {
                    grdLista.DataSource = clientes;//cargue en el datagridview lo que tiene la lista
                    //Columns[4] corresponde al campo existe
                   // grdLista.Columns[4].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }// fin CargarListaArray



        private void FrmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                // CargarListaDataSet();
                
                // En el load del formulario se llama a carga el gridview con el data set
                CargarListaArray();
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//FrmClientes_Load

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            formularioBuscar = new FrmBuscarClientes();
            //se especifica que se quiere usar el evento ACEPTAR
            formularioBuscar.Aceptar += new EventHandler(Aceptar);
            formularioBuscar.ShowDialog();
        }// fin btnBuscar_Click

        //Implementa el evento aceptar, este recibe un id el cual se manda desde
        //FrmBuscarCliente y se usa en FrmClientes para cargar los datos del cliente
        private void Aceptar(object id,EventArgs e)
        {
            try
            {
                int idCliente = (int)id;
                if (idCliente != -1)
                {
                    CargarCliente(idCliente);
                }
                else
                {
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }// fin Aceptar

        private void CargarCliente(int id)
        {
            EntidadCliente cliente = new EntidadCliente();
            BLCliente traerCliente = new BLCliente(Configuracion.getConnectionString);
            try
            {
                cliente = traerCliente.ObtenerCliente(id);
                if (cliente != null)
                {
                    txtIdCliente.Text = cliente.Id_cliente.ToString();
                    txtNombre.Text = cliente.Nombre;
                    txttelefono.Text = cliente.Telefono;
                    txtDireccion.Text = cliente.Direccion;
                    /*Se asigna la entidad cliente local
                     a la variable global clienteRegistrado*/
                    clienteRegistrado = cliente;
                }
                else
                {
                    MessageBox.Show("El cliente no se encuentra en la base de datos",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarListaArray(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }
        }//fin CargarCliente

        private void grdLista_DoubleClick(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                //se recupero el ID
                id = (int)grdLista.SelectedRows[0].Cells[0].Value;
                //ya con el ID recuperado se puede llamar a la funcion que carga
                //el cliente desde la base de datos en el formulario
                CargarCliente(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }//grdLista_DoubleClick

        private void btneliminar_Click(object sender, EventArgs e)
        {
            EntidadCliente cliente;
            int resultado;
            BLCliente logica = new BLCliente(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtIdCliente.Text))
                {   //busca primero el cliente antes de borrarlo para ver si existe
                    cliente = logica.ObtenerCliente(int.Parse(txtIdCliente.Text));
                    if (cliente != null)
                    {
                        /* Eliminar con procedimiento almacenado
                        resultado = logica.EliminarConSP(cliente);
                        MessageBox.Show(logica.Mensaje, "Aviso", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        //imprime el mensaje que el SP mandó
                        */
                        /* Eliminar sin procedimiento almacenado*/
                        resultado = logica.EliminarCliente(cliente);
                        MessageBox.Show("Eliminado sin PS", "Aviso", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaArray();
                    }
                    else
                    {
                        MessageBox.Show("El cliente no existe", "Aviso", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        Limpiar();
                        CargarListaArray();
                    }
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar un cliente antes de eliminar", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//btnEliminar_Click
    


        ////clienteRegistrado = cliente; //se setea el cliente registrado para poder darle la opcion al usuario de modificar la informacion del cliente
        ///

    }// FrmClientes : Form
}// Fin namespace InterfazEscritorio


