using System;

namespace Modelo
{
    public class Procesos_OrigenDestinoArchivos
    {
        public long ProcessNr { get; set; }
        public string PathFrom { get; set; }
        public string PathTo { get; set; }
        public long Created_User_Id { get; set; }
        public long Modified_User_Id { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Updated_Date { get; set; }
        public bool Deleted { get; set; }
    }
}
