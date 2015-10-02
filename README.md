# Generic-UnitOfWork-Repository-EF
A generic Unit of Work and Repository pattern for Entity framework. Can be used with any Context class.

# Example
UnitOfWork uof = new UnitOfWork();

uof.GetRepo<ContactTypeRepository>().Insert(new ContactType { ModifiedDate = DateTime.Now, Name = "TestType102" });
uof.GetRepo<ContactTypeRepository>().Insert(new ContactType { ModifiedDate = DateTime.Now, Name = "TestType113" });
uof.GetRepo<AddressTypeRepository>().Insert(new AddressType { Col1 = DateTime.Now, Col2 = "TestType113" });
uof.Commit();
