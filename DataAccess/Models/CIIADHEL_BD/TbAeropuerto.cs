using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccess.Models.CIIADHEL_BD
{
    public partial class TbAeropuerto
    {
        public TbAeropuerto()
        {
            Notams = new HashSet<Notams>();
            TbCaracteristicasEspecializadasAeropuerto = new HashSet<TbCaracteristicasEspecializadasAeropuerto>();
            TbContacto = new HashSet<TbContacto>();
            TbFrecuencias = new HashSet<TbFrecuencias>();
            TbPistas = new HashSet<TbPistas>();
            TbUsuarios = new HashSet<TbUsuarios>();
        }

        public int IdAeropuerto { get; set; }
        public string Nombre { get; set; }
        public string NombreOaci { get; set; }
        public string NombreIcao { get; set; }
        public string EstadoAeropuerto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public int UsuarioCreacion { get; set; }
        public int UsuarioActualizacion { get; set; }

        public virtual ICollection<Notams> Notams { get; set; }
        public virtual ICollection<TbCaracteristicasEspecializadasAeropuerto> TbCaracteristicasEspecializadasAeropuerto { get; set; }
        public virtual ICollection<TbContacto> TbContacto { get; set; }
        public virtual ICollection<TbFrecuencias> TbFrecuencias { get; set; }
        public virtual ICollection<TbPistas> TbPistas { get; set; }
        public virtual ICollection<TbUsuarios> TbUsuarios { get; set; }
    }
}
