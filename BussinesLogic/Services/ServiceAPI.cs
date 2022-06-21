using BussinesLogic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class ServiceAPI : IServiceAPI
    {
        private static string _baseurl;
        public ServiceAPI()
        {
            _baseurl = "http://localhost:3033";

        }

        public async Task<bool> EditarUsuario(ActualizarUsuario actualizar)
        {
            bool respuesta = false;

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(actualizar), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/users/EditarUsuario/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<List<UsuariosAll>> ListarUsuarios()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var response = await client.GetAsync("/api/users/UsersInfo");

            //List<Students> list = new List<Students>();
            var list = new UsuariosAllResponse();
            var lst = new List<UsuariosAll>();
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<UsuariosAllResponse>(json_response);
                lst = list.airports;
            }

            return lst;
        }

        public async Task<List<UsuariosbyID>> ObtenerUsuario(int id)
        {
            UsuariosbyIDResponse objeto = new UsuariosbyIDResponse();
            List<UsuariosbyID> lst = new List<UsuariosbyID>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var response = await client.GetAsync($"/api/users/UsersInfoID/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UsuariosbyIDResponse>(json_response);


                objeto = result;

            }
            lst = objeto.Recuperados;
            return lst;
        }
    }
}
