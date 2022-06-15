using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccess.Models.CIIADHEL_BD
{
    public partial class TbPistas
    {
        public int IdPista { get; set; }
        public int IdAeropuerto { get; set; }
        public string Pista { get; set; }
        public string Elevacion { get; set; }
        public string SuperficiePista { get; set; }
        public int? AsdaRwy1 { get; set; }
        public int? AsdaRwy2 { get; set; }
        public int? TodaRwy1 { get; set; }
        public int? TodaRwy2 { get; set; }
        public int? ToraRwy1 { get; set; }
        public int? ToraRwy2 { get; set; }
        public int? LdaRwy1 { get; set; }
        public int? LdaRwy2 { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public int UsuarioCreacion { get; set; }
        public int? UsuarioActualizacion { get; set; }

        public virtual TbAeropuerto IdAeropuertoNavigation { get; set; }
    }
}
