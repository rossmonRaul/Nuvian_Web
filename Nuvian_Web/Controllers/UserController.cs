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

       
    }
}
