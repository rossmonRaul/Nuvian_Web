using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Models
{
    public class UsuariosbyID
    {
        public int id_usr { get; set; }
        public int identificacion { get; set; }
        public string contrasena { get; set; }
        public string nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string correo { get; set; }
        public int telefono { get; set; }
        public System.DateTime fechanacimiento { get; set; }
        public int id_aeropuerto { get; set; }
    }
}
