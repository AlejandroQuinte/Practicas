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
    public partial class FrmEstudiante : Form {
        public FrmEstudiante() {
            InitializeComponent();
        }
        //creamos un event handler
        public event EventHandler BuscarEstudiante;
        //Variables globales
        int vgn_id;
        EntidadEstudiante datoRegistrado;

        private void GrdEstudiante_DoubleClick(object sender, EventArgs e) {
            Seleccionar();
        }

        private void FrmEstudiante_Load(object sender, EventArgs e) {
            CargarListaDataSet();
        }

        private void BtnGuardar_Click(object sender, EventArgs e) {
            EntidadEstudiante estudiante = new EntidadEstudiante();
            BLEstudiante logica = new BLEstudiante(Configuracion.getConnectionString);

            int resultado;
            int resultadoM = 0;

            try {
                //Se hace el llamado de generarEntidad, para poder jalar los datos del formulario
                //hacia la entidad y luego mover esa misma entidad con los datos correctos
                if ( string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido1.Text)
                    || string.IsNullOrEmpty(TxtApellido2.Text) || string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(txtTelefono.Text)) {
                    MessageBox.Show("Debe llenar los cuadros corresponientes", "Alerta");
                }
                else {
                    estudiante = GenerarEntidad();

                    if (txtIdEstudiante.Text!="") {
                        resultadoM = logica.Modificar(estudiante);
                        if (resultadoM == 1) {
                            MessageBox.Show("Modificacion realizada de forma exitosa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }else{
                            MessageBox.Show("Error, no se pudo MODIFICAR");
                        }

                    }
                    else {
                        resultado = logica.Insertar(estudiante);
                        if (resultado==0) {

                            MessageBox.Show(logica.mensaje);
                        }
                        else {
                            if (resultadoM == 0) {
                                MessageBox.Show("Insertado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Limpiar();
                            }

                        }

                    }


                }


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //para que vuelva a cargar el DataGridView
            CargarListaDataSet();
        }//---------------------------------------

        private void BtnBuscar_Click(object sender, EventArgs e) {

        }

        private void BtnNuevo_Click(object sender, EventArgs e) {
            Limpiar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e) {
            EntidadEstudiante estudiante;
            int resultado;
            BLEstudiante logica = new BLEstudiante(Configuracion.getConnectionString);

            try {
                if (!string.IsNullOrEmpty(txtIdEstudiante.Text)) {
                    //Busca primero el idioma antes de borrarlo para ver si existe
                    resultado = Convert.ToInt32(txtIdEstudiante.Text);
                    estudiante = logica.ObtenerEstudiante(resultado);

                    if (estudiante != null) {
                        //si el cliente es nulo, existe por lo que se puede borrar

                        resultado = logica.EliminarEstudiante(estudiante);
                        MessageBox.Show("Estudiante Eliminado Correctamente");
                        Limpiar();
                        CargarListaDataSet();

                    }
                    else {
                        MessageBox.Show("El Estudiante no existe", "Aviso", MessageBoxButtons.OK);
                        Limpiar();
                        CargarListaDataSet();
                    }

                }
                else {
                    MessageBox.Show("Debe seleccionar un Estudiante antes de eliminarlo", "Aviso", MessageBoxButtons.OK);
                }


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            Limpiar();
        }//---------------------------------------------------

        private void BtnSalir_Click(object sender, EventArgs e) {
            Close();
        }








        //Metodos-------------------------------------

        public void Limpiar() {
            txtIdEstudiante.Text = string.Empty;
            txtNombre.Text = string.Empty;
            TxtApellido2.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;


            if (!txtIdEstudiante.Enabled) {
                //txtIdEstudiante.Enabled = true;
            }
        }//-----------------

        //Evalua si el numero se encuentra mayor a 100 cuando se suelta la tecla
        public void muyGrande(TextBox num) {
            double n = 0;
            double.TryParse(num.Text, out n);
            if (n > 100) {
                MessageBox.Show("La nota no puede ser mayor a 100", "Nota fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Error);
                num.Text = String.Empty;
            }
        }

        //Evalua que letras se meten, solo permitirá numeros
        public void validarEntrada(object sender, KeyPressEventArgs e) {
            //Permitimos la entrada de numeros comas y borrado
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 44) {

                e.Handled = false;

            }
            else {
                e.Handled = true;//cancela el evento /presionar la tecla
            }
        }//--------------------------------------


        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-Principal
        private void CargarEstudiante(int id) {

            EntidadEstudiante estudiante = new EntidadEstudiante();
            BLEstudiante traerDato = new BLEstudiante(Configuracion.getConnectionString);

            try {
                estudiante = traerDato.ObtenerEstudiante(id);

                if (estudiante != null) {
                    txtIdEstudiante.Text = estudiante.Identificacion.ToString();
                    txtNombre.Text = estudiante.Nombre;
                    txtApellido1.Text = estudiante.Apellido1;
                    TxtApellido2.Text = estudiante.Apellido2;
                    txtCorreo.Text = estudiante.Correo;
                    txtTelefono.Text = estudiante.Telefono.ToString();

                    datoRegistrado = estudiante;
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
                CargarEstudiante(id1);
                //Desabhilitamos el CODIGO para que no pueda ser cambiado
                txtIdEstudiante.Enabled = false;


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------




        //Muestra que dato se seleccionó y lo puede mostrar o guardar

        private void Seleccionar() {

            if (GrdEstudiante.SelectedRows.Count > 0) {
                vgn_id = (int)GrdEstudiante.SelectedRows[0].Cells[0].Value;
                Aceptar(vgn_id, null);
                txtIdEstudiante.Enabled = false;
            }
        }//--------------------------



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



        //Generar Entidad
        public EntidadEstudiante GenerarEntidad() {

            EntidadEstudiante estudiante =new EntidadEstudiante(); 
            if (string.IsNullOrEmpty(txtIdEstudiante.Text)) {

                estudiante = new EntidadEstudiante();

            }
            else {
                estudiante = datoRegistrado;
            }

            if(string.IsNullOrEmpty(txtIdEstudiante.Text)){
                estudiante.Identificacion = 1;
            }else{
                estudiante.Identificacion = Convert.ToInt32(txtIdEstudiante.Text);
            }
            
            estudiante.Nombre = txtNombre.Text;
            estudiante.Apellido1 = txtApellido1.Text;
            estudiante.Apellido2 = TxtApellido2.Text;
            estudiante.Correo = txtCorreo.Text;
            estudiante.Telefono = int.Parse(txtTelefono.Text);

            return estudiante;
        }//---------------------------------

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e) {
            validarEntrada(sender, e);
        }












        //--
    }
}
