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
    public partial class FrmCertificacion : Form {
        public FrmCertificacion() {
            InitializeComponent();
        }
        //Variables globales
        string vgn_id;
        EntidadCertificacion datoRegistrado;

        //creamos un formulario de la busqueda para poder entrar a los event handler
        FrmBuscarIdioma formularioBuscar;
        private void GrdNotaMateria_DoubleClick(object sender, EventArgs e) {

        }

        private void BtnGuardar_Click(object sender, EventArgs e) {

        }

        private void FrmCertificacion_Load(object sender, EventArgs e) {

        }

        private void BtnBuscar_Click(object sender, EventArgs e) {

        }

        private void BtnNuevo_Click(object sender, EventArgs e) {

        }

        private void BtnEliminar_Click(object sender, EventArgs e) {

        }

        private void BtnSalir_Click(object sender, EventArgs e) {
            Close();
        }




        //Metodos-------------------------------------


        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-Principal
        private void CargarCertificacion(string id) {

            EntidadCertificacion certificacion = new EntidadCertificacion();
            BLCerticacion traerDato = new BLCerticacion(Configuracion.getConnectionString);

            try {
                certificacion = traerDato.ObtenerCertificacion(id);

                if (certificacion != null) {
                    txtIdCertificado.Text = certificacion.Id_certificado;
                    txtIdProfesor.Text = certificacion.Id_profesor.ToString();
                    txtMateria.Text = certificacion.Materia;

                    datoRegistrado = certificacion;
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

                string id1 = id.ToString();
                CargarCertificacion(id1);
                //Desabhilitamos el CODIGO para que no pueda ser cambiado
                txtIdCertificado.Enabled = false;


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------




        //Muestra que dato se seleccionó y lo puede mostrar o guardar

        private void Seleccionar() {

            if (GrdCertificacion.SelectedRows.Count > 0) {
                vgn_id = (string)GrdCertificacion.SelectedRows[0].Cells[0].Value;
                Aceptar(vgn_id, null);
                txtIdCertificado.Enabled = false;
            }
        }//--------------------------



        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLCerticacion logica = new BLCerticacion(Configuracion.getConnectionString);
            DataSet DS;


            try {
                DS = logica.ListarCertificacion(condicion, orden);

                GrdCertificacion.DataSource = DS;
                GrdCertificacion.DataMember = DS.Tables["Certificacion"].TableName;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------


        public void Limpiar() {
            txtIdCertificado.Text = string.Empty;
            txtIdProfesor.Text = string.Empty;
            txtMateria.Text = string.Empty;

            if (!txtIdCertificado.Enabled) {
                txtIdCertificado.Enabled = true;
            }
        }//-----------------



        //Generar Entidad
        public EntidadCertificacion GenerarEntidad() {

            EntidadCertificacion certificacion;
            if (txtIdCertificado.Enabled) {

                certificacion = new EntidadCertificacion();

            }
            else {
                certificacion = datoRegistrado;
            }

            certificacion.Id_certificado = txtIdCertificado.Text;

            certificacion.Id_profesor =int.Parse( txtIdProfesor.Text);

            certificacion.Materia = txtMateria.Text;    

            return certificacion;
        }//---------------------------------









    }
}
