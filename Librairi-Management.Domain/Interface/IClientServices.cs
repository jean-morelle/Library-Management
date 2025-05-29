using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librairi_Management.Domain.Models;

namespace Librairi_Management.Domain.Interface
{
    public interface IClientServices
    {
        Task<IEnumerable<Client>> ObtenirTousLesClients();
        Task<Client> ObtenirClientParId(Guid Id);
        Task AjouterClientAsync(Client client);
        Task SupprimerClientAsync(Guid Id);
        Task MettreAjoursClientAsync(Client client);
    }
}
