# A Generic UnitOfWork and Repository pattern for Entity Framework
This can be used for any of your model class. 

# Example
UnitOfWork uof = new UnitOfWork();

uof.GetRepo<ContactTypeRepository>().Insert(new ContactType { ModifiedDate = DateTime.Now, Name = "TestType102" });
uof.GetRepo<ContactTypeRepository>().Insert(new ContactType { ModifiedDate = DateTime.Now, Name = "TestType113" });
uof.GetRepo<AddressTypeRepository>().Insert(new AddressType { Col1 = DateTime.Now, Col2 = "TestType113" });
uof.Commit();
