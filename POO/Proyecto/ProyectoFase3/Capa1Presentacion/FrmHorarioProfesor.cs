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
    public partial class FrmHorarioProfesor : Form {
        public FrmHorarioProfesor() {
            InitializeComponent();
        }
        //Variables globales
        string vgn_id;
        EntidadHorarioProfesor datoRegistrado;

        //creamos un formulario de la busqueda para poder entrar a los event handler
        FrmBuscarIdioma formularioBuscar;
        private void GrdClaseSincronica_DoubleClick(object sender, EventArgs e) {

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

        private void FrmHorarioProfesor_Load(object sender, EventArgs e) {

        }




        


        //Metodos-------------------------------------


        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-Principal
        private void CargarHorarioProfesor(int id) {

            EntidadHorarioProfesor horarioProfesor = new EntidadHorarioProfesor();
            BLHorarioProfesor traerDato = new BLHorarioProfesor(Configuracion.getConnectionString);

            try {
                horarioProfesor = traerDato.ObtenerHorarioProfesor(id);

                if (horarioProfesor != null) {
                    txtIdHorarioProfesor.Text = horarioProfesor.Id_horarioProfesor.ToString();
                    txtIdProfesor.Text = horarioProfesor.Id_profesor.ToString();
                    txtHoraInicio.Text = horarioProfesor.HoraInicio;
                    txtHoraFinal.Text = horarioProfesor.HoraFinal;
                    txtFechaInicio.Text = horarioProfesor.FechaInicio;
                    txtFechaFinal.Text = horarioProfesor.FechaFinal;
                    txtEstado.Text = horarioProfesor.Estado;

                    datoRegistrado = horarioProfesor;
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
                CargarHorarioProfesor(id1);
                //Desabhilitamos el CODIGO para que no pueda ser cambiado
                txtIdHorarioProfesor.Enabled = false;


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------




        //Muestra que dato se seleccionó y lo puede mostrar o guardar

        private void Seleccionar() {

            if (GrdHorarioProfesor.SelectedRows.Count > 0) {
                vgn_id = (string)GrdHorarioProfesor.SelectedRows[0].Cells[0].Value;
                Aceptar(vgn_id, null);
                txtIdHorarioProfesor.Enabled = false;
            }
        }//--------------------------



        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLHorarioProfesor logica = new BLHorarioProfesor(Configuracion.getConnectionString);
            DataSet DS;


            try {
                DS = logica.ListarHorarioProfesor(condicion, orden);

                GrdHorarioProfesor.DataSource = DS;
                GrdHorarioProfesor.DataMember = DS.Tables["HorarioProfesor"].TableName;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------


        public void Limpiar() {
            txtIdHorarioProfesor.Text = string.Empty;
            txtIdProfesor.Text = string.Empty;
            txtHoraFinal.Text = string.Empty;
            txtHoraInicio.Text = string.Empty;
            txtFechaFinal.Text = string.Empty;
            txtFechaInicio.Text = string.Empty;
            txtEstado.Text = string.Empty;

            if (!txtIdHorarioProfesor.Enabled) {
                txtIdHorarioProfesor.Enabled = true;
            }
        }//-----------------



        //Generar Entidad
        public EntidadHorarioProfesor GenerarEntidad() {

            EntidadHorarioProfesor horarioProfesor;
            if (txtIdHorarioProfesor.Enabled) {

                horarioProfesor = new EntidadHorarioProfesor();

            }
            else {
                horarioProfesor = datoRegistrado;
            }

            horarioProfesor.Id_horarioProfesor = int.Parse(txtIdHorarioProfesor.Text);
            horarioProfesor.Id_profesor = int.Parse(txtIdProfesor.Text);
            horarioProfesor.HoraInicio = txtHoraInicio.Text;
            horarioProfesor.HoraFinal = txtHoraFinal.Text;
            horarioProfesor.FechaInicio = txtFechaFinal.Text;
            horarioProfesor.FechaFinal = txtFechaFinal.Text;
            horarioProfesor.Estado = txtEstado.Text;


            return horarioProfesor;
        }//---------------------------------










    }
}
