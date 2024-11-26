using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Formularios.Productos
{
    public partial class Agregar_Producto : Form
    {
        public Agregar_Producto()
        {
            InitializeComponent();
            Clases.Class_Productos objProductos = new Clases.Class_Productos();
            objProductos.MostarDepartamentos(CBoxDepartamento);
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

        private void TxtBoxStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Clases.Class_Productos objProducto = new Clases.Class_Productos();
            objProducto.InsertarProductos(TxtBoxNombre,TxtBoxDescripcion,TxtBoxPrecio,TxtBoxStock,CBoxDepartamento);
            this.Close();
        }
    }
}
