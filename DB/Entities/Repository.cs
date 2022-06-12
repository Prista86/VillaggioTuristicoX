using MVC_TDPC13.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_TDPC13.DB.Entities
{
    public class Repository
    {
        private DBContext DBContext;
        public int Scelta;
        //public int scelta;
        public Repository(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }
        public List<Prenotazione> GetPrenotazioni()
        {
            //select * from persons
            List<Prenotazione> result = this.DBContext.Prenotazioni.ToList();
            return result;
        }


        public List<Suite> VerificaSilver()
        {
            //select* from persons
            List<Suite> result = this.DBContext.Suites.ToList();
            
            Suite esempio = GetSuiteByID("1");
            if (esempio.Disponibilita > 0)
            {
                esempio.Disponibilita -= 1;
                this.UpdateSuite(esempio);
                
                return result;
            }
            return result;
        }
        public List<Suite> VerificaGold()
        {
            //select* from persons
            List<Suite> result = this.DBContext.Suites.ToList();
            
            Suite esempio = GetSuiteByID("2");
            if (esempio.Disponibilita > 0)
            {
                esempio.Disponibilita -= 1;
                this.UpdateSuite(esempio);
                
                return result;
            }
            return result;
            
        }

        public List<Prenotazione> GetPersonWithFilter(string filter)
        {
            //select * from persons where nome like "%filter%"
            //or cognome like "%filter%"
            List<Prenotazione> result = this.DBContext.Prenotazioni
                .Where(p => p.User.Contains(filter)).ToList();
            return result;
        }



        public List<Suite> GetSuites()
        {
            //select* from persons
            List<Suite> result = this.DBContext.Suites.ToList();            
            return result;
        }
        public void InsertPrenotazione(Prenotazione prenotazione)
        {
            this.DBContext.Prenotazioni.Add(prenotazione);
            this.DBContext.SaveChanges();
        }

        public Suite GetSuiteByID(string id)
        {
            //select * from persons where id = "id"            
            Suite suiteCont = this.DBContext.Suites.Where(p => p.Id.ToString() == id).FirstOrDefault();
            return suiteCont;
        }

        public void UpdateSuite(Suite suite)
        {
            this.DBContext.Suites.Update(suite);
            this.DBContext.SaveChanges();
        }
    }
}
