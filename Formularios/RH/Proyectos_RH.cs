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
    public partial class Proyectos_RH : Form
    {
        public Proyectos_RH()
        {
            InitializeComponent();
            Clases.Class_Proyectos objProyecto = new Clases.Class_Proyectos();
            objProyecto.MostrarProyectos(dgvProyectos);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Formularios.RH.Agregar_Proyecto frmagregar = new Agregar_Proyecto();
            frmagregar.ShowDialog();
            Clases.Class_Proyectos objProyecto = new Clases.Class_Proyectos();
            objProyecto.MostrarProyectos(dgvProyectos);
        }

        private void dgvProyectos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Formularios.RH.Actualizar_Proyecto frmactualizar = new RH.Actualizar_Proyecto();
            Clases.Class_Proyectos objProyectos = new Clases.Class_Proyectos();
            objProyectos.SeleccionarProyecto(dgvProyectos,frmactualizar.TxtBoxID,frmactualizar.TxtBoxNProyecto,frmactualizar.TxtBoxDescripcion,frmactualizar.DtpFechaInicio,frmactualizar.DtpFechaFin,frmactualizar.CBoxIDdepartamento);
            frmactualizar.ShowDialog();
            objProyectos.MostrarProyectos(dgvProyectos);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            Clases.Class_Proyectos objProyecto = new Clases.Class_Proyectos();
            Formularios.RH.Borrar_Proyecto frmborrar = new Borrar_Proyecto();
            frmborrar.ShowDialog();
            objProyecto.MostrarProyectos(dgvProyectos);
        }
    }
}
