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
    public partial class FrmCliente : Form {
        public FrmCliente() {
            InitializeComponent();
        }
        //generar entidad
        public EntidadCliente GenerarEntidadCliente() {
            EntidadCliente cliente = new EntidadCliente();
            cliente.setNombre(TxtNombre.Text);
            cliente.setTelefono(TxtTelefono.Text);
            cliente.setDireccion(TxtDireccion.Text);


            return cliente;
        }
        private void BtnGuardar_Click(object sender, EventArgs e) {
            EntidadCliente cliente = new EntidadCliente();
            BLCliente logica = new BLCliente(Configuracion.getConnectionString);//Obtiene la cadena de conexion y se la envia a la capa logica
            int resultado;
            try {
                if (string.IsNullOrEmpty(TxtNombre.Text) || string.IsNullOrEmpty(TxtTelefono.Text) ||
                    string.IsNullOrEmpty(TxtDireccion.Text)) {
                    MessageBox.Show("Datos incompletos, favor, complete todos los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else {
                    cliente = GenerarEntidadCliente();
                    resultado = logica.Insertar(cliente);
                    MessageBox.Show("Operación realizada de forma exitosa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Limpiar() {
            //TxtIdCliente.Text = "";
            TxtNombre.Text = "";
            TxtTelefono.Text = "";
            TxtDireccion.Text = "";
        }

        private void BtnSalir_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
