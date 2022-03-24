
namespace InterfazEscritorio
{
    partial class FrmClientesReservaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.grdLista = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotalNoches = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGuardarReservacion = new System.Windows.Forms.Button();
            this.cboCPersonas = new System.Windows.Forms.ComboBox();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboCancelada = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.dtpFSalida = new System.Windows.Forms.DateTimePicker();
            this.dtpFIngreso = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrecioNoche = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdReservacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.idreserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fsalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpersonas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Reservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Ingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadPersonas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioNoche = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cancelada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::InterfazEscritorio.Properties.Resources.Search_48x48;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(735, 54);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 57);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.SystemColors.Info;
            this.txtDireccion.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtDireccion.Location = new System.Drawing.Point(126, 88);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(586, 26);
            this.txtDireccion.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Dirección";
            // 
            // txttelefono
            // 
            this.txttelefono.BackColor = System.Drawing.SystemColors.Info;
            this.txttelefono.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txttelefono.Location = new System.Drawing.Point(587, 52);
            this.txttelefono.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.ReadOnly = true;
            this.txttelefono.Size = new System.Drawing.Size(125, 27);
            this.txttelefono.TabIndex = 15;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.Info;
            this.txtNombre.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNombre.Location = new System.Drawing.Point(126, 52);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(432, 27);
            this.txtNombre.TabIndex = 14;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.SystemColors.Info;
            this.txtIdCliente.Location = new System.Drawing.Point(19, 52);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(79, 27);
            this.txtIdCliente.TabIndex = 13;
            this.txtIdCliente.TextChanged += new System.EventHandler(this.txtIdCliente_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Teléfono";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Código";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.txtIdCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txttelefono);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(14, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(832, 124);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Cliente";
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::InterfazEscritorio.Properties.Resources.Close_48;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.Location = new System.Drawing.Point(749, 626);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(89, 45);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // grdLista
            // 
            this.grdLista.AllowUserToAddRows = false;
            this.grdLista.AllowUserToDeleteRows = false;
            this.grdLista.AllowUserToResizeColumns = false;
            this.grdLista.AllowUserToResizeRows = false;
            this.grdLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Reservacion,
            this.ID_Cliente,
            this.Fecha_Ingreso,
            this.FechaSalida,
            this.CantidadPersonas,
            this.TipoHabitacion,
            this.PrecioNoche,
            this.Cancelada,
            this.Total});
            this.grdLista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLista.Location = new System.Drawing.Point(6, 26);
            this.grdLista.Name = "grdLista";
            this.grdLista.RowTemplate.Height = 25;
            this.grdLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLista.Size = new System.Drawing.Size(818, 193);
            this.grdLista.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTotalNoches);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnGuardarReservacion);
            this.groupBox2.Controls.Add(this.cboCPersonas);
            this.groupBox2.Controls.Add(this.txtTotalPagar);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cboCancelada);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cboTipo);
            this.groupBox2.Controls.Add(this.dtpFSalida);
            this.groupBox2.Controls.Add(this.dtpFIngreso);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtPrecioNoche);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtIdReservacion);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(14, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(832, 210);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reservaciones";
            // 
            // txtTotalNoches
            // 
            this.txtTotalNoches.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalNoches.Location = new System.Drawing.Point(346, 112);
            this.txtTotalNoches.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotalNoches.Name = "txtTotalNoches";
            this.txtTotalNoches.ReadOnly = true;
            this.txtTotalNoches.Size = new System.Drawing.Size(200, 27);
            this.txtTotalNoches.TabIndex = 33;
            this.txtTotalNoches.TextChanged += new System.EventHandler(this.txtTotalNoches_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(248, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 20);
            this.label13.TabIndex = 32;
            this.label13.Text = "Total Días";
            // 
            // btnGuardarReservacion
            // 
            this.btnGuardarReservacion.Image = global::InterfazEscritorio.Properties.Resources.save_48;
            this.btnGuardarReservacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarReservacion.Location = new System.Drawing.Point(713, 157);
            this.btnGuardarReservacion.Name = "btnGuardarReservacion";
            this.btnGuardarReservacion.Size = new System.Drawing.Size(111, 39);
            this.btnGuardarReservacion.TabIndex = 9;
            this.btnGuardarReservacion.Text = "&Guardar";
            this.btnGuardarReservacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarReservacion.UseVisualStyleBackColor = true;
            this.btnGuardarReservacion.Click += new System.EventHandler(this.btnGuardarReservacion_Click);
            // 
            // cboCPersonas
            // 
            this.cboCPersonas.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cboCPersonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCPersonas.FormattingEnabled = true;
            this.cboCPersonas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cboCPersonas.Location = new System.Drawing.Point(122, 69);
            this.cboCPersonas.Name = "cboCPersonas";
            this.cboCPersonas.Size = new System.Drawing.Size(120, 28);
            this.cboCPersonas.TabIndex = 2;
            this.cboCPersonas.SelectedIndexChanged += new System.EventHandler(this.cboCPersonas_SelectedIndexChanged);
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalPagar.Location = new System.Drawing.Point(670, 112);
            this.txtTotalPagar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.ReadOnly = true;
            this.txtTotalPagar.Size = new System.Drawing.Size(155, 27);
            this.txtTotalPagar.TabIndex = 6;
            this.txtTotalPagar.TextChanged += new System.EventHandler(this.txtTotalPagar_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(573, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 20);
            this.label12.TabIndex = 31;
            this.label12.Text = "Total Pagar";
            // 
            // cboCancelada
            // 
            this.cboCancelada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCancelada.FormattingEnabled = true;
            this.cboCancelada.Items.AddRange(new object[] {
            "PENDIENTE",
            "CANCELADO"});
            this.cboCancelada.Location = new System.Drawing.Point(122, 111);
            this.cboCancelada.Name = "cboCancelada";
            this.cboCancelada.Size = new System.Drawing.Size(120, 28);
            this.cboCancelada.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "Estado";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "JUNIOR",
            "STANDARD",
            "DELUXE"});
            this.cboTipo.Location = new System.Drawing.Point(722, 30);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(103, 28);
            this.cboTipo.TabIndex = 7;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // dtpFSalida
            // 
            this.dtpFSalida.CalendarForeColor = System.Drawing.SystemColors.Info;
            this.dtpFSalida.Location = new System.Drawing.Point(346, 70);
            this.dtpFSalida.Name = "dtpFSalida";
            this.dtpFSalida.Size = new System.Drawing.Size(200, 27);
            this.dtpFSalida.TabIndex = 5;
            this.dtpFSalida.ValueChanged += new System.EventHandler(this.dtpFSalida_ValueChanged);
            // 
            // dtpFIngreso
            // 
            this.dtpFIngreso.CalendarForeColor = System.Drawing.SystemColors.Info;
            this.dtpFIngreso.Location = new System.Drawing.Point(346, 31);
            this.dtpFIngreso.Name = "dtpFIngreso";
            this.dtpFIngreso.Size = new System.Drawing.Size(200, 27);
            this.dtpFIngreso.TabIndex = 4;
            this.dtpFIngreso.ValueChanged += new System.EventHandler(this.dtpFIngreso_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(573, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Precio Noche  P/P";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(573, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Tipo Habitación";
            // 
            // txtPrecioNoche
            // 
            this.txtPrecioNoche.BackColor = System.Drawing.SystemColors.Info;
            this.txtPrecioNoche.Location = new System.Drawing.Point(722, 70);
            this.txtPrecioNoche.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecioNoche.Name = "txtPrecioNoche";
            this.txtPrecioNoche.ReadOnly = true;
            this.txtPrecioNoche.Size = new System.Drawing.Size(103, 27);
            this.txtPrecioNoche.TabIndex = 8;
            this.txtPrecioNoche.TextChanged += new System.EventHandler(this.txtPrecioNoche_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Num. Personas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Fecha Salida";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Fecha Ingreso";
            // 
            // txtIdReservacion
            // 
            this.txtIdReservacion.BackColor = System.Drawing.SystemColors.Info;
            this.txtIdReservacion.Location = new System.Drawing.Point(122, 31);
            this.txtIdReservacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIdReservacion.Name = "txtIdReservacion";
            this.txtIdReservacion.ReadOnly = true;
            this.txtIdReservacion.Size = new System.Drawing.Size(120, 27);
            this.txtIdReservacion.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "ID. Reservación";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::InterfazEscritorio.Properties.Resources.Nuevo;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.Location = new System.Drawing.Point(615, 626);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(111, 45);
            this.btnLimpiar.TabIndex = 34;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdLista);
            this.groupBox3.Location = new System.Drawing.Point(20, 375);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(831, 236);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Historial de Reservaciones";
            // 
            // idreserva
            // 
            this.idreserva.DataPropertyName = "NUMRESERVACION";
            this.idreserva.HeaderText = "Id Reserva";
            this.idreserva.Name = "idreserva";
            this.idreserva.Width = 80;
            // 
            // idCliente
            // 
            this.idCliente.DataPropertyName = "ID_CLIENTE";
            this.idCliente.HeaderText = "idCliente";
            this.idCliente.Name = "idCliente";
            this.idCliente.Visible = false;
            // 
            // fingreso
            // 
            this.fingreso.DataPropertyName = "FECHAINGRESO";
            this.fingreso.HeaderText = "Fecha Ingreso";
            this.fingreso.Name = "fingreso";
            this.fingreso.Width = 125;
            // 
            // fsalida
            // 
            this.fsalida.DataPropertyName = "FECHASALIDA";
            this.fsalida.HeaderText = "Fecha Salida";
            this.fsalida.Name = "fsalida";
            this.fsalida.Width = 125;
            // 
            // cpersonas
            // 
            this.cpersonas.DataPropertyName = "CANTIDADPERSONAS";
            this.cpersonas.HeaderText = "Cantidad Personas";
            this.cpersonas.Name = "cpersonas";
            this.cpersonas.Width = 80;
            // 
            // thabitacion
            // 
            this.thabitacion.DataPropertyName = "TIPOHABITACION";
            this.thabitacion.HeaderText = "Tipo Habitacion";
            this.thabitacion.Name = "thabitacion";
            this.thabitacion.Width = 130;
            // 
            // Id_Reservacion
            // 
            this.Id_Reservacion.DataPropertyName = "NUMRESERVACION";
            this.Id_Reservacion.HeaderText = "Id_Reservacion";
            this.Id_Reservacion.Name = "Id_Reservacion";
            // 
            // ID_Cliente
            // 
            this.ID_Cliente.DataPropertyName = "ID_CLIENTE";
            this.ID_Cliente.HeaderText = "ID_Cliente";
            this.ID_Cliente.Name = "ID_Cliente";
            this.ID_Cliente.Visible = false;
            // 
            // Fecha_Ingreso
            // 
            this.Fecha_Ingreso.DataPropertyName = "FECHAINGRESO";
            this.Fecha_Ingreso.HeaderText = "Fecha Ingreso";
            this.Fecha_Ingreso.Name = "Fecha_Ingreso";
            this.Fecha_Ingreso.Width = 120;
            // 
            // FechaSalida
            // 
            this.FechaSalida.DataPropertyName = "FECHASALIDA";
            this.FechaSalida.HeaderText = "Fecha Salida";
            this.FechaSalida.Name = "FechaSalida";
            this.FechaSalida.Width = 120;
            // 
            // CantidadPersonas
            // 
            this.CantidadPersonas.DataPropertyName = "CANTIDADPERSONAS";
            this.CantidadPersonas.HeaderText = "Cantidad Personas";
            this.CantidadPersonas.Name = "CantidadPersonas";
            // 
            // TipoHabitacion
            // 
            this.TipoHabitacion.DataPropertyName = "TIPOHABITACION";
            this.TipoHabitacion.HeaderText = "Tipo Habitación";
            this.TipoHabitacion.Name = "TipoHabitacion";
            this.TipoHabitacion.Width = 140;
            // 
            // PrecioNoche
            // 
            this.PrecioNoche.DataPropertyName = "PRECIO_NOCHE";
            this.PrecioNoche.HeaderText = "Precio Noche";
            this.PrecioNoche.Name = "PrecioNoche";
            this.PrecioNoche.Visible = false;
            // 
            // Cancelada
            // 
            this.Cancelada.DataPropertyName = "CANCELADA";
            this.Cancelada.HeaderText = "Cancelada";
            this.Cancelada.Name = "Cancelada";
            this.Cancelada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cancelada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "TOTALPAGAR";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // FrmClientesReservaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 689);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmClientesReservaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes y Reservaciones";
            this.Load += new System.EventHandler(this.FrmClientesReservaciones_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView grdLista;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpFSalida;
        private System.Windows.Forms.DateTimePicker dtpFIngreso;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrecioNoche;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdReservacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboCancelada;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.ComboBox cboCPersonas;
        private System.Windows.Forms.Button btnGuardarReservacion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTotalNoches;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idreserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fsalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpersonas;
        private System.Windows.Forms.DataGridViewTextBoxColumn thabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Reservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Ingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadPersonas;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioNoche;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cancelada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}