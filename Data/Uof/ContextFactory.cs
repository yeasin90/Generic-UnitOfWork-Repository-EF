using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Uof
{
    public static class ContextFactory
    {
        public static DbContext GetContext(ContextType type)
        {
            switch (type)
            {
                case ContextType.AdventureWorks2012Context:
                    return new AdventureWorks2012Entities();
                default:
                    return null;
            }
        }
    }
}
