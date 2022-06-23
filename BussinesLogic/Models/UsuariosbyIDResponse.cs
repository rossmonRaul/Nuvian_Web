using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Models
{
    public class UsuariosbyIDResponse
    {
        public bool ok { get; set; }
        public List<UsuariosbyID> Recuperados { get; set; }
    }
}
