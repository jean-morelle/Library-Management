using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager.Core.Interface
{
    public interface IUserServices
    {
     public Task <IEnumerable<Utilisateur>> GetUtilisateurs();

     public Task< Utilisateur> GetUtilisateur(int id);

     public Task CreateUser(Utilisateur utilisateur);

     public Task DeleteUser(int id);

     public Task UpdateUser(Utilisateur utilisateur);

    }
}
