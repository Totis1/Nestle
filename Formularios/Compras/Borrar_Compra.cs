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
    public partial class Borrar_Compra : Form
    {
        public Borrar_Compra()
        {
            InitializeComponent();
            Clases.Class_Compras objCompra = new Clases.Class_Compras();
            objCompra.MostrarComprasV2(CBoxBorrar);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Clases.Class_Compras objCompra = new Clases.Class_Compras();
            objCompra.EliminarCompra(CBoxBorrar);
            this.Close();
        }
    }
}
