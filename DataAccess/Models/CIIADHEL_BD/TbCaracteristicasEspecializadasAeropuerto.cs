using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccess.Models.CIIADHEL_BD
{
    public partial class TbCaracteristicasEspecializadasAeropuerto
    {
        public int IdCarEspAero { get; set; }
        public int? IdAeropuerto { get; set; }
        public int Publico { get; set; }
        public int Controlado { get; set; }
        public string Coordenada { get; set; }
        public string InfoTorre { get; set; }
        public string InfoGeneral { get; set; }
        public string EspacioAereo { get; set; }
        public string Combustible { get; set; }
        public string NormaGeneral { get; set; }
        public string NormaParticular { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public int UsuarioCreacion { get; set; }
        public int? UsuarioActualizacion { get; set; }

        public virtual TbAeropuerto IdAeropuertoNavigation { get; set; }
    }
}
