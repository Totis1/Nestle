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
    public partial class Agregar_Venta : Form
    {
        public Agregar_Venta()
        {
            InitializeComponent();
            Clases.Class_Ventas objVenta = new Clases.Class_Ventas();
            objVenta.MostrarProductos(CBoxProducto);
            objVenta.MostrarClientes(CBoxCliente);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clases.Class_Ventas objVenta = new Clases.Class_Ventas();
            objVenta.InsertarVentas(CBoxProducto,TxtBoxCantidad,DtpFechaVenta,TxtBoxPrecio,CBoxCliente);
            this.Close();
        }

        private void TxtBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtBoxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
