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
    public partial class FrmClaseSincronica : Form {
        public FrmClaseSincronica() {
            InitializeComponent();

            DTFechaClase.MinDate = DateTime.Now;
            DTFechaClase.Value = DTFechaClase.Value.AddDays(2);

            if(DTFechaClase.Value.DayOfWeek == DayOfWeek.Sunday){
                DTFechaClase.Value = DTFechaClase.Value.AddDays(1);
            }else if(DTFechaClase.Value.DayOfWeek == DayOfWeek.Saturday) {
                DTFechaClase.Value = DTFechaClase.Value.AddDays(2);
            }
            
        }
        //Variables globales
        int vgn_id;
        EntidadClaseSincronica datoRegistrado;
        //formulario a buscar
        FrmBuscarEstudiante frmBuscar;

        private void GrdNotaMateria_DoubleClick(object sender, EventArgs e) {
            Seleccionar();
        }

        private void FrmClaseSincronica_Load(object sender, EventArgs e) {
            CargarListaDataSet();
        }


        private void BtnGuardar_Click(object sender, EventArgs e) {
            EntidadClaseSincronica claseSincronica = new EntidadClaseSincronica();
            BLClaseSincronica logica = new BLClaseSincronica(Configuracion.getConnectionString);

            int resultado =0;
            int resultadoM = 0;

            try {
                //Se hace el llamado de generarEntidad, para poder jalar los datos del formulario
                //hacia la entidad y luego mover esa misma entidad con los datos correctos
                
                if (string.IsNullOrEmpty(txtIdEstudiante.Text)) {
                    MessageBox.Show("Debe seleccionar un estudiante si desea colocar la clase sincronica", "Alerta");
                }
                else if (DTFechaClase.Value == DateTime.Now || DTFechaClase.Value == DateTime.Now.AddDays(1)) {
                    MessageBox.Show("La fecha seleccionada debe ser entre semana y 2 dias despues a la actual", "Alerta");
                    
                }
                else if(DTFechaClase.Value.DayOfWeek == DayOfWeek.Saturday || DTFechaClase.Value.DayOfWeek == DayOfWeek.Sunday) {
                    
                    MessageBox.Show("La fecha seleccionada debe ser entre semana", "Alerta");
                   
                }
                else {
                    claseSincronica = GenerarEntidad();

                    if (!string.IsNullOrEmpty(txtIdClaseSincronica.Text)) {
                        resultadoM = logica.Modificar(claseSincronica);
                        if (resultadoM == 1) {
                            MessageBox.Show("Modificacion realizada de forma exitosa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                    }
                    else {
                        resultado = logica.Insertar(claseSincronica);
                        //MessageBox.Show(logica.mensaje);
                        if (resultado == 1) {
                            MessageBox.Show("Insertado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                            
                        }
                        else {
                            if (resultadoM > 0) {
                                MessageBox.Show("Modificado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Limpiar();
                            }else{
                                MessageBox.Show(logica.mensaje);
                            }

                        }

                    }


                }


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //para que vuelva a cargar el DataGridView
            CargarListaDataSet();
        }//-------------------------------------

        private void BtnBuscar_Click(object sender, EventArgs e) {

        }

        private void BtnNuevo_Click(object sender, EventArgs e) {

        }

        private void BtnEliminar_Click(object sender, EventArgs e) {
            EntidadClaseSincronica claseSincronica;
            int resultado;
            BLClaseSincronica logica = new BLClaseSincronica(Configuracion.getConnectionString);

            try {
                if (!string.IsNullOrEmpty(txtIdClaseSincronica.Text)) {
                    //Busca primero el idioma antes de borrarlo para ver si existe
                    claseSincronica = logica.ObtenerClaseSincronica(Convert.ToInt32(txtIdClaseSincronica.Text));

                    if (claseSincronica != null) {
                        //si el cliente es nulo, existe por lo que se puede borrar

                        resultado = logica.EliminarClaseSincronica(claseSincronica);
                        MessageBox.Show("Clase Sincronica Eliminado Correctamente");
                        Limpiar();
                        CargarListaDataSet();

                    }
                    else {
                        MessageBox.Show("La Clase Sincronica no existe", "Aviso", MessageBoxButtons.OK);
                        Limpiar();
                        CargarListaDataSet();
                    }

                }
                else {
                    MessageBox.Show("Debe seleccionar un Clase Sincronica antes de eliminarlo", "Aviso", MessageBoxButtons.OK);
                }


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            Limpiar();
        }

        private void BtnSalir_Click(object sender, EventArgs e) {
            Close();
        }



        //Metodos-------------------------------------


        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-Principal
        private void CargarClaseSincronica(int id) {

            EntidadClaseSincronica claseSinc = new EntidadClaseSincronica();
            BLClaseSincronica traerDato = new BLClaseSincronica(Configuracion.getConnectionString);

            try {
                claseSinc = traerDato.ObtenerClaseSincronica(id);

                if (claseSinc != null) {
                    txtIdClaseSincronica.Text = claseSinc.Id_claseSincronica.ToString();
                    txtIdEstudiante.Text = claseSinc.Id_estudiante.ToString();
                    txtIdProfesor.Text = claseSinc.Id_profesor.ToString();
                    txtIdCurso.Text = claseSinc.Id_curso;
                    DTFechaClase.Value =claseSinc.FechaClase;
                    DTHoraInicio.Value =claseSinc.HoraInicio;
                    DTHoraFinal.Value =claseSinc.HoraFinal;

                    //DTFechaClase.Value= Convert.ToDateTime(claseSinc.FechaClase.AddHours(2).ToString("MM-dd-yyyy"));
                    //DTHoraInicio.Value = Convert.ToDateTime(claseSinc.HoraInicio.ToString("HH:mm:ss"));
                    //DTHoraFinal.Value = Convert.ToDateTime(claseSinc.HoraFinal.ToString("HH:mm:ss"));


                    datoRegistrado = claseSinc;
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
                CargarClaseSincronica(id1);
                LlamadoEstudianteClaseSinc(id1);


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------




        //Muestra que dato se seleccionó y lo puede mostrar o guardar

        private void Seleccionar() {

            if (GrdClaseSincronica.SelectedRows.Count > 0) {
                vgn_id = (int)GrdClaseSincronica.SelectedRows[0].Cells[0].Value;
                Aceptar(vgn_id, null);
            }
        }//--------------------------



        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLClaseSincronica logica = new BLClaseSincronica(Configuracion.getConnectionString);
            DataSet DS;


            try {
                DS = logica.ListarClaseSincronica(condicion, orden);

                GrdClaseSincronica.DataSource = DS;
                GrdClaseSincronica.DataMember = DS.Tables["ClaseSincronica"].TableName;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------


        public void Limpiar() { 
            txtIdClaseSincronica.Text = string.Empty;
            txtIdEstudiante.Text = string.Empty;
            txtIdProfesor.Text = string.Empty;
            txtIdCurso.Text = string.Empty;
            DTFechaClase.Text = string.Empty;
            DTHoraFinal.Text = string.Empty;
            DTHoraInicio.Text = string.Empty;

            //matricula.Fechamatricula.ToString();

            if (!txtIdClaseSincronica.Enabled) {
                txtIdClaseSincronica.Enabled = true;
            }
        }//-----------------



        //Generar Entidad
        public EntidadClaseSincronica GenerarEntidad() {

            EntidadClaseSincronica claseSincronica;
            if (string.IsNullOrEmpty(txtIdClaseSincronica.Text)) {

                claseSincronica = new EntidadClaseSincronica();

                claseSincronica.Id_claseSincronica =-1;
            }
            else {
                claseSincronica = datoRegistrado;

                claseSincronica.Id_claseSincronica = int.Parse(txtIdClaseSincronica.Text);
                 
            }

            claseSincronica.Id_estudiante = int.Parse(txtIdEstudiante.Text);
            claseSincronica.Id_profesor = int.Parse(txtIdProfesor.Text);
            claseSincronica.Id_curso = txtIdCurso.Text;
            claseSincronica.FechaClase = DTFechaClase.Value;
            claseSincronica.HoraInicio = DTHoraInicio.Value;
            claseSincronica.HoraFinal = DTHoraFinal.Value.AddHours(2);

            return claseSincronica;
        }//---------------------------------

        private void btnSelectIdEstudiante_Click(object sender, EventArgs e) {
            frmBuscar = new FrmBuscarEstudiante();
            //se especifica que se requiere usar el evento aceptar creado en el FrmBuscarIdioma
            frmBuscar.BuscarEstudiante += new EventHandler(BuscarEstudiante);
            frmBuscar.ShowDialog();
            if(!string.IsNullOrEmpty(txtIdEstudiante.Text)){
                LlamadoEstudianteClaseSinc(Convert.ToInt32(txtIdEstudiante.Text));
            }
        }//---------------------------------------




        private void BuscarEstudiante(object id, EventArgs e) {
            try {


                // estudiante = acceso.ObtenerEstudiante(vgn_idEstudiante);

                txtIdEstudiante.Text = id.ToString();
                

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------


        //Metodo para traer los datos que estan sincronizados a ese estudiante el cual esta matriculado en esa materia
        //e igualmente los datos


        private void LlamadoEstudianteClaseSinc(int idEstudiante) {
            BLClaseSincronica acceso = new BLClaseSincronica(Configuracion.getConnectionString);
            string[] clase = new string[4];
            try {
                clase = acceso.ObtenerEstudianteClaseSincronica(idEstudiante);
                txtIdEstudiante.Text = clase[0];
                txtIdCurso.Text = clase[1];
                txtIdProfesor.Text = clase[2];
                txtMateria.Text = clase[3];
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
