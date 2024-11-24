using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Formularios.RH
{
    public partial class Borrar_Proyecto : Form
    {
        public Borrar_Proyecto()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Clases.Class_Proyectos objProyectos = new Clases.Class_Proyectos();
            objProyectos.EliminarProyecto(CBoxProyectoEliminar);
            this.Close();
        }

        private void Borrar_Proyecto_Load(object sender, EventArgs e)
        {
            Clases.Class_Proyectos objProyecto = new Clases.Class_Proyectos();
            objProyecto.MostarProyectos_V2(CBoxProyectoEliminar);
        }
    }
}
