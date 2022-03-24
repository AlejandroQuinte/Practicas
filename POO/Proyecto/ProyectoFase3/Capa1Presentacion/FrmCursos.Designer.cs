namespace Capa1Presentacion {
    partial class FrmCursos {
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
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.GrdCurso = new System.Windows.Forms.DataGridView();
            this.idCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idIdioma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadCursos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horasCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaSincronica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horasAsincronicas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtNombreCurso = new System.Windows.Forms.TextBox();
            this.txtIdCurso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIdNota = new System.Windows.Forms.TextBox();
            this.txtIdIdioma = new System.Windows.Forms.TextBox();
            this.txtCantCursos = new System.Windows.Forms.TextBox();
            this.txtHorasCurso = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCurso)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(34, 407);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(134, 65);
            this.BtnGuardar.TabIndex = 37;
            this.BtnGuardar.Text = "Guardar o Modificar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(219, 407);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 65);
            this.BtnBuscar.TabIndex = 36;
            this.BtnBuscar.Text = "&Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(345, 407);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 65);
            this.BtnNuevo.TabIndex = 35;
            this.BtnNuevo.Text = "&Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(471, 407);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 65);
            this.BtnEliminar.TabIndex = 34;
            this.BtnEliminar.Text = "&Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(766, 445);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(64, 27);
            this.BtnSalir.TabIndex = 33;
            this.BtnSalir.Text = "&Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // GrdCurso
            // 
            this.GrdCurso.AllowUserToAddRows = false;
            this.GrdCurso.AllowUserToDeleteRows = false;
            this.GrdCurso.AllowUserToResizeColumns = false;
            this.GrdCurso.AllowUserToResizeRows = false;
            this.GrdCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdCurso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCurso,
            this.idNota,
            this.idIdioma,
            this.nombreCurso,
            this.cantidadCursos,
            this.horasCurso,
            this.horaSincronica,
            this.horasAsincronicas,
            this.precio});
            this.GrdCurso.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GrdCurso.Location = new System.Drawing.Point(12, 209);
            this.GrdCurso.Name = "GrdCurso";
            this.GrdCurso.RowTemplate.Height = 25;
            this.GrdCurso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdCurso.Size = new System.Drawing.Size(843, 179);
            this.GrdCurso.TabIndex = 32;
            this.GrdCurso.DoubleClick += new System.EventHandler(this.GrdCurso_DoubleClick);
            // 
            // idCurso
            // 
            this.idCurso.DataPropertyName = "ID_Curso";
            this.idCurso.HeaderText = "ID Curso";
            this.idCurso.Name = "idCurso";
            this.idCurso.Width = 80;
            // 
            // idNota
            // 
            this.idNota.DataPropertyName = "ID_Nota";
            this.idNota.HeaderText = "ID Nota";
            this.idNota.Name = "idNota";
            this.idNota.Width = 80;
            // 
            // idIdioma
            // 
            this.idIdioma.DataPropertyName = "ID_Idioma";
            this.idIdioma.HeaderText = "ID Idioma";
            this.idIdioma.Name = "idIdioma";
            this.idIdioma.Width = 80;
            // 
            // nombreCurso
            // 
            this.nombreCurso.DataPropertyName = "NombreCurso";
            this.nombreCurso.HeaderText = "Nombre Curso";
            this.nombreCurso.Name = "nombreCurso";
            this.nombreCurso.Width = 140;
            // 
            // cantidadCursos
            // 
            this.cantidadCursos.DataPropertyName = "CantidadCursos";
            this.cantidadCursos.HeaderText = "Cantidad de Cursos";
            this.cantidadCursos.Name = "cantidadCursos";
            this.cantidadCursos.Width = 80;
            // 
            // horasCurso
            // 
            this.horasCurso.DataPropertyName = "HorasCurso";
            this.horasCurso.HeaderText = "Horas Curso";
            this.horasCurso.Name = "horasCurso";
            this.horasCurso.Width = 80;
            // 
            // horaSincronica
            // 
            this.horaSincronica.DataPropertyName = "HorasSincronicas";
            this.horaSincronica.HeaderText = "Horas Sincronicas";
            this.horaSincronica.Name = "horaSincronica";
            this.horaSincronica.Width = 80;
            // 
            // horasAsincronicas
            // 
            this.horasAsincronicas.DataPropertyName = "HorasAsincronicas";
            this.horasAsincronicas.HeaderText = "Horas Asincronicas";
            this.horasAsincronicas.Name = "horasAsincronicas";
            this.horasAsincronicas.Width = 80;
            // 
            // precio
            // 
            this.precio.DataPropertyName = "Precio";
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            // 
            // TxtNombreCurso
            // 
            this.TxtNombreCurso.Location = new System.Drawing.Point(374, 36);
            this.TxtNombreCurso.Name = "TxtNombreCurso";
            this.TxtNombreCurso.Size = new System.Drawing.Size(265, 23);
            this.TxtNombreCurso.TabIndex = 31;
            // 
            // txtIdCurso
            // 
            this.txtIdCurso.BackColor = System.Drawing.SystemColors.Window;
            this.txtIdCurso.Location = new System.Drawing.Point(34, 36);
            this.txtIdCurso.Name = "txtIdCurso";
            this.txtIdCurso.Size = new System.Drawing.Size(296, 23);
            this.txtIdCurso.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Nombre Curso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "ID Curso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 38;
            this.label3.Text = "Precio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "Horas Curso";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 40;
            this.label5.Text = "Cantidad Cursos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 41;
            this.label6.Text = "ID Idioma";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 42;
            this.label7.Text = "ID Nota";
            // 
            // txtIdNota
            // 
            this.txtIdNota.Location = new System.Drawing.Point(34, 99);
            this.txtIdNota.Name = "txtIdNota";
            this.txtIdNota.Size = new System.Drawing.Size(296, 23);
            this.txtIdNota.TabIndex = 43;
            // 
            // txtIdIdioma
            // 
            this.txtIdIdioma.Location = new System.Drawing.Point(34, 156);
            this.txtIdIdioma.Name = "txtIdIdioma";
            this.txtIdIdioma.Size = new System.Drawing.Size(296, 23);
            this.txtIdIdioma.TabIndex = 44;
            // 
            // txtCantCursos
            // 
            this.txtCantCursos.Location = new System.Drawing.Point(374, 99);
            this.txtCantCursos.Name = "txtCantCursos";
            this.txtCantCursos.Size = new System.Drawing.Size(265, 23);
            this.txtCantCursos.TabIndex = 45;
            this.txtCantCursos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantCursos_KeyPress);
            // 
            // txtHorasCurso
            // 
            this.txtHorasCurso.Location = new System.Drawing.Point(374, 156);
            this.txtHorasCurso.Name = "txtHorasCurso";
            this.txtHorasCurso.Size = new System.Drawing.Size(265, 23);
            this.txtHorasCurso.TabIndex = 46;
            this.txtHorasCurso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorasCurso_KeyPress);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(730, 99);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 23);
            this.txtPrecio.TabIndex = 47;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // FrmCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 493);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtHorasCurso);
            this.Controls.Add(this.txtCantCursos);
            this.Controls.Add(this.txtIdIdioma);
            this.Controls.Add(this.txtIdNota);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.GrdCurso);
            this.Controls.Add(this.TxtNombreCurso);
            this.Controls.Add(this.txtIdCurso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCursos";
            this.Text = "Mantenimiento Cursos";
            this.Load += new System.EventHandler(this.FrmCursos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdCurso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridView GrdCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn idIdioma;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadCursos;
        private System.Windows.Forms.DataGridViewTextBoxColumn horasCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaSincronica;
        private System.Windows.Forms.DataGridViewTextBoxColumn horasAsincronicas;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.TextBox TxtNombreCurso;
        private System.Windows.Forms.TextBox txtIdCurso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIdNota;
        private System.Windows.Forms.TextBox txtIdIdioma;
        private System.Windows.Forms.TextBox txtCantCursos;
        private System.Windows.Forms.TextBox txtHorasCurso;
        private System.Windows.Forms.TextBox txtPrecio;
    }
}