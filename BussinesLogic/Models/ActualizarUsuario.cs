using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Models
{
    public class ActualizarUsuario
    {
        public int Id_usr { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Cedula { get; set; }
        public int Id_aeropuerto { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
    }
}
