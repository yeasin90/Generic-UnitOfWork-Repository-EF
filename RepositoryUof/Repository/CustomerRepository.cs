using Data;
using Data.Uof;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstEF.RepositoryPattern
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(DbContext context)
            : base(context)
        {

        }

        public CustomerRepository()
            : base(ContextType.AdventureWorks2012Context)
        {

        }
    }
}
