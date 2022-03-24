namespace Capa1Presentacion {
    partial class FrmIdiomas {
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
            this.GrdIdiomas = new System.Windows.Forms.DataGridView();
            this.idIdioma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreIdioma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtNombreIdioma = new System.Windows.Forms.TextBox();
            this.TxtIdIdioma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrdIdiomas)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(48, 347);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(134, 65);
            this.BtnGuardar.TabIndex = 27;
            this.BtnGuardar.Text = "Guardar o Modificar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(188, 347);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 65);
            this.BtnBuscar.TabIndex = 26;
            this.BtnBuscar.Text = "&Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(269, 347);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 65);
            this.BtnNuevo.TabIndex = 25;
            this.BtnNuevo.Text = "&Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(350, 347);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 65);
            this.BtnEliminar.TabIndex = 24;
            this.BtnEliminar.Text = "&Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(450, 385);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(64, 27);
            this.BtnSalir.TabIndex = 23;
            this.BtnSalir.Text = "&Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // GrdIdiomas
            // 
            this.GrdIdiomas.AllowUserToAddRows = false;
            this.GrdIdiomas.AllowUserToDeleteRows = false;
            this.GrdIdiomas.AllowUserToResizeColumns = false;
            this.GrdIdiomas.AllowUserToResizeRows = false;
            this.GrdIdiomas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdIdiomas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idIdioma,
            this.nombreIdioma});
            this.GrdIdiomas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GrdIdiomas.Location = new System.Drawing.Point(48, 131);
            this.GrdIdiomas.Name = "GrdIdiomas";
            this.GrdIdiomas.RowTemplate.Height = 25;
            this.GrdIdiomas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdIdiomas.Size = new System.Drawing.Size(466, 179);
            this.GrdIdiomas.TabIndex = 22;
            this.GrdIdiomas.DoubleClick += new System.EventHandler(this.GrdIdiomas_DoubleClick);
            // 
            // idIdioma
            // 
            this.idIdioma.DataPropertyName = "ID_Idioma";
            this.idIdioma.HeaderText = "ID Idioma";
            this.idIdioma.Name = "idIdioma";
            this.idIdioma.Width = 210;
            // 
            // nombreIdioma
            // 
            this.nombreIdioma.DataPropertyName = "NombreIdioma";
            this.nombreIdioma.HeaderText = "Nombre Idioma";
            this.nombreIdioma.Name = "nombreIdioma";
            this.nombreIdioma.Width = 210;
            // 
            // TxtNombreIdioma
            // 
            this.TxtNombreIdioma.Location = new System.Drawing.Point(202, 53);
            this.TxtNombreIdioma.Name = "TxtNombreIdioma";
            this.TxtNombreIdioma.Size = new System.Drawing.Size(312, 23);
            this.TxtNombreIdioma.TabIndex = 19;
            // 
            // TxtIdIdioma
            // 
            this.TxtIdIdioma.BackColor = System.Drawing.SystemColors.Window;
            this.TxtIdIdioma.Location = new System.Drawing.Point(49, 53);
            this.TxtIdIdioma.Name = "TxtIdIdioma";
            this.TxtIdIdioma.Size = new System.Drawing.Size(144, 23);
            this.TxtIdIdioma.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Código: ";
            // 
            // FrmIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 465);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.GrdIdiomas);
            this.Controls.Add(this.TxtNombreIdioma);
            this.Controls.Add(this.TxtIdIdioma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmIdiomas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de idiomas";
            this.Load += new System.EventHandler(this.FrmIdiomas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdIdiomas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridView GrdIdiomas;
        private System.Windows.Forms.TextBox TxtNombreIdioma;
        private System.Windows.Forms.TextBox TxtIdIdioma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idIdioma;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreIdioma;
    }
}