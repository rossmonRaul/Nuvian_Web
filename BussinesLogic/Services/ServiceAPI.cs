
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

            try {
                using ( var cliente = new HttpClient())
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
            catch (Exception) {
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
    }
}
