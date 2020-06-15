using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace DAL
{
    public class RepositorioRecaudo
    {
        SqlConnection Connection;
        SqlDataReader Reader;
        List<Recaudado> recaudados;
        public RepositorioRecaudo(SqlConnection sqlConnection)
        {
            Connection = sqlConnection;
            recaudados = new List<Recaudado>();
        }
        public void Guardar(Recaudado recaudado)
        {
            using (var Comando = Connection.CreateCommand())
            {
                Comando.CommandText = "insert into Recaudo(Nit,Mes,Año,Tipo,Valor,Identificacion,Nombre)" +
                    "values(@Nit,@Mes,@Año,@Tipo,@Valor,@Id,@Nombre); ";
                Comando.Parameters.AddWithValue("@Nit", recaudado.Nit);
                Comando.Parameters.AddWithValue("@Mes", recaudado.Mes);
                Comando.Parameters.AddWithValue("@Año", recaudado.Año);
                Comando.Parameters.AddWithValue("@Tipo", recaudado.Tipo);
                Comando.Parameters.AddWithValue("@Valor", recaudado.ValorImpuesto);
                Comando.Parameters.AddWithValue("@Id", recaudado.Identificacion);
                Comando.Parameters.AddWithValue("@Nombre", recaudado.Nombre);
                Comando.ExecuteNonQuery();
            }
        }
        public List<Recaudado> Consultar()
        {
            recaudados.Clear();
            
            using (var Comando = Connection.CreateCommand())
            {
                Comando.CommandText = "select *from Recaudo";
                Reader = Comando.ExecuteReader();
                while (Reader.Read())
                {
                    Recaudado recaudado = new Recaudado();
                    recaudado = Map(Reader);
                   recaudados.Add(recaudado);
                }
            }
            return recaudados;
        }
        public Recaudado Map(SqlDataReader reader)
        {

            Recaudado recaudado = new Recaudado();
            recaudado.Nit = (string)reader["Nit"];
            recaudado.Mes = (string)reader["Mes"];
            recaudado.Año = (string)reader["Año"];
            recaudado.Tipo = (string)reader["Tipo"];
            recaudado.ValorImpuesto = (decimal)reader["Valor"];
            recaudado.Identificacion = (string)reader["Identificacion"];
            recaudado.Nombre = (string)reader["Nombre"];
            return recaudado;
        }
        public List<Recaudado> Buscar(string tipo,string mes,string anya)
        {
            recaudados.Clear();
            recaudados = Consultar();
            return recaudados.Where(R=>R.Tipo.Equals(tipo)||R.Mes.Equals(mes)||R.Año.Equals(anya)).ToList();
        }
        public List<Recaudado> BuscarxNit_Mes_Año(string nit, string mes, string anya)
        {
            recaudados.Clear();
            recaudados = Consultar();
            return recaudados.Where(R => R.Nit.Equals(nit) || R.Mes.Equals(mes) || R.Año.Equals(anya)).ToList();
        }
        public List<Recaudado> BuscarXMes_Año( string mes, string Año)
        {
            recaudados.Clear();
            recaudados = Consultar();
            return recaudados.Where(R =>  R.Mes.Equals(mes) || R.Año.Equals(Año)).ToList();
        }
        public List<Recaudado> BuscarXAgente(string nit)
        {
            recaudados.Clear();
            recaudados = Consultar();
            return recaudados.Where(R => R.Tipo.Equals(nit) ).ToList();
        }
    }
}
