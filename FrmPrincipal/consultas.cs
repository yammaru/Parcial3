using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace FrmPrincipal
{
    public partial class consultas : Form
    {
        ServicioRecaudo ServicioRecaudo = new ServicioRecaudo();
        
        public consultas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CmbTipo.Enabled = true;
            txtAño.Enabled = true;
            txtMes.Enabled = true;
            Grilla.DataSource = null;
            Grilla.DataSource= ServicioRecaudo.BuscarxNit_Mes_Año(CmbTipo.Text,txtMes.Text,txtAño.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CmbTipo.Enabled = false;
            txtAño.Enabled = true;
            txtMes.Enabled = true;
            Grilla.DataSource = null;
            Grilla.DataSource = ServicioRecaudo.BuscarxMes_Año( txtMes.Text, txtAño.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CmbTipo.Enabled = true;
            txtAño.Enabled = false;
            txtMes.Enabled = false;
            Grilla.DataSource = null;
            Grilla.DataSource = ServicioRecaudo.BuscarXNit(CmbTipo.Text);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Grilla.DataSource = null;
            Grilla.DataSource = ServicioRecaudo.Consultar();

        }
    }
}
