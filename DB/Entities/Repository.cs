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
        public List<Prenotaz> GetPersons()
        {
            //select * from persons
            List<Prenotaz> result = this.DBContext.Prenotaz.ToList();
            return result;
        }
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
        public void InsertPerson(Prenotaz prenotaz)
        {
            this.DBContext.Prenotaz.Add(prenotaz);
            this.DBContext.SaveChanges();
        }
    }
}
