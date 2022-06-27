using BussinesLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLogic.Models;

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
        public bool NuevoUsuario(UserModel user)
        {
            try
            {
                return  _service.Create(user);
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

        [HttpGet]
        public async Task<JsonResult> ListarUsuarios()
        {

            List<UsuariosAll> list = new List<UsuariosAll>();
            list = await _service.ListarUsuarios();
            return Json(list);
        }

        [HttpGet]
        public async Task<JsonResult> CargarCombo()
        {
            List<AirportsModel.airportsList> airports = new List<AirportsModel.airportsList>();
            airports = await _service.ListarAeropuertos();

            return Json(airports);
        }

        [HttpGet]
        public async Task<JsonResult> BuscarUsarioID(int id)
        {
            List<UsuariosbyID> lst = await _service.ObtenerUsuario(id);
            return Json(lst);
        }

        [HttpPost]
        public async Task<bool> EditarUsuario(ActualizarUsuario actualizar)
        {
            return await _service.EditarUsuario(actualizar);
        }


    }
}
