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
        

        public PrenotazioneController(Repository repository)
        {
            this.repository = repository;
            
        }
        


        // POST api/<PrenotazioneController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PrenotazioneModel model)
        {
            
            List<Suite> suite = this.repository.GetSuites();


            int numSuite;
            if (model.Suite == "Silver")
            {
                numSuite = 0;
            }
            else
            {
                numSuite = 1;
            }




            if (suite[numSuite].Disponibilita > 0)
            {
                Prenotazione prenotazione = new Prenotazione();
                prenotazione.Suite = model.Suite;
                prenotazione.Week = model.Week;
                prenotazione.User = model.User;
                this.repository.InsertPrenotazione(prenotazione);
            }
            

            //string username = User.Identity.Name;

            return Ok();
        }

    }
}


