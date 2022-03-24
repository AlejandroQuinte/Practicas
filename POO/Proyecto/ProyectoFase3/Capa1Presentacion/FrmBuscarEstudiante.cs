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
    public partial class FrmBuscarEstudiante : Form {
        public FrmBuscarEstudiante() {
            InitializeComponent();
        }

        //Creamos un event handler para enviar valores al frmIdiomas
        public event EventHandler BuscarEstudiante;

        //Variable global para accederla de todos los metodos de la clase
        int vgn_idEstudiante; //vgn = Variable Global Numerica 

        private void TxtNombreIdioma_KeyUp(object sender, KeyEventArgs e) {

            string condicion = string.Format("Nombre like '%{0}%'", TxtNombreEstudiante.Text);

            CargarListaDataSet(condicion);


        }


        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLEstudiante logica = new BLEstudiante(Configuracion.getConnectionString);
            DataSet DS;


            try {
                DS = logica.ListarEstudiante(condicion, orden);

                GrdEstudiante.DataSource = DS;
                GrdEstudiante.DataMember = DS.Tables["Estudiantes"].TableName;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------

        //Este seleccionar enviara la informacion hacia la tabla FRMIDIOMAS
        private void Seleccionar() {

            if (GrdEstudiante.SelectedRows.Count > 0) {
                vgn_idEstudiante =(int)GrdEstudiante.SelectedRows[0].Cells[0].Value;
                CargarEstudiante(vgn_idEstudiante);


            }
        }//--------------------------

        private void CargarEstudiante(int id) {

            EntidadEstudiante estudiante = new EntidadEstudiante();
            BLEstudiante traerIdioma = new BLEstudiante(Configuracion.getConnectionString);
            estudiante = traerIdioma.ObtenerEstudiante(id);
            try {
                TxtNombreEstudiante.Text = estudiante.Nombre;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }//---------------------------

        private void BtnAceptar_Click(object sender, EventArgs e) {
            //revisamos que el vgn_id no0 este vacio, sucede que cuando uno abre la nueva pagina
            //el dataGridView aparece seleccionado el primer elemento y si das en aceptar sucederá un error
            //entonces arrglamos el problema dandole el primer valor que siempre seleciona con solo abrir el dato

            if (vgn_idEstudiante==0) {
                vgn_idEstudiante = (int)GrdEstudiante.Rows[0].Cells[0].Value;
            }

            BuscarEstudiante(vgn_idEstudiante, null);
            Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            FrmEstudiante frmEstudiante = new FrmEstudiante();
            frmEstudiante.ShowDialog();
        }

        private void FrmBuscarEstudiante_Load(object sender, EventArgs e) {
            CargarListaDataSet();
        }

        private void GrdEstudiante_DoubleClick(object sender, EventArgs e) {
            Seleccionar();
        }

        private void BtnCancelar_Click(object sender, EventArgs e) {
            Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e) {

        }
    }
}
