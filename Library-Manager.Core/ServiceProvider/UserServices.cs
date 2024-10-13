using Library_Management.Models;
using Library_Manager.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager.Core.ServiceProvider
{
    public class UserServices : IUserServices
    {
        private readonly HttpClient httpClient;

        public UserServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
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

        public Task<IEnumerable<Utilisateur>> GetUtilisateurs()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }
    }
}
