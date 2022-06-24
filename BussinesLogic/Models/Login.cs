using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Models
{
    public class Login
    {
        public bool ok { get; set; }
        public string cedula { get; set; }
        public logList airport { get; set; }
        public class logList
        {
            public int ID_Aeropuerto { get; set; }
        }
    }
}
