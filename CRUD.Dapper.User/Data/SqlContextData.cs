using CRUD.Dapper.User.Data.Interface;
using CRUD.Dapper.User.Domain;
using CRUD.Dapper.User.Services;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CRUD.Dapper.User.Data
{
    public class SqlContextData : IDbContext
    {
        private readonly SqlConfig _context;

        public SqlContextData(SqlConfig context)
        {
            _context = context;
        }
        public void CreateDataBase()
        {
            using (var connection = new SqlConnection(_context.StringConection))
            {
                try
                {
                    connection.Execute("Create table cidade (id_cidade int primary key, cidade varchar(30), estado int)");
                }
                catch
                {
                    Console.WriteLine("Erro em criar tabela");
                }
            }
        }

        public List<Client> GetAll()
        {
            using (var connection = new SqlConnection(_context.StringConection))
            {
                try
                {
                    return connection.Query<Client>("SELECT * FROM NAME_OF_TABLE").ToList();

                }
                catch
                {
                    Console.WriteLine("Not found any client.");
                    return new List<Client>();
                }
            }
        }

        public Client GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Client client)
        {
            throw new NotImplementedException();
        }

        public void Update(Client client)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
