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
    public partial class Login : Form
    {
        Clases.Conexion_DB objConn = new Clases.Conexion_DB();
        public Login()
        {
            InitializeComponent();
            objConn.establecerConn();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            int decision;
            Clases.Class_Login objLogin = new Clases.Class_Login();
            decision = objLogin.Login(txtboxcorreo, txtboxcontraseña);
            switch (decision)
            {
                case 1:
                    Formularios.Produccion frmProduccion = new Formularios.Produccion();
                    this.Hide();
                    frmProduccion.ShowDialog();
                    this.Close();
                    break;
                case 2:
                    Formularios.RecursosHumanos frmRH = new Formularios.RecursosHumanos();
                    this.Hide();
                    frmRH.ShowDialog();
                    this.Close();
                    break;
                case 3:
                    Formularios.Venta frmVentas = new Formularios.Venta();
                    this.Hide();
                    frmVentas.ShowDialog();
                    this.Close();
                    break;
                case 4:
                    Formularios.Finanzas frmFinanzas = new Formularios.Finanzas();
                    this.Hide();
                    frmFinanzas.ShowDialog();
                    this.Close();
                    break;
                case 5:
                    Formularios.Logistica frmLogistica = new Formularios.Logistica();
                    this.Hide();
                    frmLogistica.ShowDialog();
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
