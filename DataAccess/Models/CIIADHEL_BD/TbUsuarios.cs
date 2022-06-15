using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccess.Models.CIIADHEL_BD
{
    public partial class TbUsuarios
    {
        public int IdUsr { get; set; }
        public string NombreUsr { get; set; }
        public byte[] Contraseña { get; set; }
        public int Cedula { get; set; }
        public int IdRol { get; set; }
        public int? IdAeropuerto { get; set; }

        public virtual TbAeropuerto IdAeropuertoNavigation { get; set; }
        public virtual TbRoles IdRolNavigation { get; set; }
    }
}
