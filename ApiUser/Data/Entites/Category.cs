using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUser.Data.Entites
{
    public class Category: BaseEntitiy
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
