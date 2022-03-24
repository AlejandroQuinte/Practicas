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
    public partial class FrmProfesor : Form {
        public FrmProfesor() {
            InitializeComponent();
        }
        //Variables globales
        int vgn_id;
        EntidadProfesor datoRegistrado;

        //creamos un formulario de la busqueda para poder entrar a los event handler
        FrmBuscarIdioma formularioBuscar;
        private void GrdProfesor_DoubleClick(object sender, EventArgs e) {
            Seleccionar();
        }
        private void FrmProfesor_Load(object sender, EventArgs e) {
            CargarListaDataSet();
        }

        private void BtnGuardar_Click(object sender, EventArgs e) {
            EntidadProfesor profesor = new EntidadProfesor();
            BLProfesor logica = new BLProfesor(Configuracion.getConnectionString);

            int resultado;
            int resultadoM = 0;

            try {
                //Se hace el llamado de generarEntidad, para poder jalar los datos del formulario
                //hacia la entidad y luego mover esa misma entidad con los datos correctos
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido1.Text)
                    || string.IsNullOrEmpty(TxtApellido2.Text) || string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(txtTelefono.Text)) {
                    MessageBox.Show("Debe llenar los cuadros corresponientes", "Alerta");
                }
                else {
                    profesor = GenerarEntidad();

                    if (txtIdProfesor.Text != "") {
                        resultadoM = logica.Modificar(profesor);
                        if (resultadoM == 1) {
                            MessageBox.Show("Modificacion realizada de forma exitosa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else {
                            MessageBox.Show("Error, no se pudo MODIFICAR");
                        }

                    }
                    else {
                        resultado = logica.Insertar(profesor);
                        if (resultado == 0) {

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
        }//-------------------------------------------------

        private void BtnBuscar_Click(object sender, EventArgs e) {

        }//----------------------------------------

        private void BtnNuevo_Click(object sender, EventArgs e) {
            Limpiar();
        }//---------------------------------------

        private void BtnEliminar_Click(object sender, EventArgs e) {
            EntidadProfesor profesor;
            int resultado;
            BLProfesor logica = new BLProfesor(Configuracion.getConnectionString);

            try {
                if (!string.IsNullOrEmpty(txtIdProfesor.Text)) {
                    //Busca primero el idioma antes de borrarlo para ver si existe
                    resultado = Convert.ToInt32(txtIdProfesor.Text);
                    profesor = logica.ObtenerProfesor(resultado);

                    if (profesor != null) {
                        //si el cliente es nulo, existe por lo que se puede borrar

                        resultado = logica.EliminarProfesor(profesor);
                        MessageBox.Show("Profesor Eliminado Correctamente");
                        Limpiar();
                        CargarListaDataSet();

                    }
                    else {
                        MessageBox.Show("El Profesor no existe", "Aviso", MessageBoxButtons.OK);
                        Limpiar();
                        CargarListaDataSet();
                    }

                }
                else {
                    MessageBox.Show("Debe seleccionar un Profesor antes de eliminarlo", "Aviso", MessageBoxButtons.OK);
                }


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            Limpiar();
        }//-----------------------------------------

        private void BtnSalir_Click(object sender, EventArgs e) {
            Close();
        }//------------------------------------


        //Metodos-------------------------------------


        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-Principal
        private void CargarProfesor(int id) {

            EntidadProfesor profesor = new EntidadProfesor();
            BLProfesor traerDato = new BLProfesor(Configuracion.getConnectionString);

            try {
                profesor = traerDato.ObtenerProfesor(id);

                if (profesor != null) {
                    txtIdProfesor.Text = profesor.Identificacion.ToString();
                    txtNombre.Text = profesor.Nombre;
                    txtApellido1.Text = profesor.Apellido1;
                    TxtApellido2.Text = profesor.Apellido2;
                    txtCorreo.Text = profesor.Correo;
                    txtTelefono.Text = profesor.Telefono.ToString();

                    datoRegistrado = profesor;
                }
                else {
                    MessageBox.Show("El Dato no se encuentra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//---------------------------

        //Implementa el evento ACEPTAR, este recibe un id el cual se manda desde frmBuscar
        // y se usa en frmCliente para cargar los datos de los clientes
        private void Aceptar(object id, EventArgs e) {

            try {

                int id1 = (int)id;
                CargarProfesor(id1);


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------




        //Muestra que dato se seleccionó y lo puede mostrar o guardar

        private void Seleccionar() {

            if (GrdProfesor.SelectedRows.Count > 0) {
                vgn_id = Convert.ToInt32( GrdProfesor.SelectedRows[0].Cells[0].Value);
                Aceptar(vgn_id, null);
                
            }
        }//--------------------------



        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLProfesor logica = new BLProfesor(Configuracion.getConnectionString);
            DataSet DS;


            try {
                DS = logica.ListarProfesor(condicion, orden);

                GrdProfesor.DataSource = DS;
                GrdProfesor.DataMember = DS.Tables["Profesores"].TableName;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------


        public void Limpiar() {
            txtIdProfesor.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            TxtApellido2.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;

            if (!txtIdProfesor.Enabled) {
                txtIdProfesor.Enabled = true;
            }
        }//-----------------



        //Generar Entidad
        public EntidadProfesor GenerarEntidad() {

            EntidadProfesor profesor ;
            if (string.IsNullOrEmpty(txtIdProfesor.Text)) {

                profesor = new EntidadProfesor();

            }
            else {
                profesor = datoRegistrado;
            }

            if (string.IsNullOrEmpty(txtIdProfesor.Text)) {
                profesor.Identificacion = 1;
            }
            else {
                profesor.Identificacion = Convert.ToInt32(txtIdProfesor.Text);
            }

            profesor.Nombre = txtNombre.Text;
            profesor.Apellido1 = txtApellido1.Text;
            profesor.Apellido2 = TxtApellido2.Text;
            profesor.Correo = txtCorreo.Text;
            profesor.Telefono = int.Parse(txtTelefono.Text);

            return profesor;
        }//---------------------------------

        
    }
}
