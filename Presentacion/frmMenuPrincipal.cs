using ModeloParcial.Presentacion;
using ModeloParcial.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloParcial
{
    public partial class frmMenuPrincipal : Form
    {
        FabricaServicio Fabrica = null;
        public frmMenuPrincipal(FabricaServicio fabrica)
        {
            InitializeComponent();
            this.Fabrica= fabrica;

        }

        private void nuevaOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdenRetiro orden = new frmOrdenRetiro(Fabrica);
            orden.ShowDialog();
        }
    }
}
