using DBFirstEF.UoFRepo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstEF.Repository
{
    public class AddressTypeRepository : Repository<AddressType>
    {
        public AddressTypeRepository(DbContext context = null) 
            : base(context)
        {

        }
    }
}
