using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Models
{
    public class UsuariosbyID
    {
        public int ID { get; set; }
        public string contrasena { get; set; }
        public string Nombre { get; set; }
        public string Primer_apellido { get; set; }
        public string Segundo_apellido { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public int ID_Aeropuerto { get; set; }
    }
}
