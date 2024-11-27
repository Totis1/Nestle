using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Formularios.Ventas
{
    public partial class Actualizar_Cliente : Form
    {
        public Actualizar_Cliente()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Clases.Class_Clientes objCliente = new Clases.Class_Clientes();
            objCliente.ActualizarCliente(TxtBoxID,TxtBoxNombre,DtpFechaRegistro,CBoxEstado,TxtBoxCorreo,TxtBoxTelefono);
            this.Close();
        }
    }
}
