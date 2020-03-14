using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Dapper.User.Data.Interface;
using CRUD.Dapper.User.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Dapper.User.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IDbContext _dbContext { get; set; }

        public ClientController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET api/client/
        [HttpGet]
        public ActionResult<List<Client>> List()
        {
            return _dbContext.GetAll();
        }

        //GET api/client/3
        [HttpGet("details/{id}", Name = "GetID")]
        public ActionResult<Client> Details(int id)
        {
            return _dbContext.GetById(id);

        }

        //POST api/client/
        [HttpPost ("insert")]
        public ActionResult<Client> Insert(Client client)
        {
            //client.DataAtCreate = client.DataAtCreat;
            _dbContext.Insert(client);
            return client;
        }

        //PUT api/client/
        [HttpPut("update")]
        public ActionResult<Client> Update(Client client)
        {
            //client.DataAtCreate = client.DataAtCreat;
            _dbContext.Update(client);
            return client;
        }
        
        //DELETE api/client/
        [HttpDelete ("delete")]
        public ActionResult<string> Delete(Client client)
        {
            
            return _dbContext.Delete(client.Id_Client); ;

        }
    }
}