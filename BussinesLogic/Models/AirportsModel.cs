using System.Collections.Generic;

namespace BussinesLogic.Models
{
    public class AirportsModel
    {
        public bool ok { get; set; }
        public int length { get; set; }
        public List<airportsList> airports{ get; set; }
        public class airportsList
        {
            public int ID_Aeropuerto { get; set; }
            public string Nombre { get; set; }
            public string Nombre_OACI { get; set; }
            public string NombreICAO { get; set; }
        }
    }
}
