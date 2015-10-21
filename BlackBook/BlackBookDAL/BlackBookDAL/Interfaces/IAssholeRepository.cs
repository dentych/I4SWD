using BlackBookDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBookDAL.Interfaces
{
    public interface IAssholeRepository
    {
        IEnumerable<Asshole> GetAssholes();
        Asshole GetAssholeById(long id);
        void InsertAsshole(Asshole asshole);
        void DeleteAsshole(long id);
        void UpdateAsshole(Asshole asshole);
    }
}
