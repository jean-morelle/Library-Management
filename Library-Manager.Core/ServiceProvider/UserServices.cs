using Library_Management.Models;
using Library_Manager.Core.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library_Manager.Core.ServiceProvider
{
    public class UserServices : IUserServices
    {
        //  private static string requeteUrl = "https://localhost:7047/api/User";
        private const string requeteUrl = "api/User";

        private readonly HttpClient httpClient;
        private readonly IAlertServices alertServices;

        public UserServices(HttpClient httpClient , IAlertServices alertServices)
        {
            this.httpClient = httpClient;
            this.alertServices = alertServices;
        }

        public Task CreateUser(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Utilisateur> GetUtilisateur(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Utilisateur>> GetUtilisateurs()
        {
            try {
                var httpResponse = await httpClient.GetAsync(requeteUrl);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var stringContent = await httpResponse.Content.ReadAsStringAsync();
                    var utilisateurs = JsonConvert.DeserializeObject<IEnumerable<Utilisateur>>(stringContent);

                    if (utilisateurs == null)
                    {
                       // alertServices.ShowAlert("No User found");
                      return new List<Utilisateur>();
                    }
                    return utilisateurs;
                }

                if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    alertServices.ShowAlert("Bad request.");
                }

            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }


        public Task UpdateUser(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }
    }
}
