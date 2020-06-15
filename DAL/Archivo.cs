using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

using System.Data;

namespace DAL
{
    public class Archivo
    {
        List<Recaudado> recaudados;
        public Archivo()
        {
            recaudados = new List<Recaudado>();
        }
        public List<Recaudado> Consultar(string ruta)
        {
            recaudados = new List<Recaudado>();
            recaudados.Clear();
            FileStream flujo = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(flujo);
            string linea = string.Empty;
            while ((linea=reader.ReadLine())!=null)
            {
                Recaudado recaudado = Map(linea);
                recaudados.Add(recaudado);
            }
            reader.Close();
            flujo.Close();
                

            return recaudados;

        }

        private Recaudado Map(string linea)
        {
            string[] datos = linea.Split(';');
            Recaudado recaudado = new Recaudado();
            recaudado.Nit = datos[0];
            recaudado.Mes = datos[1];
            recaudado.Año = datos[2];
            recaudado.Tipo = datos[3];
            recaudado.ValorImpuesto = decimal.Parse(datos[4]);
            recaudado.Identificacion = datos[5];
            recaudado.Nombre = datos[6]; 
            return recaudado;
        }
    }
}
