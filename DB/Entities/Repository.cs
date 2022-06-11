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

        //public Suite GetSuiteByID(string id)
        //{
        //    Suite result = this.DBContext.Suites.Where(p => p.Id.ToString() == id).FirstOrDefault();
        //    return result;
        //}

        /*public List<Suite> GetSuites()
        {
            //select* from persons
            List<Suite> result = this.DBContext.Suites.ToList();



            //Suite esempio = GetSuiteByID("000000");
            //esempio.Nome = "new name";
            //this.UpdateSuite(esempio);



            return result;
        }*/

        //public Person GetPersonByID(string id)
        //{
        //    //select * from persons where id = "id"
        //    Person result = this.DBContext.Persons.Where(p => p.ID.ToString() == id).FirstOrDefault();
        //    return result;
        //}
        //public List<Prenotaz> GetPersonWithFilter(string filter)
        //{
        //    //select * from persons where nome like "%filter%"
        //    //or cognome like "%filter%"
        //    List<Prenotaz> result = this.DBContext.Prenotaz
        //        .Where(p => p.Nome.Contains(filter)
        //        || p.Cognome.Contains(filter)).ToList();
        //    return result;
        //}
        public void InsertPerson(Prenotazione prenotaz)
        {
            this.DBContext.Prenotazioni.Add(prenotaz);
            this.DBContext.SaveChanges();
        }

        public void UpdateSuite(Suite suite) {
            this.DBContext.Suites.Update(suite);
            this.DBContext.SaveChanges();
        }
    }
}
