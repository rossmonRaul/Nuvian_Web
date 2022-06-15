using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccess.Models.CIIADHEL_token
{
    public partial class TbAeroFavoritos
    {
        public int IdFavorito { get; set; }
        public int IdAeropuerto { get; set; }
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public string NombreOaci { get; set; }
        public string NombreIcao { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public int UsuarioCreacion { get; set; }
        public int? UsuarioActualizacion { get; set; }
    }
}
