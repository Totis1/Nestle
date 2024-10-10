using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Clases
{
    internal class Class_Login
    {
        public int Login(TextBox Correo, TextBox Pass)
        {
            string query = "select * from empleados where email = '" + Correo.Text + "' and contraseña = '" + Pass.Text + "' "; 
            Conexion_DB objConn = new Conexion_DB();
            MySqlCommand command = new MySqlCommand(query,objConn.establecerConn());
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int dd = reader.GetInt32("id_departamento");
                return dd;
            }
            else
            {
                MessageBox.Show("Logeado incorrectamente");
                return 0;
            }
        }
    }
}
