using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librairi_Management.Domain.Interface;
using Librairi_Management.Domain.Models;

namespace Library_Management.Application.Service
{
    public class ClientServices: IClientServices
    {
        private readonly IClientRepertory clientRepertory;

        public ClientServices(IClientRepertory clientRepertory)
        {
            this.clientRepertory = clientRepertory;
        }

        public async Task AjouterClientAsync(Client client)
        {
            await clientRepertory.AjouterClientAsync(client);
        }

        public async Task MettreAjoursClientAsync(Client client)
        {
            await clientRepertory.MettreAjoursClientAsync(client);
        }

        public async Task<Client> ObtenirClientParId(Guid Id)
        {
            var client = await clientRepertory.ObtenirClientParId(Id);
            return client;
        }

        public async Task<IEnumerable<Client>> ObtenirTousLesClients()
        {
            var client = await clientRepertory.ObtenirTousLesClients();
            return client;
        }

        public async Task SupprimerClientAsync(Guid Id)
        {
            await clientRepertory.SupprimerClientAsync(Id);
        }
    }
}
