using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class ServicioRecaudo
    {
        SqlConnection Connection;
        RepositorioRecaudo repositorioRecaudo;
        Archivo archivo = new Archivo();
        public ServicioRecaudo()
        {
            Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Recaudo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            repositorioRecaudo = new RepositorioRecaudo(Connection);
        
        }
        public string Guardar(Recaudado recaudo)
        {
            try
            {
                Connection.Open();
                repositorioRecaudo.Guardar(recaudo);
                Connection.Close();
                return $"Guardo!";
                  
            }
            catch (Exception e)
            {
                Connection.Close();
                return $"Error de Dase de Datos al Guardar::: {e.Message}";
            }
        }
        public List<Recaudado> ConsultarArchivo(string ruta) { return archivo.Consultar(ruta); }
        public List<Recaudado> Consultar()
        {
          
            
          
                Connection.Open();
                List<Recaudado> recaudados = repositorioRecaudo.Consultar();
                Connection.Close();
                return recaudados;
            
        }
        public List<Recaudado> Buscar(string tipo,string mes,string año)
        {
           
            
                Connection.Open();
                List<Recaudado> recaudados = repositorioRecaudo.Buscar(tipo,mes,año);
                Connection.Close();
                return recaudados;
          
        }
        public List<Recaudado> BuscarxNit_Mes_Año(string nit, string mes, string año)
        {
            
           
                Connection.Open();
                List<Recaudado> recaudados = repositorioRecaudo.BuscarxNit_Mes_Año(nit, mes, año);
                Connection.Close();
                return recaudados;
           
        }
        public List<Recaudado> BuscarxMes_Año(string mes, string año)
        {
            
           
                Connection.Open();
                List<Recaudado> recaudados = repositorioRecaudo.BuscarXMes_Año( mes, año);
                Connection.Close();
                return recaudados;
          
        }
        public List<Recaudado> BuscarXNit(string nit)
        {
            
            
                Connection.Open();
                List<Recaudado> recaudados = repositorioRecaudo.BuscarXAgente(nit);
                Connection.Close();
                return recaudados;
            
        }
    }
}
