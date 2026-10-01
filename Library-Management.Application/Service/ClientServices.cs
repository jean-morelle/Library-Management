using Librairi_Management.Domain.Interface;
using Librairi_Management.Domain.Models;
using Library_Management.Repertory;

namespace Library_Management.Application.Service
{
    public class ClientServices: IClientServices
    {
        private readonly IClientRepertory clientRepertory;
        private readonly IEmpruntRepertory empruntRepertory;

        public ClientServices(IClientRepertory clientRepertory, IEmpruntRepertory empruntRepertory)
        {
            this.clientRepertory = clientRepertory;
            this.empruntRepertory = empruntRepertory;
        }

        public async Task AjouterClientAsync(Client client)
        {
            await clientRepertory.AjouterClientAsync(client);
        }

        public async Task MettreAjoursClientAsync(Client client)
        {
            await clientRepertory.MettreAjoursClientAsync(client);
        }

        public Task<Client?> ObtenirClientParId(Guid Id)
        {
            return clientRepertory.ObtenirClientParId(Id);
        }

        public Task<IEnumerable<Client>> ObtenirTousLesClients()
        {
            return clientRepertory.ObtenirTousLesClients();
        }

        public async Task SupprimerClientAsync(Guid Id)
        {
            if (await empruntRepertory.ClientAEmpruntEnCoursAsync(Id))
            {
                throw new RegleMetierException("Impossible de supprimer un client qui a des emprunts en cours.");
            }
            await clientRepertory.SupprimerClientAsync(Id);
        }
    }
}
