using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Models
{
    public class UsuariosAllResponse
    {
        public bool ok { get; set; }
        public int length { get; set; }
        public List<UsuariosAll> airports { get; set; }
    }
}
