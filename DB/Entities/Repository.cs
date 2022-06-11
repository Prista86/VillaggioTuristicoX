using System.Collections.Generic;
using System.Linq;

namespace MVC_TDPC13.DB.Entities
{
    public class Repository
    {
        private DBContext DBContext;
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
        
        public Suite GetSuiteByID(string id)
        {
            //select * from persons where id = "id"
            Suite result = this.DBContext.Suites.Where(p => p.Id.ToString() == id).FirstOrDefault();
            return result;
        }

        public List<Suite> GetSuites()
        {
            //select* from persons
            List<Suite> result = this.DBContext.Suites.ToList();



            Suite esempio = GetSuiteByID("1");
            esempio.Disponibilita -= 1;
            this.UpdateSuite(esempio);



            return result;
        }

        

        
        
        public void InsertPerson(Prenotazione prenotazione)
        {
            this.DBContext.Prenotazioni.Add(prenotazione);
            this.DBContext.SaveChanges();
        }

        public void UpdateSuite(Suite suite) {
            this.DBContext.Suites.Update(suite);
            this.DBContext.SaveChanges();
        }
    }
}
