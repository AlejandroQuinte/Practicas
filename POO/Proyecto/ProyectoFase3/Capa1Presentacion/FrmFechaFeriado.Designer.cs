namespace Capa1Presentacion {
    partial class FrmFechaFeriado {
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
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.GrdFechaFeriado = new System.Windows.Forms.DataGridView();
            this.idFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdFecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DTFechaFeriado = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.GrdFechaFeriado)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(126, 105);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(215, 23);
            this.txtMotivo.TabIndex = 114;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 112;
            this.label7.Text = "Fecha";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(126, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 111;
            this.label6.Text = "Motivo";
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
            // GrdFechaFeriado
            // 
            this.GrdFechaFeriado.AllowUserToAddRows = false;
            this.GrdFechaFeriado.AllowUserToDeleteRows = false;
            this.GrdFechaFeriado.AllowUserToResizeColumns = false;
            this.GrdFechaFeriado.AllowUserToResizeRows = false;
            this.GrdFechaFeriado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdFechaFeriado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFecha,
            this.fecha,
            this.motivo});
            this.GrdFechaFeriado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GrdFechaFeriado.Location = new System.Drawing.Point(12, 176);
            this.GrdFechaFeriado.Name = "GrdFechaFeriado";
            this.GrdFechaFeriado.RowTemplate.Height = 25;
            this.GrdFechaFeriado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdFechaFeriado.Size = new System.Drawing.Size(447, 179);
            this.GrdFechaFeriado.TabIndex = 105;
            this.GrdFechaFeriado.DoubleClick += new System.EventHandler(this.GrdFechaFeriado_DoubleClick);
            // 
            // idFecha
            // 
            this.idFecha.DataPropertyName = "ID_Fecha";
            this.idFecha.HeaderText = "ID Fecha";
            this.idFecha.Name = "idFecha";
            this.idFecha.Width = 130;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "Fecha";
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.Width = 130;
            // 
            // motivo
            // 
            this.motivo.DataPropertyName = "Motivo";
            this.motivo.HeaderText = "Motivo";
            this.motivo.Name = "motivo";
            this.motivo.Width = 130;
            // 
            // txtIdFecha
            // 
            this.txtIdFecha.BackColor = System.Drawing.SystemColors.Window;
            this.txtIdFecha.Location = new System.Drawing.Point(12, 27);
            this.txtIdFecha.Name = "txtIdFecha";
            this.txtIdFecha.Size = new System.Drawing.Size(215, 23);
            this.txtIdFecha.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 103;
            this.label1.Text = "ID Fecha";
            // 
            // DTFechaFeriado
            // 
            this.DTFechaFeriado.Location = new System.Drawing.Point(242, 27);
            this.DTFechaFeriado.Name = "DTFechaFeriado";
            this.DTFechaFeriado.Size = new System.Drawing.Size(200, 23);
            this.DTFechaFeriado.TabIndex = 115;
            // 
            // FrmFechaFeriado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 461);
            this.Controls.Add(this.DTFechaFeriado);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.GrdFechaFeriado);
            this.Controls.Add(this.txtIdFecha);
            this.Controls.Add(this.label1);
            this.Name = "FrmFechaFeriado";
            this.Text = "FrmFechaFeriado";
            this.Load += new System.EventHandler(this.FrmFechaFeriado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdFechaFeriado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridView GrdFechaFeriado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivo;
        private System.Windows.Forms.TextBox txtIdFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTFechaFeriado;
    }
}