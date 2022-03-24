namespace Capa1Presentacion {
    partial class FrmBuscarIdioma {
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
            this.TxtNombreIdioma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrdIdiomas = new System.Windows.Forms.DataGridView();
            this.idIdioma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreIdioma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GrdIdiomas)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(424, 321);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 17;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(287, 321);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 16;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(427, 35);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 23);
            this.BtnBuscar.TabIndex = 14;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtNombreIdioma
            // 
            this.TxtNombreIdioma.Location = new System.Drawing.Point(87, 35);
            this.TxtNombreIdioma.Name = "TxtNombreIdioma";
            this.TxtNombreIdioma.Size = new System.Drawing.Size(292, 23);
            this.TxtNombreIdioma.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre";
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
            this.GrdIdiomas.Location = new System.Drawing.Point(33, 107);
            this.GrdIdiomas.Name = "GrdIdiomas";
            this.GrdIdiomas.RowTemplate.Height = 25;
            this.GrdIdiomas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdIdiomas.Size = new System.Drawing.Size(466, 179);
            this.GrdIdiomas.TabIndex = 23;
            this.GrdIdiomas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdIdiomas_CellContentClick);
            this.GrdIdiomas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GrdIdiomas_MouseClick);
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
            // FrmBuscarIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(545, 401);
            this.Controls.Add(this.GrdIdiomas);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.TxtNombreIdioma);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuscarIdioma";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Idioma";
            this.Load += new System.EventHandler(this.FrmBuscarIdioma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdIdiomas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtNombreIdioma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GrdIdiomas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idIdioma;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreIdioma;
    }
}