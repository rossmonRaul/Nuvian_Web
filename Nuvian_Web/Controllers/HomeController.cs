using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nuvian_Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BussinesLogic.Services;

namespace Nuvian_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceAPI _service;

        public HomeController(ILogger<HomeController> logger, IServiceAPI service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HomeView()
        {
            return View();
        }
      
        [HttpPost]
        public async Task<string> Login(string cedula, string contrasena)
        {
            bool resp;
            //Se envian los parametros a la interface para realizar la validacion del login, esta devuelve y bool (true/false) segun la accion con haya respondido la api
            resp = await _service.login(cedula, contrasena);
            return Convert.ToString(resp);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
