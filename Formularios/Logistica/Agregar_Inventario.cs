﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Formularios.Logistica
{
    public partial class Agregar_Inventario : Form
    {
        public Agregar_Inventario()
        {
            InitializeComponent();
            Clases.Class_Inventario objInventario = new Clases.Class_Inventario();
            objInventario.MostrarProductos(CBoxProducto);
            objInventario.MostarDepartamentos(CBoxDepartamento);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clases.Class_Inventario objInventario = new Clases.Class_Inventario();
            objInventario.InsertarInventario(CBoxProducto,TxtBoxCantidad,CBoxDepartamento);
            this.Close();
        }

        private void TxtBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
