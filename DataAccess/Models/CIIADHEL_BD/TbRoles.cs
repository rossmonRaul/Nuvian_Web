using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccess.Models.CIIADHEL_BD
{
    public partial class TbRoles
    {
        public TbRoles()
        {
            TbUsuarios = new HashSet<TbUsuarios>();
        }

        public int IdRol { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<TbUsuarios> TbUsuarios { get; set; }
    }
}
