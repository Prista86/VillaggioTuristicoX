using System;

namespace MVC_TDPC13.DB.Entities
{
    public class Prenotazione
    {
        public Guid? ID { get; set; }
        public string Suite { get; set; }
        public string Week { get; set; }
        public string IdUser { get; set; }

    }
}
