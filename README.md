# A Generic UnitOfWork and Repository pattern for Entity Framework
This can be used for any of your model class. 

# Example
UnitOfWork uof = new UnitOfWork(ContextType.AdventureWorks2012Context);

uof.GetRepo<ContactTypeRepository>().Insert(new ContactType { ContactTypeID = 133, ModifiedDate = DateTime.Now, Name = "Type1" });
uof.GetRepo<ContactTypeRepository>().Insert(new ContactType { ContactTypeID = 134, ModifiedDate = DateTime.Now, Name = "Type2" });
uof.GetRepo<AddressTypeRepository>().Insert(new AddressType { AddressTypeID = 450, ModifiedDate = DateTime.Now, Name = "Type121", rowguid = new Guid() });

uof.Commit();

ContactTypeRepository contactRepo = new ContactTypeRepository();
contactRepo.Insert(new ContactType { ContactTypeID = 107, ModifiedDate = DateTime.Now, Name = "Type3" });

contactRepo.Commit();
