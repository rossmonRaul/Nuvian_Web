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

        public UserModel Create(UserModel usuarios)
        {
            var users = new UserModel();

            try
            {
                using (var cliente = new HttpClient())
                {

                    string obj = JsonConvert.SerializeObject(usuarios);
                    var content = new StringContent(obj, Encoding.UTF8, "application/json");
                    var respuesta = cliente.PostAsync(_baseurl + "/api/users/postUsuarios", content);
                    respuesta.Wait();

                    if (respuesta.Result.IsSuccessStatusCode)
                    {
                        var rest = respuesta.Result.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<UserModel>(rest.Result);
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }

            return users;
        }

        public bool Delete(int id)
        {
            var users = new UserModel();
            users.ID_USR = id;

            bool res = false;

            try
            {
                using (var cliente = new HttpClient())
                {

                    string obj = JsonConvert.SerializeObject(users);
                    var content = new StringContent(obj, Encoding.UTF8, "application/json");
                    var respuesta = cliente.DeleteAsync(_baseurl + "/api/users/deleteUsuarios/" + users.ID_USR);
                    respuesta.Wait();

                    if (respuesta.Result.IsSuccessStatusCode)
                    {
                        var rest = respuesta.Result.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<UserModel>(rest.Result);
                        res = true;
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }

            return res;
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

        public async Task<List<AirportsModel.airportsList>> ListarAeropuertos()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var response = await client.GetAsync("/api/airports/");

            //List<Students> list = new List<Students>();
            var list = new AirportsModel();
            var lst = new List<AirportsModel.airportsList>();
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<AirportsModel>(json_response);
                lst = list.airports;
            }

            return lst;
        }

        public async Task<bool> login(string cedula, string contra)
        {
            bool respuesta = false;

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var response = await client.PostAsync($"/api/users/login/{cedula}/{contra}", null);
            var result = new Login();
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Login>(json_response);
                if (!result.airport.ID_Aeropuerto.Equals(0))
                {
                    respuesta = true;
                }
            }

            return respuesta;
        }

    }
}
