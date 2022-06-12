using Microsoft.AspNetCore.Mvc;
using MVC_TDPC13.DB.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_TDPC13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuiteController : ControllerBase
    {
        private readonly Repository repository;
        
        
        public SuiteController(Repository repository)
        {
            this.repository = repository;
            
        }
        

        [HttpGet("getasync1")]
        public async Task<List<Suite>> GetSilver()
        {
            List<Suite> suite = this.repository.VerificaSilver();
            
            return suite;
        }

        [HttpGet("getasync2")]
        public async Task<List<Suite>> GetGold()
        {
            List<Suite> suite = this.repository.VerificaGold();
            
            return suite;
        }
    }
}
