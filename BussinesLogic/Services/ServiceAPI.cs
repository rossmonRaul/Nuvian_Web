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
        //Constructos con la URL donde se encuentra el api
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
                    //Convertir el objeto ed tipo lista a un objeto de tipo JSON
                    string obj = JsonConvert.SerializeObject(usuarios);
                    //Formatear el objeto
                    var content = new StringContent(obj, Encoding.UTF8, "application/json");
                    //Se envia la request al api y obtenemos la respuesta que esta nos brinda
                    var respuesta = cliente.PostAsync(_baseurl + "/api/users/postUsuarios", content);
                    //Funcion para que la tarea se complete al 100% para continuar con la ejecucion
                    respuesta.Wait();

                    if (respuesta.Result.IsSuccessStatusCode)
                    {
                        //Obtenemos el mensaje que el API nos brinda y lo convertimos a string para poder realizar la lectura de esta informacion
                        var rest = respuesta.Result.Content.ReadAsStringAsync();
                        //Se formatea la informacion de la respuesta a una model creado anteriormente
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

        //Metodo para eliminar registros 
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
        //Metodo para editar algun registro de un usuario
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
        //Metodo par Listar todos los datos de un usuario
        public async Task<List<UsuariosAll>> ListarUsuarios()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var response = await client.GetAsync("/api/users/UsersInfo");

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
        //Metodo para listar un usuario usando el ID_USR como guia
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
        //Listar todos los aeropuertos para rellenar el combo box del formulario
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
        //Metodo para validar validez del login
        public async Task<bool> login(string cedula, string contrasena)
        {
            bool respuesta = false;

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            //Envio de datos por parametros, este caso no recibe ningun body por lo cual se indica como un null
            var response = await client.PostAsync($"/api/users/login/{cedula}/{contrasena}", null);
            var result = new Login();
            if (response.IsSuccessStatusCode)
            {
                //Obtener la respuesta que envia el api
                var json_response = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Login>(json_response);
                //se valida el contenido de la lista
                //el metodo de login en el api no reenvia de manera correcta las respuestas REST por lo cual se valida con el contenido de la respuesta
                //si el ID_Aeropuerto es igual a 0 quiere decir que el usuario no se encuentra registrado en el sistema
                if (!result.airport.ID_Aeropuerto.Equals(0))
                {
                    respuesta = true;
                }
            }

            return respuesta;
        }

    }
}
