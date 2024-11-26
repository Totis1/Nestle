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
    public partial class Borrar_Producto : Form
    {
        public Borrar_Producto()
        {
            InitializeComponent();
            Clases.Class_Productos objProducto = new Clases.Class_Productos();
            objProducto.MostrarProductosV2(CBoxProducto);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Clases.Class_Productos objProducto = new Clases.Class_Productos();
            objProducto.EliminarProducto(CBoxProducto);
            this.Close();
        }
    }
}
