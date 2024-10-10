using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Clases
{
    internal class Conexion_DB
    {
        MySqlConnection conn = new MySqlConnection();
        static string servidor = "localhost";
        static string bd = "nestle"; //Aqui va el nombre de la base de datos
        static string user = "root"; //Aqui va el usuario
        static string pass = "sanuma21"; //Aqui va la contraseña de workbench
        static string puerto = "3306"; //Aqui va el puerto 

        string cadenaconn = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + user + ";" + "password=" + pass + ";" + "database=" + bd + ";";

        public MySqlConnection establecerConn() 
        {
            try
            {
                conn.ConnectionString = cadenaconn;
                conn.Open();
                //MessageBox.Show("Se establecio la coneccion con la DB");
            }
            catch (MySqlException e)
            {
                MessageBox.Show("No se pudo conectar a la base de datos, error: " + e.ToString());
            }
            return conn;
        }

        public void cerrarConn()
        {
            conn.Close();
        }
    }
}
