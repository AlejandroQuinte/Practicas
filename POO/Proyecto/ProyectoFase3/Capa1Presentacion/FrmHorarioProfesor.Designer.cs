namespace Capa1Presentacion {
    partial class FrmHorarioProfesor {
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
            this.txtHoraFinal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoraInicio = new System.Windows.Forms.TextBox();
            this.txtFechaInicio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFechaFinal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtIdProfesor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.GrdHorarioProfesor = new System.Windows.Forms.DataGridView();
            this.idClaseSincronica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstudiante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProfesor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdHorarioProfesor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrdHorarioProfesor)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHoraFinal
            // 
            this.txtHoraFinal.Location = new System.Drawing.Point(237, 53);
            this.txtHoraFinal.Name = "txtHoraFinal";
            this.txtHoraFinal.Size = new System.Drawing.Size(193, 23);
            this.txtHoraFinal.TabIndex = 154;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 153;
            this.label5.Text = "Hora Final";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 152;
            this.label4.Text = "Hora Inicio";
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.Location = new System.Drawing.Point(12, 137);
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.Size = new System.Drawing.Size(219, 23);
            this.txtHoraInicio.TabIndex = 151;
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.Location = new System.Drawing.Point(237, 111);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(193, 23);
            this.txtFechaInicio.TabIndex = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 149;
            this.label3.Text = "Fecha Inicio";
            // 
            // txtFechaFinal
            // 
            this.txtFechaFinal.Location = new System.Drawing.Point(436, 53);
            this.txtFechaFinal.Name = "txtFechaFinal";
            this.txtFechaFinal.Size = new System.Drawing.Size(193, 23);
            this.txtFechaFinal.TabIndex = 148;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(436, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 147;
            this.label2.Text = "Fecha Final";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(436, 111);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(193, 23);
            this.txtEstado.TabIndex = 146;
            // 
            // txtIdProfesor
            // 
            this.txtIdProfesor.Location = new System.Drawing.Point(12, 85);
            this.txtIdProfesor.Name = "txtIdProfesor";
            this.txtIdProfesor.Size = new System.Drawing.Size(219, 23);
            this.txtIdProfesor.TabIndex = 145;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.TabIndex = 144;
            this.label7.Text = "ID Profesor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(436, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 143;
            this.label6.Text = "Estado";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(12, 374);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(134, 65);
            this.BtnGuardar.TabIndex = 142;
            this.BtnGuardar.Text = "Guardar o Modificar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(175, 374);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 65);
            this.BtnBuscar.TabIndex = 141;
            this.BtnBuscar.Text = "&Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(279, 374);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 65);
            this.BtnNuevo.TabIndex = 140;
            this.BtnNuevo.Text = "&Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(383, 374);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 65);
            this.BtnEliminar.TabIndex = 139;
            this.BtnEliminar.Text = "&Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(571, 412);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(64, 27);
            this.BtnSalir.TabIndex = 138;
            this.BtnSalir.Text = "&Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // GrdHorarioProfesor
            // 
            this.GrdHorarioProfesor.AllowUserToAddRows = false;
            this.GrdHorarioProfesor.AllowUserToDeleteRows = false;
            this.GrdHorarioProfesor.AllowUserToResizeColumns = false;
            this.GrdHorarioProfesor.AllowUserToResizeRows = false;
            this.GrdHorarioProfesor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdHorarioProfesor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idClaseSincronica,
            this.idEstudiante,
            this.idProfesor,
            this.idCurso,
            this.fechaClase,
            this.horaInicio,
            this.horaFinal});
            this.GrdHorarioProfesor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GrdHorarioProfesor.Location = new System.Drawing.Point(12, 176);
            this.GrdHorarioProfesor.Name = "GrdHorarioProfesor";
            this.GrdHorarioProfesor.RowTemplate.Height = 25;
            this.GrdHorarioProfesor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdHorarioProfesor.Size = new System.Drawing.Size(623, 179);
            this.GrdHorarioProfesor.TabIndex = 137;
            this.GrdHorarioProfesor.DoubleClick += new System.EventHandler(this.GrdClaseSincronica_DoubleClick);
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
            // txtIdHorarioProfesor
            // 
            this.txtIdHorarioProfesor.BackColor = System.Drawing.SystemColors.Window;
            this.txtIdHorarioProfesor.Location = new System.Drawing.Point(12, 27);
            this.txtIdHorarioProfesor.Name = "txtIdHorarioProfesor";
            this.txtIdHorarioProfesor.Size = new System.Drawing.Size(219, 23);
            this.txtIdHorarioProfesor.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 135;
            this.label1.Text = "ID Horario Profesor";
            // 
            // FrmHorarioProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 473);
            this.Controls.Add(this.txtHoraFinal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHoraInicio);
            this.Controls.Add(this.txtFechaInicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFechaFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtIdProfesor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.GrdHorarioProfesor);
            this.Controls.Add(this.txtIdHorarioProfesor);
            this.Controls.Add(this.label1);
            this.Name = "FrmHorarioProfesor";
            this.Text = "FrmHorarioProfesor";
            this.Load += new System.EventHandler(this.FrmHorarioProfesor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdHorarioProfesor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHoraFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoraInicio;
        private System.Windows.Forms.TextBox txtFechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFechaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtIdProfesor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridView GrdHorarioProfesor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClaseSincronica;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstudiante;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProfesor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaClase;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaFinal;
        private System.Windows.Forms.TextBox txtIdHorarioProfesor;
        private System.Windows.Forms.Label label1;
    }
}