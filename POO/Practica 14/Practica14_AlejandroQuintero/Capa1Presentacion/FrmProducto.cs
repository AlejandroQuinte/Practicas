using CapaEntidades;
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
    public partial class FrmProducto : Form {
        public FrmProducto() {
            InitializeComponent();
        }
        public EntidadProducto GenerarEntidadProducto(){
            EntidadProducto producto = new EntidadProducto();
            producto.Descripcion = TxtDescripcion.Text;
            producto.PrecioVenta = float.Parse(txtPrecioVenta.Text);
            producto.PrecioCompra = float.Parse(txtPrecioCompra.Text);

            if(CHGravado.Checked){
                producto.Gravado = "SI";
            }else{
                producto.Gravado = "NO";
            }
            
            return producto;
        }


        private void BtnGuardar_Click(object sender, EventArgs e) {
            EntidadProducto producto = new EntidadProducto();
            BLProducto logica = new BLProducto(Configuracion.getConnectionString);//Obtiene la cadena de conexion y se la envia a la capa logica
            int resultado;
            try {
                if (string.IsNullOrEmpty(TxtDescripcion.Text) || float.IsNaN(float.Parse( txtPrecioCompra.Text)) ||
                    float.IsNaN(float.Parse(txtPrecioVenta.Text))) {
                    MessageBox.Show("Datos incompletos, favor, complete todos los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else {
                    producto = GenerarEntidadProducto();
                    resultado = logica.Insertar(producto);
                    MessageBox.Show("Operación realizada de forma exitosa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Limpiar() {
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            TxtDescripcion.Text = "";
            CHGravado.Checked = false;
        }
    }
}
