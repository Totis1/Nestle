using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Formularios.Ventas
{
    public partial class Borrar_Venta : Form
    {
        public Borrar_Venta()
        {
            InitializeComponent();
            Clases.Class_Ventas objVenta = new Clases.Class_Ventas();
            objVenta.MostrarVentasV2(CBoxBorrar);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Clases.Class_Ventas objVenta = new Clases.Class_Ventas();
            objVenta.EliminarVenta(CBoxBorrar);
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBoxBorrar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
