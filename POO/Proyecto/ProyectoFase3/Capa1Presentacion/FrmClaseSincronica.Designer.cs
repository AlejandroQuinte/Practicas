namespace Capa1Presentacion {
    partial class FrmClaseSincronica {
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
            this.txtIdProfesor = new System.Windows.Forms.TextBox();
            this.txtIdEstudiante = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.GrdClaseSincronica = new System.Windows.Forms.DataGridView();
            this.idClaseSincronica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstudiante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProfesor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdClaseSincronica = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdCurso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DTFechaClase = new System.Windows.Forms.DateTimePicker();
            this.DTHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.DTHoraFinal = new System.Windows.Forms.DateTimePicker();
            this.btnSelectIdEstudiante = new System.Windows.Forms.Button();
            this.btnSelectIdProfesor = new System.Windows.Forms.Button();
            this.txtMateria = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrdClaseSincronica)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdProfesor
            // 
            this.txtIdProfesor.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtIdProfesor.Enabled = false;
            this.txtIdProfesor.Location = new System.Drawing.Point(27, 145);
            this.txtIdProfesor.Name = "txtIdProfesor";
            this.txtIdProfesor.Size = new System.Drawing.Size(107, 23);
            this.txtIdProfesor.TabIndex = 126;
            // 
            // txtIdEstudiante
            // 
            this.txtIdEstudiante.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtIdEstudiante.Enabled = false;
            this.txtIdEstudiante.Location = new System.Drawing.Point(27, 91);
            this.txtIdEstudiante.Name = "txtIdEstudiante";
            this.txtIdEstudiante.Size = new System.Drawing.Size(107, 23);
            this.txtIdEstudiante.TabIndex = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 124;
            this.label7.Text = "ID Estudiante";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 123;
            this.label6.Text = "ID Profesor";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(27, 380);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(134, 65);
            this.BtnGuardar.TabIndex = 122;
            this.BtnGuardar.Text = "Guardar o Modificar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(190, 380);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 65);
            this.BtnBuscar.TabIndex = 121;
            this.BtnBuscar.Text = "&Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(294, 380);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 65);
            this.BtnNuevo.TabIndex = 120;
            this.BtnNuevo.Text = "&Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(398, 380);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 65);
            this.BtnEliminar.TabIndex = 119;
            this.BtnEliminar.Text = "&Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(586, 418);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(64, 27);
            this.BtnSalir.TabIndex = 118;
            this.BtnSalir.Text = "&Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // GrdClaseSincronica
            // 
            this.GrdClaseSincronica.AllowUserToAddRows = false;
            this.GrdClaseSincronica.AllowUserToDeleteRows = false;
            this.GrdClaseSincronica.AllowUserToResizeColumns = false;
            this.GrdClaseSincronica.AllowUserToResizeRows = false;
            this.GrdClaseSincronica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdClaseSincronica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idClaseSincronica,
            this.idEstudiante,
            this.idProfesor,
            this.idCurso,
            this.fechaClase,
            this.horaInicio,
            this.horaFinal});
            this.GrdClaseSincronica.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GrdClaseSincronica.Location = new System.Drawing.Point(27, 182);
            this.GrdClaseSincronica.Name = "GrdClaseSincronica";
            this.GrdClaseSincronica.RowTemplate.Height = 25;
            this.GrdClaseSincronica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdClaseSincronica.Size = new System.Drawing.Size(623, 179);
            this.GrdClaseSincronica.TabIndex = 117;
            this.GrdClaseSincronica.DoubleClick += new System.EventHandler(this.GrdNotaMateria_DoubleClick);
            // 
            // idClaseSincronica
            // 
            this.idClaseSincronica.DataPropertyName = "ID_ClaseSincronica";
            this.idClaseSincronica.HeaderText = "ID Clase Sincronica";
            this.idClaseSincronica.Name = "idClaseSincronica";
            this.idClaseSincronica.Width = 70;
            // 
            // idEstudiante
            // 
            this.idEstudiante.DataPropertyName = "ID_Estudiante";
            this.idEstudiante.HeaderText = "ID Estudiante";
            this.idEstudiante.Name = "idEstudiante";
            this.idEstudiante.Width = 70;
            // 
            // idProfesor
            // 
            this.idProfesor.DataPropertyName = "ID_Profesor";
            this.idProfesor.HeaderText = "ID Profesor";
            this.idProfesor.Name = "idProfesor";
            this.idProfesor.Width = 70;
            // 
            // idCurso
            // 
            this.idCurso.DataPropertyName = "ID_Curso";
            this.idCurso.HeaderText = "ID Curso";
            this.idCurso.Name = "idCurso";
            this.idCurso.Width = 70;
            // 
            // fechaClase
            // 
            this.fechaClase.DataPropertyName = "FechaClase";
            this.fechaClase.HeaderText = "Fecha Clase";
            this.fechaClase.Name = "fechaClase";
            // 
            // horaInicio
            // 
            this.horaInicio.DataPropertyName = "HoraInicio";
            this.horaInicio.HeaderText = "Hora Inicio";
            this.horaInicio.Name = "horaInicio";
            // 
            // horaFinal
            // 
            this.horaFinal.DataPropertyName = "HoraFinal";
            this.horaFinal.HeaderText = "Hora Final";
            this.horaFinal.Name = "horaFinal";
            // 
            // txtIdClaseSincronica
            // 
            this.txtIdClaseSincronica.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtIdClaseSincronica.Enabled = false;
            this.txtIdClaseSincronica.Location = new System.Drawing.Point(27, 33);
            this.txtIdClaseSincronica.Name = "txtIdClaseSincronica";
            this.txtIdClaseSincronica.Size = new System.Drawing.Size(219, 23);
            this.txtIdClaseSincronica.TabIndex = 116;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 115;
            this.label1.Text = "ID Clase Sincronica";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 127;
            this.label2.Text = "ID Curso";
            // 
            // txtIdCurso
            // 
            this.txtIdCurso.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtIdCurso.Enabled = false;
            this.txtIdCurso.Location = new System.Drawing.Point(252, 59);
            this.txtIdCurso.Name = "txtIdCurso";
            this.txtIdCurso.Size = new System.Drawing.Size(95, 23);
            this.txtIdCurso.TabIndex = 128;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 129;
            this.label3.Text = "Fecha de la clase";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 132;
            this.label4.Text = "Hora Inicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(457, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 133;
            this.label5.Text = "Hora Final";
            // 
            // DTFechaClase
            // 
            this.DTFechaClase.Location = new System.Drawing.Point(252, 117);
            this.DTFechaClase.MinDate = new System.DateTime(2022, 2, 12, 15, 27, 34, 0);
            this.DTFechaClase.Name = "DTFechaClase";
            this.DTFechaClase.Size = new System.Drawing.Size(199, 23);
            this.DTFechaClase.TabIndex = 138;
            this.DTFechaClase.Value = new System.DateTime(2022, 2, 12, 15, 27, 34, 0);
            // 
            // DTHoraInicio
            // 
            this.DTHoraInicio.CustomFormat = "";
            this.DTHoraInicio.Location = new System.Drawing.Point(457, 59);
            this.DTHoraInicio.Name = "DTHoraInicio";
            this.DTHoraInicio.Size = new System.Drawing.Size(193, 23);
            this.DTHoraInicio.TabIndex = 139;
            // 
            // DTHoraFinal
            // 
            this.DTHoraFinal.CustomFormat = "";
            this.DTHoraFinal.Location = new System.Drawing.Point(457, 117);
            this.DTHoraFinal.Name = "DTHoraFinal";
            this.DTHoraFinal.Size = new System.Drawing.Size(193, 23);
            this.DTHoraFinal.TabIndex = 140;
            // 
            // btnSelectIdEstudiante
            // 
            this.btnSelectIdEstudiante.Location = new System.Drawing.Point(140, 90);
            this.btnSelectIdEstudiante.Name = "btnSelectIdEstudiante";
            this.btnSelectIdEstudiante.Size = new System.Drawing.Size(106, 23);
            this.btnSelectIdEstudiante.TabIndex = 141;
            this.btnSelectIdEstudiante.Text = "Seleccionar";
            this.btnSelectIdEstudiante.UseVisualStyleBackColor = true;
            this.btnSelectIdEstudiante.Click += new System.EventHandler(this.btnSelectIdEstudiante_Click);
            // 
            // btnSelectIdProfesor
            // 
            this.btnSelectIdProfesor.Location = new System.Drawing.Point(140, 144);
            this.btnSelectIdProfesor.Name = "btnSelectIdProfesor";
            this.btnSelectIdProfesor.Size = new System.Drawing.Size(106, 23);
            this.btnSelectIdProfesor.TabIndex = 142;
            this.btnSelectIdProfesor.Text = "Seleccionar";
            this.btnSelectIdProfesor.UseVisualStyleBackColor = true;
            // 
            // txtMateria
            // 
            this.txtMateria.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtMateria.Enabled = false;
            this.txtMateria.Location = new System.Drawing.Point(353, 59);
            this.txtMateria.Name = "txtMateria";
            this.txtMateria.Size = new System.Drawing.Size(100, 23);
            this.txtMateria.TabIndex = 143;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(353, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 15);
            this.label8.TabIndex = 144;
            this.label8.Text = "Materia";
            // 
            // FrmClaseSincronica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(673, 480);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMateria);
            this.Controls.Add(this.btnSelectIdProfesor);
            this.Controls.Add(this.btnSelectIdEstudiante);
            this.Controls.Add(this.DTHoraFinal);
            this.Controls.Add(this.DTHoraInicio);
            this.Controls.Add(this.DTFechaClase);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdCurso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdProfesor);
            this.Controls.Add(this.txtIdEstudiante);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.GrdClaseSincronica);
            this.Controls.Add(this.txtIdClaseSincronica);
            this.Controls.Add(this.label1);
            this.Name = "FrmClaseSincronica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmClaseSincronica";
            this.Load += new System.EventHandler(this.FrmClaseSincronica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdClaseSincronica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdProfesor;
        private System.Windows.Forms.TextBox txtIdEstudiante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridView GrdClaseSincronica;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClaseSincronica;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstudiante;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProfesor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaClase;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaFinal;
        private System.Windows.Forms.TextBox txtIdClaseSincronica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdCurso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.DateTimePicker DTFechaClase;
        private System.Windows.Forms.DateTimePicker DTHoraInicio;
        private System.Windows.Forms.DateTimePicker DTHoraFinal;
        private System.Windows.Forms.Button btnSelectIdEstudiante;
        private System.Windows.Forms.Button btnSelectIdProfesor;
        private System.Windows.Forms.TextBox txtMateria;
        private System.Windows.Forms.Label label8;
    }
}