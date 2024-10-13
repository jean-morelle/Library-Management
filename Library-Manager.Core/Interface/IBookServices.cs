using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager.Core.Interface
{
    public interface IBookServices
    {

        public Task<IEnumerable<Livre>> GetLivres();

        public Task<Livre> GetLivre();

        public Task CreateBook( Livre livre);

        public Task DeleteBook(int id);

        public Task UpdateBook(Livre livre);
    }
}
