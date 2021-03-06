﻿using CRUD.Dapper.User.Data.Interface;
using CRUD.Dapper.User.Domain;
using CRUD.Dapper.User.Services;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace CRUD.Dapper.User.Data
{
    public class SqlContextData : IDbContext
    {
        private readonly SqlConfig _context;

        public SqlContextData(SqlConfig context)
        {
            _context = context;
            CreateDataBase();
        }
        public void CreateDataBase()
        {
            using (var connection = new SqlConnection(_context.StringConection))
            {
                try
                {
                    connection.Execute("if (object_id ('master.dbo.Client')) is null " +
                        "CREATE TABLE " +
                        "   Client (" +
                        "       id_client INT IDENTITY(1,1) PRIMARY KEY, " +
                        "       name VARCHAR(100) NOT NULL, " +
                        "       CPF VARCHAR(14) NOT NULL," +
                        "       email VARCHAR(50) NOT NULL," +
                        "       alias VARCHAR(100)," +
                        "       dataAtCreate DATE " +
                        "   )"
                        );
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
                    return connection.Query<Client>("SELECT * FROM dbo.Client").ToList();

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
            using (var connection = new SqlConnection(_context.StringConection))
            {
                try
                {
                    return connection.QueryFirst<Client>("SELECT * FROM Client " +
                        "WHERE id_client = @idClient;", new { idClient = id });
                }
                catch
                {
                    return new Client();
                }
            }
        }

        public void Insert(Client client)
        {
            using (var connection = new SqlConnection(_context.StringConection))
            {
                try
                {
                    connection.Execute
                        (
                            "" +
                            "INSERT INTO Client ( " +
                            "   name, CPF, email,alias, dataAtCreate)" +
                            "Values(" +
                            "   @name, @CPF, @email, @alias, @dataAtCreate)"
                            , client
                        );
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void Update(Client client)
        {
            using (var connection = new SqlConnection(_context.StringConection))
            {
                if (client.Id_Client != 0)
                {
                    try
                    {
                        connection.Execute
                            (
                                "" +
                                "UPDATE Client " +
                                "SET " +
                                "   name = @name, " +
                                "   CPF = @CPF, " +
                                "   email = @email," +
                                "   alias = @alias " +
                                "WHERE " +
                                "   id_client = @id_client"
                                , client
                            );
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public string Delete(int id)
        {
            using (var connection = new SqlConnection(_context.StringConection))
            {
                if (id != 0)
                {
                    try
                    {
                        connection.Execute
                            (
                                "DELETE FROM " +
                                "   Client " +                                
                                "WHERE " +
                                "   id_client = @id_client"
                                , new {id_client = id}
                            );
                        return "Client deleted";
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
                else
                {
                    return "Incorrect Id";
                }
            }
        }
    }
}
