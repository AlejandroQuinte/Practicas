namespace Capa1Presentacion {
    partial class FrmCursosBuscar {
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtNombreCurso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.GrdCurso)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(794, 289);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 28;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(671, 289);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 27;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(404, 22);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 23);
            this.BtnBuscar.TabIndex = 26;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtNombreCurso
            // 
            this.TxtNombreCurso.Location = new System.Drawing.Point(83, 22);
            this.TxtNombreCurso.Name = "TxtNombreCurso";
            this.TxtNombreCurso.Size = new System.Drawing.Size(292, 23);
            this.TxtNombreCurso.TabIndex = 25;
            this.TxtNombreCurso.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtNombreCurso_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nombre";
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
            this.GrdCurso.Location = new System.Drawing.Point(26, 80);
            this.GrdCurso.Name = "GrdCurso";
            this.GrdCurso.RowTemplate.Height = 25;
            this.GrdCurso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdCurso.Size = new System.Drawing.Size(843, 179);
            this.GrdCurso.TabIndex = 33;
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
            // FrmCursosBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 341);
            this.Controls.Add(this.GrdCurso);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.TxtNombreCurso);
            this.Controls.Add(this.label1);
            this.Name = "FrmCursosBuscar";
            this.Text = "FrmCursosBuscar";
            this.Load += new System.EventHandler(this.FrmCursosBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdCurso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtNombreCurso;
        private System.Windows.Forms.Label label1;
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
    }
}