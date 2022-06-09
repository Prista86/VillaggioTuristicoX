using Microsoft.AspNetCore.Mvc;
using MVC_TDPC13.DB.Entities;
using MVC_TDPC13.Models;
using System.Threading.Tasks;



namespace MVC_TDPC13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrenotazController : ControllerBase
    {
        private readonly Repository repository;
        public PrenotazController(Repository repository)
        {
            this.repository = repository;
        }

        // POST api/<PrenotazController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PrenotazModel model)
        {
            Prenotaz prenotaz = new Prenotaz();
            prenotaz.Suite = model.Suite;
            prenotaz.Week = model.Week;
            prenotaz.IdUser = model.IdUser;

            this.repository.InsertPerson(prenotaz);
            return Ok();
        }        
    }
}


