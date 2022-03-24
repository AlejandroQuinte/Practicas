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
    public partial class FrmCursosBuscar : Form {
        public FrmCursosBuscar() {
            InitializeComponent();
        }
        //Creamos un event handler para enviar valores al frmIdiomas
        public event EventHandler Aceptar;

        //Variable global para accederla de todos los metodos de la clase
        string vgn_idCurso; //vgn = Variable Global Numerica 

        private void FrmCursosBuscar_Load(object sender, EventArgs e) {
            CargarListaDataSet();
        }

        private void GrdCurso_DoubleClick(object sender, EventArgs e) {
            Seleccionar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e) {
            //condicion para filtrar los datos y recuperar el idioma deseado
            string condicion = string.Empty;

            try {
                if (string.IsNullOrEmpty(TxtNombreCurso.Text)) {
                    MessageBox.Show("Debe escribir parte del nombre a buscar", "Atencion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtNombreCurso.Focus();
                }
                else {
                    //este dato de condicion fue previamente creado en la clase DAIdioma
                    condicion = string.Format("NombreCurso like '%{0}%'", TxtNombreCurso.Text);
                }
                CargarListaDataSet(condicion);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e) {
            //revisamos que el vgn_idioma no0 este vacio, sucede que cuando uno abre la nueva pagina
            //el dataGridView aparece seleccionado el primer elemento y si das en aceptar sucederá un error
            //entonces arrglamos el problema dandole el primer valor que siempre seleciona con solo abrir el dato

            if (string.IsNullOrEmpty(vgn_idCurso)) {
                vgn_idCurso = (string)GrdCurso.Rows[0].Cells[0].Value;
            }

            Aceptar(vgn_idCurso, null);
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e) {
            Close();
        }



        //Este seleccionar enviara la informacion hacia la tabla FRMIDIOMAS
        private void Seleccionar() {

            if (GrdCurso.SelectedRows.Count > 0) {
                vgn_idCurso = (string)GrdCurso.SelectedRows[0].Cells[0].Value;
                CargarCurso(vgn_idCurso);


            }
        }//--------------------------




        private void CargarCurso(string id) {

            EntidadCurso curso = new EntidadCurso();
            BLCurso traerCurso = new BLCurso(Configuracion.getConnectionString);
            curso = traerCurso.ObtenerCurso(id);
            try {
                TxtNombreCurso.Text = curso.NombreCurso;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }//---------------------------


        


        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLCurso logica = new BLCurso(Configuracion.getConnectionString);
            DataSet DSCurso;


            try {
                DSCurso = logica.ListarCursos(condicion, orden);

                GrdCurso.DataSource = DSCurso;
                GrdCurso.DataMember = DSCurso.Tables["Cursos"].TableName;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------

        private void TxtNombreCurso_KeyUp(object sender, KeyEventArgs e) {
            //este dato de condicion fue previamente creado en la clase DAIdioma
            string condicion;
            condicion = string.Format("NombreCurso like '%{0}%'", TxtNombreCurso.Text);
            CargarListaDataSet(condicion);
        }
    }
}
