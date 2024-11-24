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
    public partial class Agregar_Proyecto : Form
    {
        public Agregar_Proyecto()
        {
            InitializeComponent();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Clases.Class_Proyectos objProyecto = new Clases.Class_Proyectos();
            objProyecto.InsertarProyecto(TxtBoxNProyecto,TxtBoxDescripcion,DtpFechaInicio,DtpFechaFin,CBoxIDdepartamento);
            this.Close();
        }

        private void Agregar_Proyecto_Load(object sender, EventArgs e)
        {
            Clases.Class_Proyectos objProyecto = new Clases.Class_Proyectos();
            objProyecto.MostarDepartamentos(CBoxIDdepartamento);

        }
    }
}
