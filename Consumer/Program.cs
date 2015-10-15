using Data;
using Data.Uof;
using DBFirstEF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork uof = new UnitOfWork(ContextType.AdventureWorks2012Context);

            uof.GetRepo<ContactTypeRepository>().Insert(new ContactType { ContactTypeID = 133, ModifiedDate = DateTime.Now, Name = "Type1" });
            uof.GetRepo<ContactTypeRepository>().Insert(new ContactType { ContactTypeID = 134, ModifiedDate = DateTime.Now, Name = "Type2" });
            uof.GetRepo<AddressTypeRepository>().Insert(new AddressType { AddressTypeID = 450, ModifiedDate = DateTime.Now, Name = "Type121", rowguid = new Guid() });
            uof.Commit();

            ContactTypeRepository contactRepo = new ContactTypeRepository();
            contactRepo.Insert(new ContactType { ContactTypeID = 107, ModifiedDate = DateTime.Now, Name = "Type3" });
            contactRepo.Commit();
        }
    }
}
