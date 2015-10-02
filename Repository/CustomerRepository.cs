using DBFirstEF.UoFRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstEF.RepositoryPattern
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(BaseDBContext context = null) 
            : base(context)
        {

        }
    }
}
