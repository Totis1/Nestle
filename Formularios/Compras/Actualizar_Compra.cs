using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Formularios.Compras
{
    public partial class Actualizar_Compra : Form
    {
        public Actualizar_Compra()
        {
            InitializeComponent();
            Clases.Class_Compras objCompra = new Clases.Class_Compras();
            objCompra.MostrarProductos(CBoxProducto);
            objCompra.MostrarProveedores(CBoxProovedor);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Clases.Class_Compras objCompra = new Clases.Class_Compras();
            objCompra.ActualizarCompra(TxtBoxID,CBoxProducto,TxtBoxCantidad,DtpFechaCompra,TxtBoxPrecio,CBoxProovedor);
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
