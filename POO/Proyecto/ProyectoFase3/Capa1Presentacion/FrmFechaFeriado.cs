using Capa2LogicaNegocio;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Capa1Presentacion {
    public partial class FrmFechaFeriado : Form {
        public FrmFechaFeriado() {
            InitializeComponent();
        }

        //Variables globales
        string vgn_id;
        EntidadFechaFeriado datoRegistrado;

        //creamos un formulario de la busqueda para poder entrar a los event handler
        FrmBuscarIdioma formularioBuscar;


        private void GrdFechaFeriado_DoubleClick(object sender, EventArgs e) {

        }

        private void FrmFechaFeriado_Load(object sender, EventArgs e) {
            CargarListaDataSet();
        }

        private void BtnGuardar_Click(object sender, EventArgs e) {
            calcularFecha();

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


        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-idioma
        private void CargarFechaFeriado(string id) {

            EntidadFechaFeriado fechaFeriado = new EntidadFechaFeriado();
            BLFechaFeriado traerDato = new BLFechaFeriado(Configuracion.getConnectionString);

            try {
                fechaFeriado = traerDato.ObtenerFechaFeriado(id);

                if (fechaFeriado != null) {
                    txtIdFecha.Text = fechaFeriado.Id_fecha;
                    //DTFechaFeriado = DateTime.Parse(fechaFeriado.Fecha);
                    txtMotivo.Text = fechaFeriado.Motivo;

                    datoRegistrado = fechaFeriado;
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
                CargarFechaFeriado(id1);
                //Desabhilitamos el CODIGO para que no pueda ser cambiado
                txtIdFecha.Enabled = false;


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------




        //Muestra que dato se seleccionó y lo puede mostrar o guardar

        private void Seleccionar() {

            if (GrdFechaFeriado.SelectedRows.Count > 0) {
                vgn_id = (string)GrdFechaFeriado.SelectedRows[0].Cells[0].Value;
                Aceptar(vgn_id, null);
                txtIdFecha.Enabled = false;
            }
        }//--------------------------



        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLFechaFeriado logica = new BLFechaFeriado(Configuracion.getConnectionString);
            DataSet DS;


            try {
                DS = logica.ListarFechaFeriado(condicion, orden);

                GrdFechaFeriado.DataSource = DS;
                GrdFechaFeriado.DataMember = DS.Tables["FechaFeriados"].TableName;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------


        public void Limpiar() {
            txtIdFecha.Text = string.Empty;
            txtMotivo.Text = string.Empty;

            if (!txtIdFecha.Enabled) {
                txtIdFecha.Enabled = true;
            }
        }//-----------------



        //Generar Entidad
        public EntidadFechaFeriado GenerarEntidad() {

            EntidadFechaFeriado fechaFeriado;
            if (txtIdFecha.Enabled) {

                fechaFeriado = new EntidadFechaFeriado();

            }
            else {
                fechaFeriado = datoRegistrado;
            }

            fechaFeriado.Id_fecha = txtIdFecha.Text;

            fechaFeriado.Motivo = txtMotivo.Text;

            return fechaFeriado;
        }//---------------------------------







        //Metodo para que la fecha de ingreso no sea menor a hoy

        private void calcularFecha(){
            if(DTFechaFeriado.Value.Date < DateTime.Now.Date){
                MessageBox.Show("La fecha de ingreso no puede ser menor a hoy");

            }
            DTFechaFeriado.Value.AddDays(2);
            int cant = (int)(DTFechaFeriado.Value - DateTime.Now.Date).TotalDays;
            int num = (int)(DTFechaFeriado.Value - DateTime.Now.Date).TotalDays;
            DateTime fechaPosterior = DTFechaFeriado.Value.AddDays(2);
            txtMotivo.Text = DTFechaFeriado.Value.AddDays(2).ToString();


        }



















    }
}
