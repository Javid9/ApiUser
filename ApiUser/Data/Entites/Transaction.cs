using ApiUser.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUser.Data.Entites
{
    public class Transaction:BaseEntitiy
    {
        public TransactionType Type { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public string Desc { get; set; }

    }
}
