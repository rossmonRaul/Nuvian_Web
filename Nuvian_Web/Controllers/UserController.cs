using BussinesLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nuvian_Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IServiceAPI _service;
        public UserController(ILogger<UserController> logger, IServiceAPI service)
        {
            _logger = logger;
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BasePage()
        {
            return View();
        }

     


        [HttpPost]
        public IActionResult NuevoUsuario(UserModel user)
        {
            try
            {
                _service.Create(user);

                return View();

            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        public bool EliminarUsuario(UserModel user)
        {
            try
            {
             
                return _service.Delete(user.ID_USR); 

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
