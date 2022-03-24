namespace Capa1Presentacion {
    partial class FrmMatricula {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtPagoTotal = new System.Windows.Forms.TextBox();
            this.txtIdCurso = new System.Windows.Forms.TextBox();
            this.txtIdEstudiante = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.GrdMatricula = new System.Windows.Forms.DataGridView();
            this.idMatricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstudiante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intensidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fehchaMatricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdMatricula = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEstadoPago = new System.Windows.Forms.TextBox();
            this.CBIntensidad = new System.Windows.Forms.ComboBox();
            this.DTFechaMatricula = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.CBCurso = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCantHoras = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnSelecEstudiante = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNombreCurso = new System.Windows.Forms.TextBox();
            this.btnSelecCurso = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.DTFechaTerminado = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCantHorasDias = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GrdMatricula)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPagoTotal
            // 
            this.txtPagoTotal.Location = new System.Drawing.Point(441, 156);
            this.txtPagoTotal.Name = "txtPagoTotal";
            this.txtPagoTotal.Size = new System.Drawing.Size(117, 23);
            this.txtPagoTotal.TabIndex = 84;
            this.txtPagoTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPagoTotal_KeyPress);
            this.txtPagoTotal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPagoTotal_KeyUp);
            // 
            // txtIdCurso
            // 
            this.txtIdCurso.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtIdCurso.Enabled = false;
            this.txtIdCurso.Location = new System.Drawing.Point(28, 156);
            this.txtIdCurso.Name = "txtIdCurso";
            this.txtIdCurso.Size = new System.Drawing.Size(148, 23);
            this.txtIdCurso.TabIndex = 82;
            // 
            // txtIdEstudiante
            // 
            this.txtIdEstudiante.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtIdEstudiante.Enabled = false;
            this.txtIdEstudiante.Location = new System.Drawing.Point(28, 99);
            this.txtIdEstudiante.Name = "txtIdEstudiante";
            this.txtIdEstudiante.Size = new System.Drawing.Size(148, 23);
            this.txtIdEstudiante.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 80;
            this.label7.Text = "ID Estudiante";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 79;
            this.label6.Text = "ID Curso";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 78;
            this.label5.Text = "Fecha Matricula";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 77;
            this.label4.Text = "Pago Total";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(28, 402);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(134, 65);
            this.BtnGuardar.TabIndex = 76;
            this.BtnGuardar.Text = "Guardar o Modificar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(191, 402);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 65);
            this.BtnBuscar.TabIndex = 75;
            this.BtnBuscar.Text = "&Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(308, 402);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 65);
            this.BtnNuevo.TabIndex = 74;
            this.BtnNuevo.Text = "&Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(425, 402);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 65);
            this.BtnEliminar.TabIndex = 73;
            this.BtnEliminar.Text = "&Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(609, 440);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(64, 27);
            this.BtnSalir.TabIndex = 72;
            this.BtnSalir.Text = "&Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // GrdMatricula
            // 
            this.GrdMatricula.AllowUserToAddRows = false;
            this.GrdMatricula.AllowUserToDeleteRows = false;
            this.GrdMatricula.AllowUserToResizeColumns = false;
            this.GrdMatricula.AllowUserToResizeRows = false;
            this.GrdMatricula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdMatricula.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMatricula,
            this.idEstudiante,
            this.idCurso,
            this.intensidad,
            this.fehchaMatricula,
            this.pagoTotal,
            this.estado});
            this.GrdMatricula.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GrdMatricula.Location = new System.Drawing.Point(28, 204);
            this.GrdMatricula.Name = "GrdMatricula";
            this.GrdMatricula.RowTemplate.Height = 25;
            this.GrdMatricula.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdMatricula.Size = new System.Drawing.Size(605, 179);
            this.GrdMatricula.TabIndex = 71;
            this.GrdMatricula.DoubleClick += new System.EventHandler(this.GrdEstudiante_DoubleClick);
            // 
            // idMatricula
            // 
            this.idMatricula.DataPropertyName = "ID_Matricula";
            this.idMatricula.HeaderText = "ID Matricula";
            this.idMatricula.Name = "idMatricula";
            this.idMatricula.Width = 70;
            // 
            // idEstudiante
            // 
            this.idEstudiante.DataPropertyName = "ID_Estudiantes";
            this.idEstudiante.HeaderText = "ID Estudiante";
            this.idEstudiante.Name = "idEstudiante";
            this.idEstudiante.Width = 70;
            // 
            // idCurso
            // 
            this.idCurso.DataPropertyName = "ID_Curso";
            this.idCurso.HeaderText = "ID Curso";
            this.idCurso.Name = "idCurso";
            this.idCurso.Width = 70;
            // 
            // intensidad
            // 
            this.intensidad.DataPropertyName = "Intensidad";
            this.intensidad.HeaderText = "Intensidad";
            this.intensidad.Name = "intensidad";
            this.intensidad.Width = 70;
            // 
            // fehchaMatricula
            // 
            this.fehchaMatricula.DataPropertyName = "FechaMatricula";
            this.fehchaMatricula.HeaderText = "Fecha Matricula";
            this.fehchaMatricula.Name = "fehchaMatricula";
            // 
            // pagoTotal
            // 
            this.pagoTotal.DataPropertyName = "TotalPago";
            this.pagoTotal.HeaderText = "Pago Total";
            this.pagoTotal.Name = "pagoTotal";
            this.pagoTotal.Width = 85;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "EstadoPago";
            this.estado.HeaderText = "Estado Pago";
            this.estado.Name = "estado";
            this.estado.Width = 95;
            // 
            // txtIdMatricula
            // 
            this.txtIdMatricula.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtIdMatricula.Enabled = false;
            this.txtIdMatricula.Location = new System.Drawing.Point(28, 36);
            this.txtIdMatricula.Name = "txtIdMatricula";
            this.txtIdMatricula.Size = new System.Drawing.Size(148, 23);
            this.txtIdMatricula.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 68;
            this.label2.Text = "Intensidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 67;
            this.label1.Text = "ID Matricula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(568, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 85;
            this.label3.Text = "Estado Pago";
            // 
            // txtEstadoPago
            // 
            this.txtEstadoPago.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtEstadoPago.Enabled = false;
            this.txtEstadoPago.Location = new System.Drawing.Point(568, 99);
            this.txtEstadoPago.Name = "txtEstadoPago";
            this.txtEstadoPago.Size = new System.Drawing.Size(113, 23);
            this.txtEstadoPago.TabIndex = 86;
            // 
            // CBIntensidad
            // 
            this.CBIntensidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBIntensidad.FormattingEnabled = true;
            this.CBIntensidad.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.CBIntensidad.Location = new System.Drawing.Point(470, 99);
            this.CBIntensidad.Name = "CBIntensidad";
            this.CBIntensidad.Size = new System.Drawing.Size(92, 23);
            this.CBIntensidad.TabIndex = 87;
            this.CBIntensidad.SelectedIndexChanged += new System.EventHandler(this.CBIntensidad_SelectedIndexChanged);
            // 
            // DTFechaMatricula
            // 
            this.DTFechaMatricula.CalendarMonthBackground = System.Drawing.SystemColors.MenuBar;
            this.DTFechaMatricula.Enabled = false;
            this.DTFechaMatricula.Location = new System.Drawing.Point(182, 36);
            this.DTFechaMatricula.Name = "DTFechaMatricula";
            this.DTFechaMatricula.Size = new System.Drawing.Size(172, 23);
            this.DTFechaMatricula.TabIndex = 88;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(360, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 15);
            this.label8.TabIndex = 89;
            this.label8.Text = "Curso";
            // 
            // CBCurso
            // 
            this.CBCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCurso.FormattingEnabled = true;
            this.CBCurso.Items.AddRange(new object[] {
            "Inglés",
            "Francés",
            "Alemán",
            "Mandarín"});
            this.CBCurso.Location = new System.Drawing.Point(360, 36);
            this.CBCurso.Name = "CBCurso";
            this.CBCurso.Size = new System.Drawing.Size(109, 23);
            this.CBCurso.TabIndex = 90;
            this.CBCurso.SelectedIndexChanged += new System.EventHandler(this.CBCurso_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(475, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 15);
            this.label9.TabIndex = 91;
            this.label9.Text = "Cantidad de Horas";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(570, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 15);
            this.label10.TabIndex = 92;
            this.label10.Text = "Precio";
            // 
            // txtCantHoras
            // 
            this.txtCantHoras.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtCantHoras.Enabled = false;
            this.txtCantHoras.Location = new System.Drawing.Point(475, 36);
            this.txtCantHoras.Name = "txtCantHoras";
            this.txtCantHoras.Size = new System.Drawing.Size(105, 23);
            this.txtCantHoras.TabIndex = 93;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Location = new System.Drawing.Point(568, 156);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(113, 23);
            this.txtPrecio.TabIndex = 94;
            // 
            // btnSelecEstudiante
            // 
            this.btnSelecEstudiante.Location = new System.Drawing.Point(182, 98);
            this.btnSelecEstudiante.Name = "btnSelecEstudiante";
            this.btnSelecEstudiante.Size = new System.Drawing.Size(75, 23);
            this.btnSelecEstudiante.TabIndex = 95;
            this.btnSelecEstudiante.Text = "Seleccionar";
            this.btnSelecEstudiante.UseVisualStyleBackColor = true;
            this.btnSelecEstudiante.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(263, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 96;
            this.label11.Text = "Nombre Curso";
            // 
            // txtNombreCurso
            // 
            this.txtNombreCurso.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtNombreCurso.Enabled = false;
            this.txtNombreCurso.Location = new System.Drawing.Point(263, 155);
            this.txtNombreCurso.Name = "txtNombreCurso";
            this.txtNombreCurso.Size = new System.Drawing.Size(172, 23);
            this.txtNombreCurso.TabIndex = 97;
            // 
            // btnSelecCurso
            // 
            this.btnSelecCurso.Location = new System.Drawing.Point(182, 156);
            this.btnSelecCurso.Name = "btnSelecCurso";
            this.btnSelecCurso.Size = new System.Drawing.Size(75, 23);
            this.btnSelecCurso.TabIndex = 98;
            this.btnSelecCurso.Text = "Seleccionar";
            this.btnSelecCurso.UseVisualStyleBackColor = true;
            this.btnSelecCurso.Click += new System.EventHandler(this.btnSelecCurso_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(263, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 15);
            this.label12.TabIndex = 99;
            this.label12.Text = "Fecha de terminado";
            // 
            // DTFechaTerminado
            // 
            this.DTFechaTerminado.CalendarMonthBackground = System.Drawing.SystemColors.Menu;
            this.DTFechaTerminado.Enabled = false;
            this.DTFechaTerminado.Location = new System.Drawing.Point(263, 98);
            this.DTFechaTerminado.Name = "DTFechaTerminado";
            this.DTFechaTerminado.Size = new System.Drawing.Size(197, 23);
            this.DTFechaTerminado.TabIndex = 101;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(589, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 15);
            this.label13.TabIndex = 102;
            this.label13.Text = "Cant horas x dias";
            // 
            // txtCantHorasDias
            // 
            this.txtCantHorasDias.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtCantHorasDias.Enabled = false;
            this.txtCantHorasDias.Location = new System.Drawing.Point(586, 36);
            this.txtCantHorasDias.Name = "txtCantHorasDias";
            this.txtCantHorasDias.Size = new System.Drawing.Size(95, 23);
            this.txtCantHorasDias.TabIndex = 103;
            // 
            // FrmMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 517);
            this.Controls.Add(this.txtCantHorasDias);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DTFechaTerminado);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSelecCurso);
            this.Controls.Add(this.txtNombreCurso);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSelecEstudiante);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtCantHoras);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CBCurso);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DTFechaMatricula);
            this.Controls.Add(this.CBIntensidad);
            this.Controls.Add(this.txtEstadoPago);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPagoTotal);
            this.Controls.Add(this.txtIdCurso);
            this.Controls.Add(this.txtIdEstudiante);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.GrdMatricula);
            this.Controls.Add(this.txtIdMatricula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMatricula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMatricula";
            this.Load += new System.EventHandler(this.FrmMatricula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdMatricula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPagoTotal;
        private System.Windows.Forms.TextBox txtIdCurso;
        private System.Windows.Forms.TextBox txtIdEstudiante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridView GrdMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstudiante;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn intensidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn fehchaMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.TextBox txtIdMatricula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEstadoPago;
        private System.Windows.Forms.ComboBox CBIntensidad;
        private System.Windows.Forms.DateTimePicker DTFechaMatricula;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CBCurso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCantHoras;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnSelecEstudiante;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNombreCurso;
        private System.Windows.Forms.Button btnSelecCurso;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker DTFechaTerminado;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCantHorasDias;
    }
}