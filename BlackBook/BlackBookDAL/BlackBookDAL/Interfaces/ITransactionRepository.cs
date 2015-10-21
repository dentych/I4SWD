using BlackBookDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBookDAL.Interfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactions();
        Transaction GetTransactionById(long id);
        void InsertTransaction(Transaction transaction);
        void DeleteTransaction(long id);
        void UpdateTransaction(Transaction transaction);
    }
}
