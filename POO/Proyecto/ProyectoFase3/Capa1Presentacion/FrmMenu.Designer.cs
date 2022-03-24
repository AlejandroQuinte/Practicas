namespace Capa1Presentacion {
    partial class FrmMenu {
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MSMatricula = new System.Windows.Forms.ToolStripMenuItem();
            this.MSRMatricula = new System.Windows.Forms.ToolStripMenuItem();
            this.MSClaseSincronica = new System.Windows.Forms.ToolStripMenuItem();
            this.MSAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.MSAgregarEstudiante = new System.Windows.Forms.ToolStripMenuItem();
            this.MSAgregarProfesor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MSMatricula,
            this.MSAdministracion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MSMatricula
            // 
            this.MSMatricula.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MSRMatricula,
            this.MSClaseSincronica});
            this.MSMatricula.Name = "MSMatricula";
            this.MSMatricula.Size = new System.Drawing.Size(69, 20);
            this.MSMatricula.Text = "Matricula";
            // 
            // MSRMatricula
            // 
            this.MSRMatricula.Name = "MSRMatricula";
            this.MSRMatricula.Size = new System.Drawing.Size(200, 22);
            this.MSRMatricula.Text = "Realizar Matricula";
            this.MSRMatricula.Click += new System.EventHandler(this.MSRMatricula_Click);
            // 
            // MSClaseSincronica
            // 
            this.MSClaseSincronica.Name = "MSClaseSincronica";
            this.MSClaseSincronica.Size = new System.Drawing.Size(200, 22);
            this.MSClaseSincronica.Text = "Realizar clase sincronica";
            this.MSClaseSincronica.Click += new System.EventHandler(this.MSClaseSincronica_Click);
            // 
            // MSAdministracion
            // 
            this.MSAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MSAgregarEstudiante,
            this.MSAgregarProfesor});
            this.MSAdministracion.Name = "MSAdministracion";
            this.MSAdministracion.Size = new System.Drawing.Size(100, 20);
            this.MSAdministracion.Text = "Administración";
            // 
            // MSAgregarEstudiante
            // 
            this.MSAgregarEstudiante.Name = "MSAgregarEstudiante";
            this.MSAgregarEstudiante.Size = new System.Drawing.Size(174, 22);
            this.MSAgregarEstudiante.Text = "Agregar Estudiante";
            this.MSAgregarEstudiante.Click += new System.EventHandler(this.MSAgregarEstudiante_Click);
            // 
            // MSAgregarProfesor
            // 
            this.MSAgregarProfesor.Name = "MSAgregarProfesor";
            this.MSAgregarProfesor.Size = new System.Drawing.Size(174, 22);
            this.MSAgregarProfesor.Text = "Agregar Profesor";
            this.MSAgregarProfesor.Click += new System.EventHandler(this.MSAgregarProfesor_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MSMatricula;
        private System.Windows.Forms.ToolStripMenuItem MSRMatricula;
        private System.Windows.Forms.ToolStripMenuItem MSClaseSincronica;
        private System.Windows.Forms.ToolStripMenuItem MSAdministracion;
        private System.Windows.Forms.ToolStripMenuItem MSAgregarEstudiante;
        private System.Windows.Forms.ToolStripMenuItem MSAgregarProfesor;
    }
}