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
    [Route("api/[controller]")]
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
    }
}