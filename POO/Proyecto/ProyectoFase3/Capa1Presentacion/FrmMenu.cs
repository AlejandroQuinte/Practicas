using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Capa1Presentacion {
    public partial class FrmMenu : Form {
        public FrmMenu() {
            InitializeComponent();
        }

        private void MSRMatricula_Click(object sender, EventArgs e) {
            FrmMatricula matricula = new FrmMatricula();
            matricula.ShowDialog();
        }

        private void MSAgregarEstudiante_Click(object sender, EventArgs e) {
            FrmEstudiante estudiante = new FrmEstudiante();
            estudiante.ShowDialog();
        }

        private void MSAgregarProfesor_Click(object sender, EventArgs e) {
            FrmProfesor prof = new FrmProfesor();
            prof.ShowDialog();
        }

        private void MSClaseSincronica_Click(object sender, EventArgs e) {
            FrmClaseSincronica frmClaseSincronica = new FrmClaseSincronica();
            frmClaseSincronica.ShowDialog();
        }
    }
}
