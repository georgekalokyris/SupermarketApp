using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Entities
{
    //Implicit data contracts are also supported in WCF but the datamember attribute allows us to play with how those contracts are exposed across the net 
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
