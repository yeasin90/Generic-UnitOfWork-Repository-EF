# A Generic UnitOfWork and Repository pattern for Entity Framework
This can be used for any of your model class. 

# Example
ContactTypeRepository re = new ContactTypeRepository();
UnitOfWork uof = new UnitOfWork(ContextType.AdventureWorks2012Context);

uof.GetRepo<ContactTypeRepository>().Insert(new ContactType { ModifiedDate = DateTime.Now, Name = "TestType102" });
uof.GetRepo<ContactTypeRepository>().Insert(new ContactType { ModifiedDate = DateTime.Now, Name = "TestType113" });
uof.Commit();
