using Data;
using Data.Uof;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstEF.Repository
{
    public class SalesPersonRepository : Repository<SalesPerson>
    {
         public SalesPersonRepository(DbContext context) 
            : base(context)
        {
             
        }

         public SalesPersonRepository()
            : base(ContextType.AdventureWorks2012Context)
        {
             
        }
    }
}
