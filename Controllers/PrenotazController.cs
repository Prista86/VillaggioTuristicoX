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
            //string username = User.Identity.Name;
            Prenotazione prenotazione = new Prenotazione();
            prenotazione.Suite = model.Suite;
            prenotazione.Week = model.Week;
            prenotazione.IdUser = model.IdUser;

            this.repository.InsertPerson(prenotazione);
            return Ok();
        }
    }
}


