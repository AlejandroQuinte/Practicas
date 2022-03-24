using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa2LogicaNegocio;
using CapaEntidades;

namespace Capa1Presentacion {
    public partial class FrmProducto : Form {
        public FrmProducto() {
            InitializeComponent();
        }

        //Se crea una variable global para poder usarla en todo momento de entidad
        EntidadProducto productoRegistrado;


        //
        FrmBuscarProducto formularioProductobuscar;

        //Variable global para accederla de todos los metodos de la clase
        int vgn_idproducto; //vgn = Variable Global Numerica 

        public EntidadProducto GenerarEntidadProducto(){
            
            EntidadProducto producto;
            if(!string.IsNullOrEmpty(TxtID.Text)) { // Si NO esta vacio es porque ya existe, habria que modificar
                producto = productoRegistrado;//revisar que siempre que se cargue un usuario la variable global tenga datos
            }
            else{
                producto = new EntidadProducto();
            }

            producto.setDescripcion(txtDescripcion.Text);
            producto.PrecioCompra = float.Parse(txtPrecioCompra.Text);
            producto.PrecioVenta = float.Parse(txtPrecioVenta.Text);

            if(CHGravado.Checked){
                producto.Gravado = "SI";
            }else{
                producto.Gravado = "NO";
            }
            
            return producto;
        }


        private void BtnGuardar_Click(object sender, EventArgs e) {
            EntidadProducto producto;
            BLProducto logica = new BLProducto(Configuracion.getConnectionString);//Obtiene la cadena de conexion y se la envia a la capa logica
            int resultado;
            try {
                if (string.IsNullOrEmpty(txtDescripcion.Text) || float.IsNaN(float.Parse( txtPrecioCompra.Text)) ||
                    float.IsNaN(float.Parse(txtPrecioVenta.Text))) {
                    MessageBox.Show("Datos incompletos, favor, complete todos los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else {

                    producto = GenerarEntidadProducto();
                    if(!producto.Existe){
                        resultado = logica.Insertar(producto);
                    }
                    else{
                        resultado = logica.Modificar(producto);
                    }
                    if(resultado >0){
                        Limpiar();
                        MessageBox.Show("Operacion Realizada con éxito");
                        CargarListaDataSet();
                    }else{
                        MessageBox.Show("No se realizaron cambios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Reiniciar los texbox
        public void Limpiar() {
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtDescripcion.Text = "";
            CHGravado.Checked = false;
        }

        private void CargarListaDataSet(string condicion = "", string orden = "") {
            //cargar el datagridview con los datos del dataset
            BLProducto logica = new BLProducto(Configuracion.getConnectionString);
            DataSet DSProductos;

            try {
                DSProductos = logica.ListarProductos(condicion, orden);
                GrdProductos.DataSource = DSProductos;
                GrdProductos.DataMember = DSProductos.Tables["Productos"].TableName;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e) {
            formularioProductobuscar = new FrmBuscarProducto();

            formularioProductobuscar.Aceptar += new EventHandler(Aceptar);
            formularioProductobuscar.ShowDialog();

        }

        private void Aceptar(object id, EventArgs e) {
            try {
                int idproducto = (int)id;
                if (idproducto != -1) {
                    //MessageBox.Show(idproducto.ToString());
                    CargarProducto(idproducto);
                }
                else {
                    Limpiar();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FrmProducto_Load(object sender, EventArgs e) {
            try {
                CargarListaDataSet();
                
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void CargarProducto(int id) {
            EntidadProducto producto = new EntidadProducto();
            BLProducto traerProducto = new BLProducto(Configuracion.getConnectionString);
            try {
                producto = traerProducto.ObtenerProducto(id);
                if (producto != null) {
     
                    TxtID.Text = producto.Id_producto.ToString();
                    txtDescripcion.Text = producto.Descripcion.ToString();
                    txtPrecioCompra.Text = producto.PrecioCompra.ToString();
                    txtPrecioVenta.Text = producto.PrecioVenta.ToString();
                    if(producto.Gravado == "SI"){
                        CHGravado.Checked = true;
                    }else{
                        CHGravado.Checked=false;
                    }

                    productoRegistrado = producto;
                    
                }
                else {
                    MessageBox.Show("El cliente no se encuentra", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarListaDataSet();

        }





        private void seleccionar() {
            if (GrdProductos.SelectedRows.Count > 0) {
                vgn_idproducto = (int)GrdProductos.SelectedRows[0].Cells[0].Value;
                //Le manda el id al evento aceptar que esta en frmProducto
                Aceptar(vgn_idproducto, null);
            }
        }//----------------------

        private void GrdProductos_DoubleClick(object sender, EventArgs e) {
            seleccionar();
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            int resultado;//El eliminado devuelve un entero y se envia una entidad
            EntidadProducto producto = new EntidadProducto();
            BLProducto traerProducto = new BLProducto(Configuracion.getConnectionString);

            try{
                if(!string.IsNullOrEmpty(TxtID.Text)){
                    //primero se busca el cliente antes de eliminarlo
                    producto = traerProducto.ObtenerProducto(int.Parse(TxtID.Text));//cuando obtiene el dato revisa si existe un dato                }else{
                    if(producto.Existe){
                        resultado = traerProducto.EliminarProducto(producto);
                        Limpiar();
                        CargarListaDataSet();
                    }
                    else{
                        MessageBox.Show("El cliente no existe", "Aviso", MessageBoxButtons.OK);
                        Limpiar();
                        CargarListaDataSet();
                    }
                }else{
                    MessageBox.Show("Debe seleccionar un cliente antes de eliminarlo", "Aviso", MessageBoxButtons.OK);
                }
            
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

        }//-------------------------------------------

        private void BtnSalir_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
