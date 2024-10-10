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
                    break;
                case 2:
                    Formularios.RecursosHumanos frmRH = new Formularios.RecursosHumanos();
                    this.Hide();
                    frmRH.ShowDialog();
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
