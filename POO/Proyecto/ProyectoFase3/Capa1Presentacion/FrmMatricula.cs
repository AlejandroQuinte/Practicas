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
    public partial class FrmMatricula : Form {
        public FrmMatricula() {
            InitializeComponent();
        }
        //Variables globales
        int vgn_id;
        EntidadMatricula datoRegistrado;
        //formulario a buscar
        FrmBuscarEstudiante frmBuscar;
        
        private void FrmMatricula_Load(object sender, EventArgs e) {
            CargarListaDataSet();
            CBCurso.SelectedIndex = 0;
            CBIntensidad.SelectedIndex = 0;
        }

        private void GrdEstudiante_DoubleClick(object sender, EventArgs e) {
            Seleccionar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e) {
            EntidadMatricula matricula = new EntidadMatricula();
            BLMatricula logica = new BLMatricula(Configuracion.getConnectionString);

            int resultado;
            int resultadoM = 0;

            try {
                //Se hace el llamado de generarEntidad, para poder jalar los datos del formulario
                //hacia la entidad y luego mover esa misma entidad con los datos correctos
                if (string.IsNullOrEmpty(txtIdEstudiante.Text)) {
                    MessageBox.Show("Debe seleccionar al estudiante que desea hacerle la matricula", "Alerta");

                }else if (string.IsNullOrEmpty(txtIdCurso.Text)){
                    MessageBox.Show("Debe seleccionar un curso si desea hacer la matricula", "Alerta");
                }
                else if(string.IsNullOrEmpty(txtPagoTotal.Text)){
                    MessageBox.Show("Debe realizar el pago si desea hacer la matricula", "Alerta");

                }else {
                    matricula = GenerarEntidad();

                    if (!string.IsNullOrEmpty(txtIdMatricula.Text)) {
                        resultadoM = logica.Modificar(matricula);
                        if (resultadoM == 1) {
                            MessageBox.Show("Modificacion realizada de forma exitosa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        } 
                    }
                    else {
                        resultado = logica.Insertar(matricula);
                        if (resultado==0) {

                            MessageBox.Show(logica.mensaje);
                        }
                        else {
                            if (resultadoM == 0) {
                                MessageBox.Show("Insertado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }

                    }


                }


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //para que vuelva a cargar el DataGridView
            CargarListaDataSet();
            Limpiar();
        }//-------------------------------------------

        private void BtnBuscar_Click(object sender, EventArgs e) {

        }

        private void BtnNuevo_Click(object sender, EventArgs e) {
            Limpiar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e) {
            EntidadMatricula matricula;
            int resultado;
            BLMatricula logica = new BLMatricula(Configuracion.getConnectionString);

            try {
                if (!string.IsNullOrEmpty(txtIdMatricula.Text)) {
                    //Busca primero el idioma antes de borrarlo para ver si existe
                    matricula = logica.ObtenerMatricula(Convert.ToInt32(txtIdMatricula.Text));

                    if (matricula != null) {
                        //si el cliente es nulo, existe por lo que se puede borrar

                        resultado = logica.EliminarMatricula(matricula);
                        MessageBox.Show("Curso Eliminado Correctamente");
                        Limpiar();
                        CargarListaDataSet();

                    }
                    else {
                        MessageBox.Show("El matricula no existe", "Aviso", MessageBoxButtons.OK);
                        Limpiar();
                        CargarListaDataSet();
                    }

                }
                else {
                    MessageBox.Show("Debe seleccionar un matricula antes de eliminarlo", "Aviso", MessageBoxButtons.OK);
                }


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            Limpiar();
        }//------------------------------------

        private void BtnSalir_Click(object sender, EventArgs e) {
            Close();
        }



        //Metodos-------------------------------------


        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-Principal
        private void CargarMatricula(int id) {

            EntidadMatricula matricula = new EntidadMatricula();
            BLMatricula traerDato = new BLMatricula(Configuracion.getConnectionString);

            try {
                matricula = traerDato.ObtenerMatricula(id);

                if (matricula != null) {
                    txtIdMatricula.Text = matricula.Id_matricula.ToString();
                    txtIdEstudiante.Text =matricula.Id_estudiantes.ToString();
                    txtIdCurso.Text = matricula.Id_curso;
                    CBIntensidad.Text = matricula.Intensidad.ToString();
                    DTFechaMatricula.Text = matricula.Fechamatricula.ToString();
                    txtPagoTotal.Text = matricula.Totalpago.ToString();
                    txtEstadoPago.Text = EstadoPago(txtPagoTotal.Text); 

                    datoRegistrado = matricula;
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

                int id1 = Convert.ToInt32( id);
                CargarMatricula(id1);
                //Desabhilitamos el CODIGO para que no pueda ser cambiado
                txtIdMatricula.Enabled = false;


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------

        //traera la informacion de la tabla buscar
        private void BuscarEstudiante(object id, EventArgs e) {
            BLEstudiante acceso = new BLEstudiante(Configuracion.getConnectionString);

            EntidadEstudiante estudiante = new EntidadEstudiante();

            
            try {

                
               // estudiante = acceso.ObtenerEstudiante(vgn_idEstudiante);

                txtIdEstudiante.Text =id.ToString();


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------


        private void Seleccionar() {

            if (GrdMatricula.SelectedRows.Count > 0) {
                vgn_id = (int)GrdMatricula.SelectedRows[0].Cells[0].Value;
                Aceptar(vgn_id, null);
                txtIdEstudiante.Enabled = false;
            }
        }//--------------------------


        //Implementa el evento ACEPTAR, este recibe un id el cual se manda desde frmBuscar
        // y se usa en frmCliente para cargar los datos de los clientes
       



        private void CargarListaDataSet(string condicion = "", string orden = "") {

            //cargar el datagridview con los datos del dataset
            BLMatricula logica = new BLMatricula(Configuracion.getConnectionString);
            DataSet DS;


            try {
                DS = logica.ListarMatricula(condicion, orden);

                GrdMatricula.DataSource = DS;
                GrdMatricula.DataMember = DS.Tables["Matricula"].TableName;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//------------------------------


        public void Limpiar() {
            txtIdMatricula.Text = string.Empty;
            txtIdEstudiante.Text = string.Empty;
            txtIdCurso.Text = string.Empty;
            txtEstadoPago.Text = string.Empty;
            DTFechaMatricula.Text = string.Empty;
            txtPagoTotal.Text = string.Empty;
            CBIntensidad.Text = string.Empty;
            CBCurso.SelectedIndex = 0;
            CBIntensidad.SelectedIndex = 0;
            LlamadoCurso(Convert.ToString(CBCurso.SelectedItem));

        }//-----------------



        //Generar Entidad
        public EntidadMatricula GenerarEntidad() {

            EntidadMatricula matricula;
            if (string.IsNullOrEmpty(txtIdMatricula.Text)) {

                matricula = new EntidadMatricula();

            }
            else {
                matricula = datoRegistrado;
            }
            

            if (string.IsNullOrEmpty(txtIdMatricula.Text)){
                matricula.Id_matricula = -1;
            }else{
                matricula.Id_matricula = Convert.ToInt32(txtIdMatricula.Text);
            }
            string m = txtIdCurso.Text;
            matricula.Id_estudiantes = Convert.ToInt32(txtIdEstudiante.Text);
            matricula.Id_curso = m;
            matricula.Intensidad = Convert.ToInt32(CBIntensidad.SelectedItem);
            matricula.Fechamatricula = DTFechaMatricula.Value;
            double num = Convert.ToDouble(txtPagoTotal.Text);
            matricula.Totalpago = (float)num;
            matricula.Estadopago = EstadoPago(txtPagoTotal.Text);



            return matricula;
        }//---------------------------------

        //metodo para comprar el estado del pago realizado
        private string EstadoPago(string pago){
            string estado;
            double num1, num2;
            num1 = Convert.ToDouble(txtPagoTotal.Text);
            num2 = Convert.ToDouble((txtPrecio.Text));    

            if (num1 == num2){
                estado = "COMPLETO";
            }else{
                estado = "INCOMPLETO";
            }


            return estado;
        }

        private void button1_Click(object sender, EventArgs e) {
            frmBuscar = new FrmBuscarEstudiante();
            //se especifica que se requiere usar el evento aceptar creado en el FrmBuscarIdioma
            frmBuscar.BuscarEstudiante += new EventHandler(BuscarEstudiante);
            frmBuscar.ShowDialog();
        }

        private void CBCurso_SelectedIndexChanged(object sender, EventArgs e) {

            LlamadoCurso(Convert.ToString(CBCurso.SelectedItem));
        }

        private void CBIntensidad_SelectedIndexChanged(object sender, EventArgs e) {
            if (Convert.ToString(CBIntensidad.SelectedItem) == "1") {
                txtCantHorasDias.Text = "1";
                CalcularFecha();

            }
            else if (Convert.ToString(CBIntensidad.SelectedItem) == "2") {
                txtCantHorasDias.Text = "2";
                CalcularFecha();
            }
            else if (Convert.ToString(CBIntensidad.SelectedItem) == "3") {
                txtCantHorasDias.Text = "3";
                CalcularFecha();
            }
            else if (Convert.ToString(CBIntensidad.SelectedItem) == "4") {
                txtCantHorasDias.Text = "4";
                CalcularFecha();
            }

           
        
        }





        private void LlamadoCurso(string nombreCurso) {
            BLMatricula acceso = new BLMatricula(Configuracion.getConnectionString);
            string[] curso = new string[9];
            try{
                curso = acceso.ObtenerCursoMatricula(nombreCurso);
                txtIdCurso.Text = curso[0];
                txtNombreCurso.Text = curso[3];
                txtCantHoras.Text = curso[5];
                txtPrecio.Text = curso[8];
            } catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //cada que se seleccione la intensidad hara el llamado con la informacion de intensidad si es 1 si es 2 etc
        private void CalcularFecha(){
            int numDays=0;

            if (Convert.ToString(CBIntensidad.SelectedItem) == "1") {
                DTFechaTerminado.Value = FechaEntrega(DTFechaMatricula.Value, Convert.ToInt32(txtCantHoras.Text));
            }
            else if (Convert.ToString(CBIntensidad.SelectedItem) == "2") {
                numDays = Convert.ToInt32(txtCantHoras.Text) / 2;
                DTFechaTerminado.Value = FechaEntrega(DTFechaMatricula.Value, numDays);
            }
            else if (Convert.ToString(CBIntensidad.SelectedItem) == "3") {
                numDays = Convert.ToInt32(txtCantHoras.Text) / 3;
                DTFechaTerminado.Value = FechaEntrega(DTFechaMatricula.Value, numDays);
            }
            else if (Convert.ToString(CBIntensidad.SelectedItem) == "4") {
                numDays = Convert.ToInt32(txtCantHoras.Text) / 4;
                DTFechaTerminado.Value = FechaEntrega(DTFechaMatricula.Value, numDays);
            }

            
            if (DTFechaTerminado.Value.DayOfWeek == DayOfWeek.Sunday) {
                DTFechaTerminado.Value = DTFechaTerminado.Value.AddDays(1);
            }
            else if (DTFechaTerminado.Value.DayOfWeek == DayOfWeek.Saturday) {
                DTFechaTerminado.Value = DTFechaTerminado.Value.AddDays(2);
            }


        }

        //Evalua que fecha cae y se le va sumando los dias dependiendo de cuantos datos le envien
        static DateTime FechaEntrega(DateTime fechaPedido, int espera) {
            DateTime dt = fechaPedido; ;

            for (int k = 0; k < espera; k++) {
                while (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday) dt = dt.AddDays(1);

                dt = dt.AddDays(1);
            }

            return dt;
        }



        private void txtPagoTotal_KeyPress(object sender, KeyPressEventArgs e) {
            validarEntrada(sender, e);
        }


        //Evalua si el numero se encuentra mayor al precio cuando se suelta la tecla
        public void muyGrande(TextBox num) {
            double n = 0,precio=0;
            double.TryParse(num.Text, out n);
            double.TryParse(txtPrecio.Text,out precio);
            if (n > precio) {
                MessageBox.Show("El pago no puede ser mayor al precio del curso", "Precio fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtPagoTotal_KeyUp(object sender, KeyEventArgs e) {
            muyGrande(txtPagoTotal);
        }

        private void btnSelecCurso_Click(object sender, EventArgs e) {

        }


        //
    }
}
