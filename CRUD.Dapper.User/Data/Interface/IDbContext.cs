using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Dapper.User.Domain;

namespace CRUD.Dapper.User.Data.Interface
{
    public interface IDbContext
    {
        public void CreateDataBase();
        public List<Client> GetAll();
        public Client GetById(int id);
        public void Insert(Client client);
        public void Update(Client client);
        public string Delete(int id);
    }
}
