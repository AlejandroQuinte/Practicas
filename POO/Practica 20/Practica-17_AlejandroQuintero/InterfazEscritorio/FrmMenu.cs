using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InterfazEscritorio
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frmCli = new FrmClientes();
            frmCli.Show();
        }

        private void mnuClientesReservaciones_Click(object sender, EventArgs e)
        {
            FrmClientesReservaciones frmRe = new FrmClientesReservaciones();
            frmRe.ShowDialog();
        }
    }//public partial class FrmMenu : Form
}//namespace InterfazEscritorio
