using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Formularios.Logistica
{
    public partial class Borrar_Inventario : Form
    {
        public Borrar_Inventario()
        {
            InitializeComponent();
            Clases.Class_Inventario objInventario = new Clases.Class_Inventario();
            objInventario.MostrarInventarioV2(CBoxBorrar);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Clases.Class_Inventario objInventario = new Clases.Class_Inventario();
            objInventario.EliminarInventario(CBoxBorrar);
            this.Close();
        }
    }
}
