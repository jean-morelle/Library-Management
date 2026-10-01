using Librairi_Management.Domain.Interface;
using Librairi_Management.Domain.Models;
using Library_Management.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.Infrastructure.Repertory
{
    public class ClientRepertory:IClientRepertory
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ClientRepertory(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AjouterClientAsync(Client client)
        {
            applicationDbContext.Clients.Add(client);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task MettreAjoursClientAsync(Client client)
        {
            applicationDbContext.Clients.Update(client);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Client?> ObtenirClientParId(Guid Id)
        {
            return await applicationDbContext.Clients.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<Client>> ObtenirTousLesClients()
        {
            return await applicationDbContext.Clients.OrderBy(c => c.Nom).ToListAsync();
        }

        public async Task SupprimerClientAsync(Guid Id)
        {
            var client = await applicationDbContext.Clients.FirstOrDefaultAsync(x => x.Id == Id);
            if (client is null)
            {
                throw new KeyNotFoundException("Client non trouvé");
            }

            applicationDbContext.Clients.Remove(client);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
