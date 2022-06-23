using BussinesLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public interface IServiceAPI
    {
        UserModel Create(UserModel usuarios);

        bool Delete(int ID_USR);
    }
}
