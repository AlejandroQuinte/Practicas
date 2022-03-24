using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa2LogicaNegocio;
using CapaEntidades;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace SitioWeb {
    public partial class Mantenimiento_formulario : System.Web.UI.Page {

        //Variables globales
        int vgn_id;
        EntidadMatricula datoRegistrado;
        string mensajeScript;


        protected void Page_Load(object sender, EventArgs e) {
            EntidadMatricula matricula;
            BLMatricula logica = new BLMatricula(clsConfiguracion.getConnectionString);
            int identificacion;
            try {


                if (!Page.IsPostBack) {

                    fechaMatricula.Text = DateTime.Now.ToString("d");
                    

                    //si session tiene un valor de idMatricula significa que le hicieron un llamado anterior
                    if (Session["id_de_matricula"] != null) {
                        identificacion = int.Parse(Session["id_de_matricula"].ToString());
                        CargarMatricula(identificacion);
                        matricula = logica.ObtenerMatricula(identificacion);
                        if (matricula.Existe) {

                            LlamadoCurso(matricula.Id_curso);

                            txtIdMatricula.Text = matricula.Id_matricula.ToString();
                            txtIdEstudiante.Text = matricula.Id_estudiantes.ToString();
                            txtIdCurso.Text = matricula.Id_curso;
                            DLIntensidad.SelectedItem.Value = matricula.Intensidad.ToString();
                            fechaMatricula.Text = matricula.Fechamatricula.ToString();
                            txtPagoTotal.Text = matricula.Totalpago.ToString();
                            txtEstadoPago.Text = EstadoPago(txtPagoTotal.Text);

                            mostradoEstudianteCurso();

                        }
                        else {
                            mensajeScript = String.Format("javascript:mostrarMensaje('Matricula no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);

                        }
                    }
                    else {
                        //revisamos si es viisble significa que le dio en seleccionar algun dato,
                        //entonces no queremos perder los datos de la pagina matricula, 
                        if(Session["visible"]!=null){
                            //revisamos si session informacion tiene algun dato, si tiene se coloca esa informacion
                            //en los textBoxs
                            if (Session["informacion"] != null) {
                                ArrayList datos = new ArrayList();
                                datos = (ArrayList)Session["informacion"];

                                txtIdEstudiante.Text = datos[0].ToString();
                                txtIdCurso.Text = datos[1].ToString();
                                txtNombreCurso.Text = datos[2].ToString();
                                DLIntensidad.SelectedItem.Value = datos[3].ToString();
                                txtPrecio.Text = datos[4].ToString(); 
                                txtCantHoras.Text = datos[5].ToString();
                                txtCantHorasDias.Text =datos[6].ToString();
                                txtEstadoPago.Text = datos[7].ToString();
                                fechaMatricula.Text = datos[8].ToString();
                                fechaFinal.Text = datos[9].ToString();
                                txtPagoTotal.Text = datos[10].ToString();

                            }
                            
                        }

                        mostradoEstudianteCurso();

                    }
                }
            } catch (Exception ex) {

            }

        }
        //metodo para mostrar la informacion de los cursos y estudiantes
        private void mostradoEstudianteCurso(){
            if (Session["id_estudianteSeleccionado"] != null) {
                //cuando se seleeciona un estudiante se crea un session con el id, revisamos que exista
                //y lo mostramos en el textBox
                txtIdEstudiante.Text = Session["id_estudianteSeleccionado"].ToString();
            }
            if (Session["id_CursoSeleccionado"] != null) {
                //revisamos que se seleccionó un dato en la pagina Curso, si fue asi 
                //creamos un metodo para que pueda hacer un llamado total del dato Curso, asi
                //mostrar la informacion completa del curso en los textBoxs
                LlamadoCurso(Session["id_CursoSeleccionado"].ToString());
                fechaFinal.Text = Convert.ToDateTime(fechaMatricula.Text).AddDays(Convert.ToInt32(txtCantHoras.Text)).ToString("d");
                txtCantHorasDias.Text = "1";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e) {
            EntidadMatricula matricula;
            BLMatricula logica = new BLMatricula(clsConfiguracion.getConnectionString);
            int resultado = 0;

            try {
                matricula = GenerarEntidad();
                //si el cliente ya existe se modifica
                if (matricula.Existe) {
                    resultado = logica.Modificar(matricula);

                }
                else {//Sino existe se crea
                    if (!string.IsNullOrEmpty(txtIdCurso.Text) && !string.IsNullOrEmpty(txtIdCurso.Text)) {

                        resultado = logica.Insertar(matricula);
                    }
                    else {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Debe agregar los dos ID del cliente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        resultado = -1;
                    }
                }
                if (resultado > 0) {
                    mensajeScript = string.Format("javascript:mostrarMensaje('Operacion realizada correctamente')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    Response.Redirect("Matricula.aspx");
                }
                else {
                    mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", logica.mensaje);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                }


            } catch (Exception ex) {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e) {
            Response.Redirect("Matricula.aspx");
        }



        //Metodos
        //Metodo para revisar el estado del pago, si fue Completo o Incompleto
        private string EstadoPago(string pago) {
            string estado;
            double num1, num2;
            num1 = Convert.ToDouble(txtPagoTotal.Text);
            num2 = Convert.ToDouble(txtPrecio.Text);

            if (num1 == num2) {
                estado = "COMPLETO";
            }
            else {
                estado = "INCOMPLETO";
            }


            return estado;
        }

        public void Limpiar() {
            txtIdMatricula.Text = string.Empty;
            txtIdEstudiante.Text = string.Empty;
            txtIdCurso.Text = string.Empty;
            txtEstadoPago.Text = string.Empty;
            fechaMatricula.Text = string.Empty;
            txtPagoTotal.Text = string.Empty;
            DLIntensidad.SelectedIndex = 1;

        }//-----------------




        //Crea un metodo para cargar a la tabla, o mejor dicho a los textbox de nombre e ID-Principal
        private void CargarMatricula(int id) {

            EntidadMatricula matricula = new EntidadMatricula();
            BLMatricula traerDato = new BLMatricula(clsConfiguracion.getConnectionString);

            try {
                matricula = traerDato.ObtenerMatricula(id);

                if (matricula != null) {
                    
                    datoRegistrado = matricula;
                }
                else {
                    MessageBox.Show("El Dato no se encuentra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//---------------------------



        //Generar Entidad
        public EntidadMatricula GenerarEntidad() {

            EntidadMatricula matricula=new EntidadMatricula();
            //si hay algo en la variable de sesion
            if (Session["id_de_matricula"] != null) {

                matricula.Id_matricula = int.Parse(Session["id_de_matricula"].ToString());
                matricula.Existe = true;
            }
            //Si no hay nada en la variable de sesion, es un cliente nuevo
            else {
                matricula.Id_matricula = -1;
                matricula.Existe = false;
            }

            matricula.Id_estudiantes = Convert.ToInt32(txtIdEstudiante.Text);
            matricula.Id_curso = txtIdCurso.Text;
            matricula.Intensidad = Convert.ToInt32(DLIntensidad.SelectedItem.ToString());
            matricula.Fechamatricula =Convert.ToDateTime(fechaMatricula.Text);
            double num = Convert.ToDouble(txtPagoTotal.Text);
            matricula.Totalpago = (float)num;
            matricula.Estadopago = EstadoPago(txtPagoTotal.Text);


            return matricula;
        }//---------------------------------


        //traera la informacion de la tabla buscar
        private void BuscarEstudiante(object id, EventArgs e) {
            BLEstudiante acceso = new BLEstudiante(clsConfiguracion.getConnectionString);

            EntidadEstudiante estudiante = new EntidadEstudiante();


            try {


                // estudiante = acceso.ObtenerEstudiante(vgn_idEstudiante);

                txtIdEstudiante.Text = id.ToString();


            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-----------------------

        //metodo para llamar datos del curso enviando el string que se saco de la pagina curso
        private void LlamadoCurso(string idCurso) {
            BLMatricula acceso = new BLMatricula(clsConfiguracion.getConnectionString);
            string[] curso = new string[9];
            try {
                curso = acceso.ObtenerCursoMatricula(idCurso);
                txtIdCurso.Text = curso[0];
                txtNombreCurso.Text = curso[3];
                txtCantHoras.Text = curso[5];
                txtPrecio.Text = curso[8];
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-------------




        protected void btnSelectEstudiante_Click(object sender, EventArgs e) {

            //creamos la variable session visible para mostrar los datos de la pagina
            //y la de iformacion para guardar la pagina
            sessionInformacion();

            Session["visible"] = 1;
            Response.Redirect("Estudiante.aspx");

            
        }

        protected void btnSelectCurso_Click(object sender, EventArgs e) {
            //creamos la variable session visible para mostrar los datos de la pagina
            //y la de iformacion para guardar la pagina
            sessionInformacion();

            Session["visible"] = 1;

            Response.Redirect("Curso.aspx");
            
        }

        //metodo para guardar la variable session en el que guardamos los datos de la pagina
        private void sessionInformacion(){
            ArrayList datos = new ArrayList();

            datos.Add(txtIdEstudiante.Text);
            datos.Add(txtIdCurso.Text);
            datos.Add(txtNombreCurso.Text);
            datos.Add(DLIntensidad.SelectedItem.ToString());
            datos.Add(txtPrecio.Text);
            datos.Add(txtCantHoras.Text);
            datos.Add(txtCantHorasDias.Text);
            datos.Add(txtEstadoPago.Text);
            datos.Add(fechaMatricula.Text);
            datos.Add(fechaFinal.Text);
            datos.Add(txtPagoTotal.Text);

            Session["informacion"] = datos;
        }

        protected void DLIntensidad_SelectedIndexChanged(object sender, EventArgs e) {
            if (DLIntensidad.SelectedItem.ToString() == "1") {
                if (!string.IsNullOrEmpty(txtCantHoras.Text)) {
                    txtCantHorasDias.Text = "1";
                    CalcularFecha();
                }
            }
            else if (DLIntensidad.SelectedItem.ToString() == "2") {
                if (!string.IsNullOrEmpty(txtCantHoras.Text)) {
                    txtCantHorasDias.Text = "2";
                    CalcularFecha();
                }
            }
            else if (DLIntensidad.SelectedItem.ToString() == "3") {
                if (!string.IsNullOrEmpty(txtCantHoras.Text)) {
                    txtCantHorasDias.Text = "3";
                    CalcularFecha();
                }
            }
            else if (DLIntensidad.SelectedItem.ToString() == "4") {
                if (!string.IsNullOrEmpty(txtCantHoras.Text)) {
                    txtCantHorasDias.Text = "4";
                    CalcularFecha();
                }
            }
        }

        //cada que se seleccione la intensidad hara el llamado con la informacion de intensidad si es 1 si es 2 etc
        private void CalcularFecha() {
            int numDays = 0;
            DateTime fechaPedido = Convert.ToDateTime(fechaMatricula.Text);
            if (DLIntensidad.SelectedItem.ToString() == "1") {

                fechaFinal.Text = FechaEntrega(fechaPedido, Convert.ToInt32(txtCantHoras.Text)).ToString();
            }
            else if (DLIntensidad.SelectedItem.ToString() == "2") {
                numDays = Convert.ToInt32(txtCantHoras.Text) / 2;
                fechaFinal.Text = FechaEntrega(fechaPedido, numDays).ToString();
            }
            else if (DLIntensidad.SelectedItem.ToString() == "3") {
                numDays = Convert.ToInt32(txtCantHoras.Text) / 3;
                fechaFinal.Text = FechaEntrega(fechaPedido, numDays).ToString();
            }
            else if (DLIntensidad.SelectedItem.ToString() == "4") {
                numDays = Convert.ToInt32(txtCantHoras.Text) / 4;
                fechaFinal.Text = FechaEntrega(fechaPedido, numDays).ToString();
            }
            DateTime fechaF = Convert.ToDateTime(fechaFinal.Text);

            if (fechaF.DayOfWeek == DayOfWeek.Sunday) {
                fechaF = fechaF.AddDays(1);
            }
            else if (fechaF.DayOfWeek == DayOfWeek.Saturday) {
                fechaF = fechaF.AddDays(2);
            }
            fechaFinal.Text = fechaF.ToString("d");
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


    }//----------------------
}