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
    public partial class Actualizar_Proyecto : Form
    {
        public Actualizar_Proyecto()
        {
            InitializeComponent();
        }

        private void Actualizar_Proyecto_Load(object sender, EventArgs e)
        {
            Clases.Class_Proyectos objProyecto = new Clases.Class_Proyectos();
            objProyecto.MostarDepartamentos(CBoxIDdepartamento);
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Clases.Class_Proyectos objProyecto = new Clases.Class_Proyectos();
            objProyecto.ActualizarProyecto(TxtBoxID,TxtBoxNProyecto, TxtBoxDescripcion, DtpFechaInicio, DtpFechaFin, CBoxIDdepartamento);
            this.Close();
        }
    }
}
