using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Models
{
    public class UsuariosAll
    {

        public int Id_usr { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Primer_apellido { get; set; }
        public string Segundo_apellido { get; set; }
        public string Aeropuerto { get; set; }
        public string Correo { get; set; }
        public string Fecha_ingreso { get; set; }
    }
}
