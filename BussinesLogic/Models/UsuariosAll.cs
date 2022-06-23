using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Models
{
    public class UsuariosAll
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Primer_apellido { get; set; }
        public string Segundo_apellido { get; set; }
        public string Aeropuerto { get; set; }
        public System.DateTime FechaIngreso { get; set; }
    }
}
