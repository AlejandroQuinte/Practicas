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
    public partial class FrmBuscarIdioma : Form {
        public FrmBuscarIdioma() {
            InitializeComponent();
        }

        //Creamos un event handler para enviar valores al frmIdiomas
        public event EventHandler Aceptar;

        //Variable global para accederla de todos los metodos de la clase
        string vgn_idIdioma; //vgn = Variable Global Numerica 


        private void BtnAceptar_Click(object sender, EventArgs e) {

            //revisamos que el vgn_idioma no0 este vacio, sucede que cuando uno abre la nueva pagina
            //el dataGridView aparece seleccionado el primer elemento y si das en aceptar sucederá un error
            //entonces arrglamos el problema dandole el primer valor que siempre seleciona con solo abrir el dato

            if(string.IsNullOrEmpty(vgn_idIdioma)){
                vgn_idIdioma = (string)GrdIdiomas.Rows[0].Cells[0].Value;
            }
            
            Aceptar(vgn_idIdioma, null);
            Close();

        }

        //Este seleccionar enviara la informacion hacia la tabla FRMIDIOMAS
        private void Seleccionar() {

            if (GrdIdiomas.SelectedRows.Count > 0) {
                vgn_idIdioma = (string)GrdIdiomas.SelectedRows[0].Cells[0].Value;
                CargarIdioma(vgn_idIdioma);
                

            }
        }//--------------------------

        private void CargarIdioma(string id) {

            EntidadIdioma idioma = new EntidadIdioma();
            BLIdioma traerIdioma = new BLIdioma(Configuracion.getConnectionString);
            idioma = traerIdioma.ObtenerIdioma(id);
            try{
                TxtNombreIdioma.Text = idioma.NombreIdioma;
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }//---------------------------

        private void BtnCancelar_Click(object sender, EventArgs e) {
            Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e) {
            //condicion para filtrar los datos y recuperar el idioma deseado
            string condicion = string.Empty;

            try{
                if(string.IsNullOrEmpty(TxtNombreIdioma.Text)){
                    MessageBox.Show("Debe escribir parte del nombre a buscar", "Atencion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtNombreIdioma.Focus();
                }else{
                    //este dato de condicion fue previamente creado en la clase DAIdioma
                    condicion = string.Format("NombreIdioma like '%{0}%'", TxtNombreIdioma.Text);
                }
                CargarListaDataSet(condicion);
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLIdioma logica = new BLIdioma(Configuracion.getConnectionString);
            DataSet DSIdioma;


            try {
                DSIdioma = logica.ListarIdiomas(condicion, orden);

                GrdIdiomas.DataSource = DSIdioma;
                GrdIdiomas.DataMember = DSIdioma.Tables["Idiomas"].TableName;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------

        private void FrmBuscarIdioma_Load(object sender, EventArgs e) {
            try {
                CargarListaDataSet();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrdIdiomas_MouseClick(object sender, MouseEventArgs e) {
            Seleccionar();
        }

        private void GrdIdiomas_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }








































        //----
    }
}
