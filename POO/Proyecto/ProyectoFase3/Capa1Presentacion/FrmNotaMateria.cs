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
    public partial class FrmNotaMateria : Form {
        public FrmNotaMateria() {
            InitializeComponent();
        }
        //Variables globales
        string vgn_id;
        EntidadNotaMateria datoRegistrado;

        //creamos un formulario de la busqueda para poder entrar a los event handler
        FrmBuscarIdioma formularioBuscar;

        private void FrmNotaMateria_Load(object sender, EventArgs e) {

        }

        private void GrdNotaMateria_DoubleClick(object sender, EventArgs e) {

        }

        private void BtnGuardar_Click(object sender, EventArgs e) {

        }

        private void BtnBuscar_Click(object sender, EventArgs e) {

        }

        private void BtnNuevo_Click(object sender, EventArgs e) {

        }

        private void BtnEliminar_Click(object sender, EventArgs e) {

        }

        private void BtnSalir_Click(object sender, EventArgs e) {

        }






        //Metodos-------------------------------------


        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-Principal
        private void CargarNotaMateria(int id) {

            EntidadNotaMateria notaMateria = new EntidadNotaMateria();
            BLNotaMateria traerDato = new BLNotaMateria(Configuracion.getConnectionString);

            try {
                notaMateria = traerDato.ObtenerMateria(id);

                if (notaMateria != null) {
                    txtIdNota.Text = notaMateria.Id_nota.ToString();
                    txtNota.Text = notaMateria.Nota.ToString();
                    txtEstado.Text = notaMateria.Estado;

                    datoRegistrado = notaMateria;
                }
                else {
                    MessageBox.Show("El Dato no se encuentra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//---------------------------

        //Implementa el evento ACEPTAR, este recibe un id el cual se manda desde frmBuscar
        // y se usa en frmCliente para cargar los datos de los clientes
        private void Aceptar(object id, EventArgs e) {

            try {

                int id1 = (int)id;
                CargarNotaMateria(id1);
                //Desabhilitamos el CODIGO para que no pueda ser cambiado
                txtIdNota.Enabled = false;


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------




        //Muestra que dato se seleccionó y lo puede mostrar o guardar

        private void Seleccionar() {

            if (GrdNotaMateria.SelectedRows.Count > 0) {
                vgn_id = (string)GrdNotaMateria.SelectedRows[0].Cells[0].Value;
                Aceptar(vgn_id, null);
                txtIdNota.Enabled = false;
            }
        }//--------------------------



        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLCerticacion logica = new BLCerticacion(Configuracion.getConnectionString);
            DataSet DS;


            try {
                DS = logica.ListarCertificacion(condicion, orden);

                GrdNotaMateria.DataSource = DS;
                GrdNotaMateria.DataMember = DS.Tables["Notas"].TableName;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------


        public void Limpiar() {
            txtIdNota.Text = string.Empty;
            txtNota.Text = string.Empty;
            txtEstado.Text = string.Empty;

            if (!txtIdNota.Enabled) {
                txtIdNota.Enabled = true;
            }
        }//-----------------



        //Generar Entidad
        public EntidadNotaMateria GenerarEntidad() {

            EntidadNotaMateria notaMateria;
            if (txtIdNota.Enabled) {

                notaMateria = new EntidadNotaMateria();

            }
            else {
                notaMateria = datoRegistrado;
            }

            notaMateria.Id_nota = int.Parse(txtIdNota.Text);

            notaMateria.Nota = int.Parse(txtNota.Text);

            notaMateria.Estado = txtEstado.Text;

            return notaMateria;
        }//---------------------------------






    }
}
