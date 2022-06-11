using Microsoft.AspNetCore.Mvc;
using MVC_TDPC13.DB;
using MVC_TDPC13.DB.Entities;
using MVC_TDPC13.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_TDPC13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrenotazioneController : ControllerBase
    {
        private readonly Repository repository;
        //private readonly DBContext dbcontext;
        public PrenotazioneController(Repository repository)
        {
            this.repository = repository;
        }
        //public PrenotazioneController(DBContext dBContext)
        //{
        //    this.dbcontext = dbcontext;
        //}

        // POST api/<PrenotazController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PrenotazioneModel model)
        {
            int numSuite;
            List<Suite> suite = this.repository.GetSuites();
            if (model.Suite=="1")
            {
                numSuite = 0;
            }else
            {
                numSuite=1;
            }

            if (suite[numSuite].Disponibilita > 0)
            {
                Prenotazione prenotazione = new Prenotazione();
                prenotazione.Suite = model.Suite;
                prenotazione.Week = model.Week;
                prenotazione.IdUser = model.IdUser;
                this.repository.InsertPerson(prenotazione);
            }
            else if (suite[numSuite].Disponibilita > 0)
            {
                Prenotazione prenotazione = new Prenotazione();
                prenotazione.Suite = model.Suite;
                prenotazione.Week = model.Week;
                prenotazione.IdUser = model.IdUser;
                this.repository.InsertPerson(prenotazione);
            }

            //string username = User.Identity.Name;

            return Ok();
        }

    }
}


