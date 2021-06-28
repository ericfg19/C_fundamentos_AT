using System;
using System.Collections.Generic;
using System.Text;
using ClassAgenda;
using Dapper;
using System.Data.SqlClient;

namespace AgendaRepositorio
{
    public class AgendaRepositorio : IAgendaRepositorio
    {
        private string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = AgendaAmigosDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Amigo> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.SelectAllAmigo";

                return connection
                    .Query<Amigo>(sql, commandType: System.Data.CommandType.StoredProcedure)
                    .AsList();
            }
        }

        public Amigo GetAmigoById(int IdSku)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.SelectAmigoById";

                return connection.QueryFirstOrDefault<Amigo>(sql, new { idsku = IdSku },
                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public void DeleteAmigo(int IdSku)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.DeletetAmigo";

                connection.Execute(sql,
                    new { idsku = IdSku },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        public void InsertAmigo(Amigo amigo)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.InsertAmigo";

                connection.Execute(sql,
                    new
                    {
                        Nome = amigo.Nome,
                        Sobrenome = amigo.SobreNome,
                        Aniversario = amigo.Aniversario
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateAmigo(Amigo amigo, int IdSku)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.UpdateAmigo";

                connection.Execute(sql,
                    new
                    {
                        Nome = amigo.Nome,
                        Sobrenome = amigo.SobreNome,
                        Aniversario = amigo.Aniversario,
                        idsku = IdSku
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
