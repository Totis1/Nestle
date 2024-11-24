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
    public partial class RecursosHumanos : Form
    {
        public RecursosHumanos()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Formularios.RH.Usuarios_RH Usuarios = new RH.Usuarios_RH();
            Usuarios.ShowDialog();
        }

        private void btnProyectos_Click(object sender, EventArgs e)
        {
            Formularios.RH.Proyectos_RH Proyectos = new RH.Proyectos_RH();
            Proyectos.ShowDialog();
        }
    }
}
