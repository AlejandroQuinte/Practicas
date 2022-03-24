namespace Capa1Presentacion {
    partial class FrmBuscarEstudiante {
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
            this.TxtNombreEstudiante = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.GrdEstudiante = new System.Windows.Forms.DataGridView();
            this.idEstudiante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrdEstudiante)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(548, 357);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 28;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(411, 357);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 27;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // TxtNombreEstudiante
            // 
            this.TxtNombreEstudiante.Location = new System.Drawing.Point(75, 95);
            this.TxtNombreEstudiante.Name = "TxtNombreEstudiante";
            this.TxtNombreEstudiante.Size = new System.Drawing.Size(292, 23);
            this.TxtNombreEstudiante.TabIndex = 25;
            this.TxtNombreEstudiante.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtNombreIdioma_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "¿Estudiante no se encuentra?";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(411, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Agregar Nuevo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GrdEstudiante
            // 
            this.GrdEstudiante.AllowUserToAddRows = false;
            this.GrdEstudiante.AllowUserToDeleteRows = false;
            this.GrdEstudiante.AllowUserToResizeColumns = false;
            this.GrdEstudiante.AllowUserToResizeRows = false;
            this.GrdEstudiante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdEstudiante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEstudiante,
            this.nombre,
            this.apellido1,
            this.apellido2,
            this.correo,
            this.telefono});
            this.GrdEstudiante.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GrdEstudiante.Location = new System.Drawing.Point(18, 144);
            this.GrdEstudiante.Name = "GrdEstudiante";
            this.GrdEstudiante.RowTemplate.Height = 25;
            this.GrdEstudiante.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdEstudiante.Size = new System.Drawing.Size(605, 179);
            this.GrdEstudiante.TabIndex = 53;
            this.GrdEstudiante.DoubleClick += new System.EventHandler(this.GrdEstudiante_DoubleClick);
            // 
            // idEstudiante
            // 
            this.idEstudiante.DataPropertyName = "ID_Estudiantes";
            this.idEstudiante.HeaderText = "ID Estudiante";
            this.idEstudiante.Name = "idEstudiante";
            this.idEstudiante.Width = 70;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "Nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // apellido1
            // 
            this.apellido1.DataPropertyName = "Apellido1";
            this.apellido1.HeaderText = "I Apellido";
            this.apellido1.Name = "apellido1";
            // 
            // apellido2
            // 
            this.apellido2.DataPropertyName = "Apellido2";
            this.apellido2.HeaderText = "II Apellido";
            this.apellido2.Name = "apellido2";
            // 
            // correo
            // 
            this.correo.DataPropertyName = "Correo";
            this.correo.HeaderText = "Correo";
            this.correo.Name = "correo";
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "Telefono";
            this.telefono.HeaderText = "Teléfono";
            this.telefono.Name = "telefono";
            this.telefono.Width = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 15);
            this.label3.TabIndex = 54;
            this.label3.Text = "Digite al estudiante que desea buscar";
            // 
            // FrmBuscarEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 428);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GrdEstudiante);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.TxtNombreEstudiante);
            this.Controls.Add(this.label1);
            this.Name = "FrmBuscarEstudiante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuscarEstudiante";
            this.Load += new System.EventHandler(this.FrmBuscarEstudiante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdEstudiante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.TextBox TxtNombreEstudiante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView GrdEstudiante;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstudiante;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido2;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.Label label3;
    }
}