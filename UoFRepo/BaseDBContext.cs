using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstEF.UoFRepo
{
    public abstract class BaseDBContext : DbContext
    {
        public BaseDBContext(string contextName) 
            : base(contextName)
        {

        }
    }
}
