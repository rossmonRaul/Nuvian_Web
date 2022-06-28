using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Models
{
    public class UsuariosbyID
    {
        public int Id_usr { get; set; }
        public int Identificacion { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Primer_apellido { get; set; }
        public string Segundo_apellido { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public System.DateTime Fecha_nacimiento { get; set; }
        public int Id_aeropuerto { get; set; }
    }
}
