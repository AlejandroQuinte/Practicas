namespace Capa1Presentacion {
    partial class FrmMenuPrincipal {
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
            this.MIArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.MIMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.MIAdministrarClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.MIAdministrarProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.MIFacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIArchivo,
            this.MIMantenimiento,
            this.MIFacturacion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MIArchivo
            // 
            this.MIArchivo.Name = "MIArchivo";
            this.MIArchivo.Size = new System.Drawing.Size(60, 20);
            this.MIArchivo.Text = "Archivo";
            // 
            // MIMantenimiento
            // 
            this.MIMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIAdministrarClientes,
            this.MIAdministrarProductos});
            this.MIMantenimiento.Name = "MIMantenimiento";
            this.MIMantenimiento.Size = new System.Drawing.Size(101, 20);
            this.MIMantenimiento.Text = "Mantenimiento";
            // 
            // MIAdministrarClientes
            // 
            this.MIAdministrarClientes.Name = "MIAdministrarClientes";
            this.MIAdministrarClientes.Size = new System.Drawing.Size(193, 22);
            this.MIAdministrarClientes.Text = "Administrar Clientes";
            // 
            // MIAdministrarProductos
            // 
            this.MIAdministrarProductos.Name = "MIAdministrarProductos";
            this.MIAdministrarProductos.Size = new System.Drawing.Size(193, 22);
            this.MIAdministrarProductos.Text = "Administrar Productos";
            // 
            // MIFacturacion
            // 
            this.MIFacturacion.Name = "MIFacturacion";
            this.MIFacturacion.Size = new System.Drawing.Size(81, 20);
            this.MIFacturacion.Text = "Facturación";
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenuPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MIArchivo;
        private System.Windows.Forms.ToolStripMenuItem MIMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem MIAdministrarClientes;
        private System.Windows.Forms.ToolStripMenuItem MIAdministrarProductos;
        private System.Windows.Forms.ToolStripMenuItem MIFacturacion;
    }
}