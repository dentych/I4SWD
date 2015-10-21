using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBookDAL.Models
{
    public class Transaction
    {
        public long ID { get; set; }
        public long DebitorID { get; set; }
        public int Amount { get; set; }
        public string Date { get; set; }
    }
}
