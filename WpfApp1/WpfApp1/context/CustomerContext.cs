using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.model;

namespace WpfApp1.context
{
    class CustomerContext: DbContext
    {
        public CustomerContext() :base("session"){

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
