using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Client> ObtenirClientParId(Guid Id)
        {
            var client = await applicationDbContext.Clients.FirstOrDefaultAsync(x=>x.Id == Id);
            return client;
        }

        public async Task<IEnumerable<Client>> ObtenirTousLesClients()
        {
            var client = await applicationDbContext.Clients.ToListAsync();
            return client;
        }

        public async Task SupprimerClientAsync(Guid Id)
        {
            var client = await applicationDbContext.Clients.FirstOrDefaultAsync(x => x.Id == Id);
            if(client is null)
            {
                throw new Exception();
            }
            else
            {
                applicationDbContext.Clients.Remove(client);
                await  applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
