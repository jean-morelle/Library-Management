using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager.Core.Interface
{
    public interface IEmpruntServices
    {
        public Task<Emprunt> GetEmprunt(int id);

        public Task<IEnumerable< Emprunt>> GetEmprunts();


        public Task CreateEmprunt(Emprunt emprunt);

        public Task DeleteEmprunt(int id);


        public Task UpdateEmprunt(Emprunt emprunt);
    }
}
