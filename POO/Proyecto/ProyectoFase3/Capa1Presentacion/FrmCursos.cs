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
    public partial class FrmCursos : Form {
        public FrmCursos() {
            InitializeComponent();
        }

        //Variables globales
        int vg_Retorno;
        string vgn_idCurso;
        EntidadCurso CursoRegistrado;

        //creamos un formulario de la busqueda para poder entrar a los event handler
        FrmCursosBuscar formularioBuscarCurso;


        //
        private void BtnBuscar_Click(object sender, EventArgs e) {
            formularioBuscarCurso = new FrmCursosBuscar();
            //se especifica que se requiere usar el evento aceptar creado en el FrmBuscarIdioma
            formularioBuscarCurso.Aceptar += new EventHandler(Aceptar);
            formularioBuscarCurso.ShowDialog();

        }//-------------------------





        //Generar Entidad
        public EntidadCurso GenerarEntidadCurso() {

            EntidadCurso curso;
            if (txtIdCurso.Enabled) {

                curso = new EntidadCurso();

            }
            else {
                curso = CursoRegistrado;
            }

            curso.Id_curso = txtIdCurso.Text;
            curso.Id_nota = Convert.ToInt32(txtIdNota.Text);
            curso.Id_idioma = txtIdIdioma.Text;
            curso.NombreCurso = TxtNombreCurso.Text;
            curso.CantidadCursos = Convert.ToInt32(txtCantCursos.Text);
            curso.HorasCurso = Convert.ToInt32(txtHorasCurso.Text);
            int horas = Convert.ToInt32(txtHorasCurso.Text);
            curso.HorasSincronicas = (int)(horas / 100) * 25;
            curso.HorasAsincronicas = (int)(horas / 100) * 75;
            curso.Precio = float.Parse(txtPrecio.Text);

            return curso;
        }//---------------------------------


        private void BtnGuardar_Click(object sender, EventArgs e) {
            EntidadCurso curso = new EntidadCurso();
            BLCurso logica = new BLCurso(Configuracion.getConnectionString);

            string resultado;
            int resultadoM = 0;

            try {
                //Se hace el llamado de generarEntidad, para poder jalar los datos del formulario
                //hacia la entidad y luego mover esa misma entidad con los datos correctos
                if (string.IsNullOrEmpty(txtIdCurso.Text) || string.IsNullOrEmpty(txtIdNota.Text)|| string.IsNullOrEmpty(txtCantCursos.Text)
                    || string.IsNullOrEmpty(txtIdIdioma.Text) || string.IsNullOrEmpty(TxtNombreCurso.Text) || string.IsNullOrEmpty(txtHorasCurso.Text)
                        || string.IsNullOrEmpty(txtPrecio.Text)) {
                    MessageBox.Show("Debe llenar los cuadros corresponientes", "Alerta");
                }
                else {
                    curso = GenerarEntidadCurso();

                    if (curso.Existe) {
                        resultadoM = logica.Modificar(curso);
                        if (resultadoM != 0) {
                            MessageBox.Show("Modificacion realizada de forma exitosa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }

                    }
                    else {
                        resultado = logica.Insertar(curso);
                        if (string.IsNullOrEmpty(resultado)) {

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

        }//---------------------------

        public void Limpiar() {
            txtIdCurso.Text = string.Empty;
            txtIdIdioma.Text = string.Empty;
            txtIdNota.Text = string.Empty; 
            TxtNombreCurso.Text = string.Empty;
            txtCantCursos.Text = string.Empty;
            txtHorasCurso.Text = string.Empty;
            txtPrecio.Text = string.Empty;


            if (!txtIdCurso.Enabled) {
                txtIdCurso.Enabled = true;
            }
        }//-----------------

        



        private void BtnSalir_Click(object sender, EventArgs e) {
            Close();
        }//-------------------



        private void FrmIdiomas_Load(object sender, EventArgs e) {

            try {

                CargarListaDataSet();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------------

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



        //Muestra que dato se seleccionó y lo puede mostrar o guardar

        private void Seleccionar() {

            if (GrdCurso.SelectedRows.Count > 0) {
                vgn_idCurso = (string)GrdCurso.SelectedRows[0].Cells[0].Value;
                Aceptar(vgn_idCurso, null);
                txtIdCurso.Enabled = false;
            }
        }//--------------------------


        //Implementa el evento ACEPTAR, este recibe un id el cual se manda desde frmBuscar
        // y se usa en el frmPrincipal para cargar los datos de los clientes
        private void Aceptar(object id, EventArgs e) {

            try {

                CargarCurso(id.ToString());
                //Desabhilitamos el CODIGO para que no pueda ser cambiado
                txtIdCurso.Enabled = false;


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------


        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-idioma
        private void CargarCurso(string id) {

            EntidadCurso curso = new EntidadCurso();
            BLCurso traerCurso = new BLCurso(Configuracion.getConnectionString);

            try {
                curso = traerCurso.ObtenerCurso(id);

                if (curso != null) {
                    txtIdCurso.Text = curso.Id_curso;
                    txtIdIdioma.Text = curso.Id_idioma;
                    txtIdNota.Text = curso.Id_nota.ToString();
                    TxtNombreCurso.Text = curso.NombreCurso;
                    txtCantCursos.Text = curso.CantidadCursos.ToString();
                    txtHorasCurso.Text = curso.HorasCurso.ToString();
                    txtPrecio.Text = curso.Precio.ToString();
                    

                    CursoRegistrado = curso;
                }
                else {
                    MessageBox.Show("El cliente no se encuentra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//---------------------------

        private void BtnNuevo_Click(object sender, EventArgs e) {
            Limpiar();

        }//---------------------------


        private void BtnEliminar_Click(object sender, EventArgs e) {
            EntidadCurso curso;
            int resultado;
            BLCurso logica = new BLCurso(Configuracion.getConnectionString);

            try {
                if (!string.IsNullOrEmpty(txtIdCurso.Text)) {
                    //Busca primero el idioma antes de borrarlo para ver si existe
                    curso = logica.ObtenerCurso(txtIdCurso.Text);

                    if (curso != null) {
                        //si el cliente es nulo, existe por lo que se puede borrar

                        resultado = logica.EliminarCurso(curso);
                        MessageBox.Show("Curso Eliminado Correctamente");
                        Limpiar();
                        CargarListaDataSet();

                    }
                    else {
                        MessageBox.Show("El Curso no existe", "Aviso", MessageBoxButtons.OK);
                        Limpiar();
                        CargarListaDataSet();
                    }

                }
                else {
                    MessageBox.Show("Debe seleccionar un Curso antes de eliminarlo", "Aviso", MessageBoxButtons.OK);
                }


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            Limpiar();
        }//------------------------------

        private void GrdCurso_DoubleClick(object sender, EventArgs e) {
            Seleccionar();
        }

        private void FrmCursos_Load(object sender, EventArgs e) {
            CargarListaDataSet();
        }

        private void txtIdNota_KeyUp(object sender, KeyEventArgs e) {
            muyGrande(txtIdNota);
        }

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

        private void txtCantCursos_KeyPress(object sender, KeyPressEventArgs e) {
            validarEntrada(sender, e);
        }

        

        private void txtHorasCurso_KeyPress(object sender, KeyPressEventArgs e) {
            validarEntrada(sender, e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e) {
            validarEntrada(sender, e);
        }
































        //
    }

}
