namespace Capa1Presentacion {
    partial class FrmCertificacion {
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
            this.txtMateria = new System.Windows.Forms.TextBox();
            this.txtIdProfesor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.GrdCertificacion = new System.Windows.Forms.DataGridView();
            this.idCertificado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProfesor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdCertificado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCertificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMateria
            // 
            this.txtMateria.Location = new System.Drawing.Point(126, 105);
            this.txtMateria.Name = "txtMateria";
            this.txtMateria.Size = new System.Drawing.Size(215, 23);
            this.txtMateria.TabIndex = 114;
            // 
            // txtIdProfesor
            // 
            this.txtIdProfesor.Location = new System.Drawing.Point(242, 27);
            this.txtIdProfesor.Name = "txtIdProfesor";
            this.txtIdProfesor.Size = new System.Drawing.Size(215, 23);
            this.txtIdProfesor.TabIndex = 113;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.TabIndex = 112;
            this.label7.Text = "ID Profesor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(126, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 111;
            this.label6.Text = "Materia";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(12, 374);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(134, 65);
            this.BtnGuardar.TabIndex = 110;
            this.BtnGuardar.Text = "Guardar o Modificar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(152, 374);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 65);
            this.BtnBuscar.TabIndex = 109;
            this.BtnBuscar.Text = "&Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(233, 374);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 65);
            this.BtnNuevo.TabIndex = 108;
            this.BtnNuevo.Text = "&Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(314, 374);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 65);
            this.BtnEliminar.TabIndex = 107;
            this.BtnEliminar.Text = "&Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(395, 412);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(64, 27);
            this.BtnSalir.TabIndex = 106;
            this.BtnSalir.Text = "&Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // GrdCertificacion
            // 
            this.GrdCertificacion.AllowUserToAddRows = false;
            this.GrdCertificacion.AllowUserToDeleteRows = false;
            this.GrdCertificacion.AllowUserToResizeColumns = false;
            this.GrdCertificacion.AllowUserToResizeRows = false;
            this.GrdCertificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdCertificacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCertificado,
            this.idProfesor,
            this.materia});
            this.GrdCertificacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GrdCertificacion.Location = new System.Drawing.Point(12, 176);
            this.GrdCertificacion.Name = "GrdCertificacion";
            this.GrdCertificacion.RowTemplate.Height = 25;
            this.GrdCertificacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdCertificacion.Size = new System.Drawing.Size(447, 179);
            this.GrdCertificacion.TabIndex = 105;
            this.GrdCertificacion.DoubleClick += new System.EventHandler(this.GrdNotaMateria_DoubleClick);
            // 
            // idCertificado
            // 
            this.idCertificado.DataPropertyName = "ID_Certificado";
            this.idCertificado.HeaderText = "ID Certificado";
            this.idCertificado.Name = "idCertificado";
            this.idCertificado.Width = 130;
            // 
            // idProfesor
            // 
            this.idProfesor.DataPropertyName = "ID_Profesor";
            this.idProfesor.HeaderText = "ID Profesor";
            this.idProfesor.Name = "idProfesor";
            this.idProfesor.Width = 130;
            // 
            // materia
            // 
            this.materia.DataPropertyName = "Materia";
            this.materia.HeaderText = "Materia";
            this.materia.Name = "materia";
            this.materia.Width = 130;
            // 
            // txtIdCertificado
            // 
            this.txtIdCertificado.BackColor = System.Drawing.SystemColors.Window;
            this.txtIdCertificado.Location = new System.Drawing.Point(12, 27);
            this.txtIdCertificado.Name = "txtIdCertificado";
            this.txtIdCertificado.Size = new System.Drawing.Size(215, 23);
            this.txtIdCertificado.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 103;
            this.label1.Text = "ID Certificado";
            // 
            // FrmCertificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 497);
            this.Controls.Add(this.txtMateria);
            this.Controls.Add(this.txtIdProfesor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.GrdCertificacion);
            this.Controls.Add(this.txtIdCertificado);
            this.Controls.Add(this.label1);
            this.Name = "FrmCertificacion";
            this.Text = "FrmCertificacion";
            this.Load += new System.EventHandler(this.FrmCertificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdCertificacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMateria;
        private System.Windows.Forms.TextBox txtIdProfesor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridView GrdCertificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCertificado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProfesor;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
        private System.Windows.Forms.TextBox txtIdCertificado;
        private System.Windows.Forms.Label label1;
    }
}