using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa2LogicaNegocio;
using CapaEntidades;

namespace Capa1Presentacion {
    public partial class FrmIdiomas : Form {
        public FrmIdiomas() {
            InitializeComponent();
        }//--------------

        //Variables globales
        string vgn_idIdioma;
        EntidadIdioma IdiomaRegistrado;

        //creamos un formulario de la busqueda para poder entrar a los event handler
        FrmBuscarIdioma formularioBuscarIdioma;


        //
        private void BtnBuscar_Click(object sender, EventArgs e) {
            formularioBuscarIdioma = new FrmBuscarIdioma();
            //se especifica que se requiere usar el evento aceptar creado en el FrmBuscarIdioma
            formularioBuscarIdioma.Aceptar += new EventHandler(Aceptar);
            formularioBuscarIdioma.ShowDialog();
            
        }//-------------------------

        
        


        //Generar Entidad
        public EntidadIdioma GenerarEntidadIdioma() {

            EntidadIdioma idioma;
            if(TxtIdIdioma.Enabled){
                
                idioma = new EntidadIdioma();

            }else{
                idioma = IdiomaRegistrado;
            }

            idioma.IdIdioma = TxtIdIdioma.Text;
            idioma.NombreIdioma = TxtNombreIdioma.Text;

            return idioma;
        }//---------------------------------


        private void BtnGuardar_Click(object sender, EventArgs e) {
            EntidadIdioma idioma = new EntidadIdioma();
            BLIdioma logica = new BLIdioma(Configuracion.getConnectionString);

            string resultado;
            int resultadoM=0;

            try{
            //Se hace el llamado de generarEntidad, para poder jalar los datos del formulario
            //hacia la entidad y luego mover esa misma entidad con los datos correctos
                if(string.IsNullOrEmpty(TxtIdIdioma.Text) || string.IsNullOrEmpty(TxtNombreIdioma.Text)){
                    MessageBox.Show("Debe llenar los cuadros corresponientes", "Alerta");
                }else{
                    idioma = GenerarEntidadIdioma();
                    
                    if(idioma.Existe){
                        resultadoM = logica.Modificar(idioma);
                        if (resultadoM != 0) {
                            MessageBox.Show("Modificacion realizada de forma exitosa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        
                    }
                    else{
                        resultado = logica.Insertar(idioma);
                        if(string.IsNullOrEmpty(resultado)){

                            MessageBox.Show(logica.mensaje);
                        }else{
                            if (resultadoM == 0) {
                                MessageBox.Show("Insertado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                        }
                        
                    }
                    
                    
                }
                

            }catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //para que vuelva a cargar el DataGridView
            CargarListaDataSet();
            Limpiar();

        }//---------------------------

        public void Limpiar(){
            TxtIdIdioma.Text = string.Empty;
            TxtNombreIdioma.Text = string.Empty;

            if (!TxtIdIdioma.Enabled) {
                TxtIdIdioma.Enabled = true;
            }
        }//-----------------

        private void BtnSalir_Click(object sender, EventArgs e) {
            Close();
        }//-------------------



        private void FrmIdiomas_Load(object sender, EventArgs e) {
            
            try{

                CargarListaDataSet();

            }catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }//------------------------------------

        private void CargarListaDataSet(string condicion ="",string orden=""){

            //cargar el datagridview con los datos del dataset
            BLIdioma logica = new BLIdioma(Configuracion.getConnectionString);
            DataSet DSIdioma;


           try{
                DSIdioma = logica.ListarIdiomas(condicion,orden);

                GrdIdiomas.DataSource = DSIdioma;
                GrdIdiomas.DataMember = DSIdioma.Tables["Idiomas"].TableName;
               
           }catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }

        }//------------------------------



        //Muestra que dato se seleccionó y lo puede mostrar o guardar

        private void Seleccionar() {

            if (GrdIdiomas.SelectedRows.Count >0) {
                vgn_idIdioma = (string)GrdIdiomas.SelectedRows[0].Cells[0].Value;
                Aceptar(vgn_idIdioma,null);
                TxtIdIdioma.Enabled = false;
            }
        }//--------------------------


        //Implementa el evento ACEPTAR, este recibe un id el cual se manda desde frmBuscar
        // y se usa en frmCliente para cargar los datos de los clientes
        private void Aceptar(object id, EventArgs e){
            
            try{
               
                string id1 = id.ToString();
                CargarIdioma(id1);
                //Desabhilitamos el CODIGO para que no pueda ser cambiado
                TxtIdIdioma.Enabled = false;


            } catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------


        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-idioma
        private void CargarIdioma(string id){

            EntidadIdioma idioma = new EntidadIdioma();
            BLIdioma traerIdioma = new BLIdioma(Configuracion.getConnectionString);

            try{
                idioma = traerIdioma.ObtenerIdioma(id);
                
                if (idioma != null){
                    TxtIdIdioma.Text = idioma.IdIdioma;
                    TxtNombreIdioma.Text = idioma.NombreIdioma;

                    IdiomaRegistrado = idioma;
                }else{
                    MessageBox.Show("El cliente no se encuentra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                

            } catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//---------------------------

        private void GrdIdiomas_DoubleClick(object sender, EventArgs e) {
            Seleccionar();
            
        }//--------------------------

        private void BtnNuevo_Click(object sender, EventArgs e) {
            Limpiar();
            
        }//---------------------------

        
        private void BtnEliminar_Click(object sender, EventArgs e) {
            EntidadIdioma idioma;
            int resultado;
            BLIdioma logica = new BLIdioma(Configuracion.getConnectionString);

            try{    
                if(!string.IsNullOrEmpty(TxtIdIdioma.Text)){
                    //Busca primero el idioma antes de borrarlo para ver si existe
                    idioma = logica.ObtenerIdioma(TxtIdIdioma.Text);

                    if(idioma != null){
                        //si el cliente es nulo, existe por lo que se puede borrar

                        resultado = logica.EliminarIdioma(idioma);
                        MessageBox.Show("Idioma Eliminado Correctamente");
                        Limpiar();
                        CargarListaDataSet();

                    }else{
                        MessageBox.Show("El idioma no existe", "Aviso", MessageBoxButtons.OK);
                        Limpiar();
                        CargarListaDataSet();
                    }

                }else{
                    MessageBox.Show("Debe seleccionar un idioma antes de eliminarlo", "Aviso", MessageBoxButtons.OK);
                }
                    

            }catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            Limpiar();
        }//------------------------------

        






































        //
    }
}
