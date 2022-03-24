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
    public partial class FrmCliente : Form {
        public FrmCliente() {
            InitializeComponent();
        }

        EntidadCliente clienteRegistrado;

        //Variable global para accederla de todos los metodos de la clase
        int vgn_idcliente; //vgn = Variable Global Numerica 

        FrmBuscarCliente formularioBuscarCliente;



        //generar entidad
        public EntidadCliente GenerarEntidadCliente() {
            EntidadCliente cliente;

            if(!string.IsNullOrEmpty(txtID.Text)){
                cliente = clienteRegistrado;
            }else{
                cliente = new EntidadCliente();
            }

            cliente.setNombre(TxtNombre.Text);
            cliente.setTelefono(TxtTelefono.Text);
            cliente.setDireccion(TxtDireccion.Text);


            return cliente;
        }
        private void BtnGuardar_Click(object sender, EventArgs e) {
            EntidadCliente cliente = new EntidadCliente();
            BLCliente logica = new BLCliente(Configuracion.getConnectionString);//Obtiene la cadena de conexion y se la envia a la capa logica
            int resultado;
            try {
                if (string.IsNullOrEmpty(TxtNombre.Text) || string.IsNullOrEmpty(TxtTelefono.Text) ||
                    string.IsNullOrEmpty(TxtDireccion.Text)) {
                    MessageBox.Show("Datos incompletos, favor, complete todos los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else {
                    cliente = GenerarEntidadCliente();
                    if(!cliente.Existe){
                        resultado = logica.Insertar(cliente);
                    }else{
                        resultado = logica.Modificar(cliente);
                    }
                    if(resultado>0){
                        MessageBox.Show("Operación realizada de forma exitosa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }else{
                        MessageBox.Show("No se realizaron cambios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //para reiniciar la tabla de grid
            CargarListaArray();

        }//-----------------------------------

        public void Limpiar() {
            txtID.Text = "";
            TxtNombre.Text = "";
            TxtTelefono.Text = "";
            TxtDireccion.Text = "";
        }

        private void BtnSalir_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            formularioBuscarCliente = new FrmBuscarCliente();

            formularioBuscarCliente.Aceptar += new EventHandler(Aceptar);
            formularioBuscarCliente.ShowDialog();
        }

        private void Aceptar(object id, EventArgs e){
            try{
                int idcliente = (int)id;
                if(idcliente != -1){
                    CargarCliente(idcliente);
                }else{
                    Limpiar();
                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrdClientes_DoubleClick(object sender, EventArgs e) {
            seleccionar();
        }

        private void seleccionar(){
            if(GrdClientes.SelectedRows.Count>0){
                vgn_idcliente = (int)GrdClientes.SelectedRows[0].Cells[0].Value;
                Aceptar(vgn_idcliente, null);
            }
        }

        
        private void CargarCliente(int id){
            EntidadCliente cliente = new EntidadCliente();
            BLCliente traerCliente = new BLCliente(Configuracion.getConnectionString);
            try{
                cliente = traerCliente.ObtenerCliente(id);

                if(cliente != null){
                    txtID.Text = cliente.Id_cliente.ToString();
                    TxtNombre.Text = cliente.Nombre;
                    TxtTelefono.Text = cliente.Telefono;
                    TxtDireccion.Text = cliente.Direccion;

                    clienteRegistrado = cliente;
                }else {
                    MessageBox.Show("El cliente no se encuentra", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            } catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarListaArray();

        }


        public void CargarListaArray(string condicion = "") {
            BLCliente logica = new BLCliente(Configuracion.getConnectionString);
            List<EntidadCliente> clientes;

            try {
                clientes = logica.ListarClientes(condicion);
                if (clientes.Count > 0) // si hay algo en la lista
                {
                    GrdClientes.DataSource = clientes; //carguelo en el gridview
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//---------------------------------

        private void FrmCliente_Load(object sender, EventArgs e) {
            CargarListaArray();
        }//--------

        private void btnEliminar_Click(object sender, EventArgs e) {
            EntidadCliente cliente;
            int resultado;
            BLCliente logica = new BLCliente(Configuracion.getConnectionString);

            try {
                if (!string.IsNullOrEmpty(txtID.Text)) {
                    //buscar primero el cliente antes de borrarlo para ver si existe
                    cliente = logica.ObtenerCliente(int.Parse(txtID.Text));
                    if (cliente != null) {
                        /*
                            //si el cliente no es nulo puede borrarlo
                            resultado = logica.EliminarConSP(cliente);
                            MessageBox.Show(logica.Mensaje, "Aviso", MessageBoxButtons.OK);
                            //imprime el mensaje con el SP mandó
                            Limpiar();
                            CargarListaArray();

                        */
                        //-----
                        resultado = logica.EliminarCliente(cliente);
                        MessageBox.Show("Eliminado sin SP");
                        Limpiar();
                        CargarListaArray();
                        //----
                    }
                    else {
                        MessageBox.Show("El cliente no existe", "Aviso", MessageBoxButtons.OK);
                        Limpiar();
                        CargarListaArray();
                    }
                }
                else {
                    MessageBox.Show("Debe seleccionar un cliente antes de eliminarlo", "Aviso", MessageBoxButtons.OK);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }//-----------------------------------
















    }
}
