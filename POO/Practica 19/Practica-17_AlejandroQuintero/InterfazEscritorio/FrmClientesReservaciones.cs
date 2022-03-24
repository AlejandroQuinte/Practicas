using AccesoDatos;
using Entidades;
using LogicaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace InterfazEscritorio
{
    public partial class FrmClientesReservaciones : Form
    {
        // variable global.
        FrmBuscarClientes formularioBuscar;

        public FrmClientesReservaciones()
        {
            InitializeComponent();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            formularioBuscar = new FrmBuscarClientes();
            //se especifica que se quiere usar el evento ACEPTAR
            formularioBuscar.Aceptar += new EventHandler(Aceptar);
            formularioBuscar.ShowDialog();
        }//btnBuscar_Click


        private void Aceptar(object id, EventArgs e)
        {
            try
            {
                int idCliente = (int)id;
                if (idCliente != -1)
                {
                    CargarCliente(idCliente);
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
                }
                else
                {
                    MessageBox.Show("El cliente no se encuentra en la base de datos",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }
        }//fin CargarCliente

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedItem.ToString() == "STANDARD")
            {
                txtPrecioNoche.Text = "25000";
            }
            else if (cboTipo.SelectedItem.ToString() == "JUNIOR")
            {
                txtPrecioNoche.Text = "20000";
            }
            else {
                txtPrecioNoche.Text = "30000";
            }
        }//cboTipo_SelectedIndexChanged

        private void calcularNoches() {
            if (dtpFIngreso.Value.Date < DateTime.Now.Date || 
                dtpFSalida.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("La fecha no puede ser menor a hoy", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dtpFIngreso.Value = DateTime.Now;
                dtpFSalida.Value = dtpFIngreso.Value.AddDays(1);
            }
            else if (dtpFIngreso.Value.Date > dtpFSalida.Value.Date)
            {
                MessageBox.Show("El ingreso no puede ser menor a la salida", "Advertencia",
                   MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dtpFSalida.Value = dtpFIngreso.Value.AddDays(1);
            }
            else
            {
                int cDias = (int)(dtpFSalida.Value - dtpFIngreso.Value).TotalDays;
                txtTotalNoches.Text = cDias.ToString();
            }
        }//calcularNoches

        private void dtpFIngreso_ValueChanged(object sender, EventArgs e)
        {
            dtpFSalida.Value = dtpFIngreso.Value.AddDays(1); 
            calcularNoches();
        }
        private void dtpFSalida_ValueChanged(object sender, EventArgs e)
        {
            calcularNoches();
        }

        private void verificarGuardar() { 
           if(string.IsNullOrEmpty(txtIdCliente.Text))
            {
                btnGuardarReservacion.Enabled = false;
            }
            else{
                btnGuardarReservacion.Enabled = true;
            }
        }

        private void FrmClientesReservaciones_Load(object sender, EventArgs e)
        {
            dtpFSalida.Value = dtpFIngreso.Value.AddDays(1);
            cboCPersonas.SelectedIndex = 1;
            cboTipo.SelectedIndex = 0;
            cboCancelada.SelectedIndex = 0;
            calculaTotal();
            verificarGuardar();
            
        }//FrmClientesReservaciones_Load

        private void calculaTotal()
        {
            double total = 0;
            if (!string.IsNullOrEmpty(txtPrecioNoche.Text) &&
                !string.IsNullOrEmpty(txtTotalNoches.Text))
            {
                total = Convert.ToInt32(txtTotalNoches.Text) *
                        Convert.ToInt32(cboCPersonas.Text) *
                        Convert.ToInt32(txtPrecioNoche.Text);
                txtTotalPagar.Text = total.ToString();
            }
        }// fin calculaTotal()

        private void txtTotalNoches_TextChanged(object sender, EventArgs e)
        {
            calculaTotal();
        }

        private void txtPrecioNoche_TextChanged(object sender, EventArgs e)
        {
            calculaTotal();
        }

        private void cboCPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculaTotal();
        }

        private void Limpiar() {
            txtIdCliente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txttelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtIdReservacion.Text = string.Empty;
            
            verificarGuardar();
            
            dtpFIngreso.Value = DateTime.Now;
            dtpFSalida.Value = dtpFIngreso.Value.AddDays(1);
            cboCPersonas.SelectedIndex = 1;
            cboTipo.SelectedIndex = 0;
            cboCancelada.SelectedIndex = 0;
            calculaTotal();
        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {
            verificarGuardar();
            string condicion;
            if (!string.IsNullOrEmpty(txtIdCliente.Text))
            {
                condicion = string.Format("ID_CLIENTE = {0}", txtIdCliente.Text);
            }
            else
            {
                condicion = string.Format("ID_CLIENTE = {0}", "-1");
            }
            CargarListaReservacionesDataSet(condicion);
        }//txtIdCliente_TextChanged


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void formatoMoneda(TextBox xTBox)
        {
            if (xTBox.Text == string.Empty)
            {
                return;
            }
            else
            {
                decimal monto;
                monto = Convert.ToDecimal(xTBox.Text);
                xTBox.Text = monto.ToString("N2");
            }
        }

        private void txtTotalPagar_TextChanged(object sender, EventArgs e)
        {
            formatoMoneda(txtTotalPagar);
        }

        //Mostrar las reservaciones de un Cliente en el DataGridView

        private void CargarListaReservacionesDataSet(string condicion = "")
        {
            //carga el datagridview con el dataset
            DAReservaciones logica = new DAReservaciones(Configuracion.getConnectionString);
            DataSet DSReservaciones;

            try
            {
                DSReservaciones = logica.ListarReservacionesCliente(condicion);
                grdLista.DataSource = DSReservaciones;
                grdLista.DataMember = DSReservaciones.Tables["Reservaciones"].TableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }// fin CargarListaReservacionesDataSet


        private EntidadReservacion GenerarEntidadReservacion()
        {
            EntidadReservacion reservacion = new EntidadReservacion();
            if (!string.IsNullOrEmpty(txtIdCliente.Text))
            {
                reservacion.Idcliente = Convert.ToInt32(txtIdCliente.Text);
                reservacion.Fingreso = dtpFIngreso.Value;
                reservacion.Fsalida = dtpFSalida.Value;
                reservacion.CantPersonas = Convert.ToInt32(cboCPersonas.Text);
                reservacion.TipoHab = cboTipo.Text;
                reservacion.PrecioNoche = Convert.ToInt32(txtPrecioNoche.Text);
                if (cboCancelada.SelectedItem.ToString() == "PENDIENTE")
                {
                    reservacion.Cancelado = false;
                }
                else {
                    reservacion.Cancelado = true;
                }
                reservacion.Totalpagar = Convert.ToDouble(txtTotalPagar.Text);
            }
            return reservacion;
        }//fin GenerarEntidadReservacion

        private void btnGuardarReservacion_Click(object sender, EventArgs e)
        {
            BLReservaciones logica = new BLReservaciones(Configuracion.getConnectionString);
            EntidadReservacion reservacion;
            int resultado;
            try
            {
                if (!string.IsNullOrEmpty(txtIdCliente.Text))
                {
                    reservacion = GenerarEntidadReservacion();
                    resultado = logica.InsertarReservacionCliente(reservacion);
                    MessageBox.Show("Reservación agregada", "Información",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else{
                    MessageBox.Show("Los datos son obligatorios", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }//btnGuardarReservacion_Click


    }//public partial class FrmClientesReservaciones : Form
}//namespace InterfazEscritorio
