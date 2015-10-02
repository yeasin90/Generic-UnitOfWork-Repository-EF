using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstEF.UoFRepo
{
    public static class ContextFactory
    {
        public static BaseDBContext GetContext(ContextType type)
        {
            switch (type)
            {
                case ContextType.AdventureWorks2012Context:
                    return new AdventureWorks2012Context();
                default:
                    return null;
            }
        }
    }

    public enum ContextType
    {
        AdventureWorks2012Context
    }
}
