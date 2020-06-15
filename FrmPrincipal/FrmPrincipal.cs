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
using Entity;

namespace FrmPrincipal
{
    public partial class FrmPrincipal : Form
    {
        List<Recaudado> recaudados = new List<Recaudado>();
        ServicioRecaudo ServicioRecaudo = new ServicioRecaudo();
        
        Recaudado recaudado = new Recaudado();
        public FrmPrincipal()
        {
            InitializeComponent();
           
        }

        SaveFileDialog GuardaRuta = new SaveFileDialog();
        string Ruta;
        
        private void button1_Click(object sender, EventArgs e)
        {
            Grilla.DataSource = null;

            if (GuardaRuta.ShowDialog()==DialogResult.OK)
            {
                Ruta = GuardaRuta.FileName;
                MessageBox.Show("Ruta Capturada::: "+Ruta);
            }
            else
            {
                MessageBox.Show("Ninguna Ruta Capturada");
            }
            recaudados.Clear();
            recaudados= ServicioRecaudo.ConsultarArchivo(Ruta);
            MessageBox.Show(guardaarchivo(recaudados));
            
            
            if ((ServicioRecaudo.Consultar()) != null)
            {
                MessageBox.Show("Esta vacia");
            }
            else
            {
                Grilla.DataSource = ServicioRecaudo.Consultar();
            }
        }
        string guardaarchivo(List<Recaudado> recaudados)
        {
            foreach (Recaudado item in recaudados)
            {
                
                Recaudado recaudado = new Recaudado();
                recaudado.Nit = item.Nit;
                recaudado.Mes = item.Mes;
                recaudado.Año = item.Año;
                recaudado.Tipo = item.Tipo;
                recaudado.ValorImpuesto =Convert.ToDecimal( item.ValorImpuesto);
                recaudado.Identificacion = item.Identificacion;
                recaudado.Nombre = item.Nombre;


                MessageBox.Show(ServicioRecaudo.Guardar(recaudado));

            }
            return "recaudo guardado en Base de datos";
        }
    
        private void BttBuscar_Click(object sender, EventArgs e)
        {
            Grilla.DataSource = null;
            Grilla.DataSource = ServicioRecaudo.Buscar(CmbTipo.Text, txtMes.Text, txtAño.Text);
            if ((ServicioRecaudo.Buscar(CmbTipo.Text, txtMes.Text, txtAño.Text)) ==null)
            {
                MessageBox.Show("Esta vacia");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Grilla.DataSource = null;
            if ((ServicioRecaudo.Consultar()) != null)
            {
                Grilla.DataSource = ServicioRecaudo.Consultar();
            }
            else
            {
                
                MessageBox.Show("Esta vacia");
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            
           foreach  (var item in ServicioRecaudo.Consultar())
            {
                comboBox1.Items.Add(item.Nit);
            }
            
        }
    }
}
