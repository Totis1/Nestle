using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Formularios
{
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Formularios.Ventas.Clientes frmClientes = new Ventas.Clientes();
            frmClientes.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Formularios.Ventas.Ventas frmVentas = new Ventas.Ventas();
            frmVentas.ShowDialog();
        }
    }
}
