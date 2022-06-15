using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccess.Models.CIIADHEL_BD
{
    public partial class TbContacto
    {
        public int IdContacto { get; set; }
        public int IdAeropuerto { get; set; }
        public string DireccionExacta { get; set; }
        public string NumeroTelefono1 { get; set; }
        public string NumeroTelefono2 { get; set; }
        public string Horario { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public int UsuarioCreacion { get; set; }
        public int? UsuarioActualizacion { get; set; }

        public virtual TbAeropuerto IdAeropuertoNavigation { get; set; }
    }
}
