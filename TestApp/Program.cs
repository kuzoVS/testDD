using CoreContext;
using Microsoft.EntityFrameworkCore;
using testDD.Models;
using testDD.Context;
using cc = CoreContext;

var optionsBuilder = new DbContextOptionsBuilder<YourDbContext>();
optionsBuilder.UseNpgsql("Host=localhost;Database=testWEB;Username=postgres;Password=123");

var dbContext = new YourDbContext(optionsBuilder.Options);

dbContext.Database.EnsureCreated();

var helperDB = new HelperDB(dbContext);

var newPerson = new Person
{
    Id = Guid.NewGuid(),
    FullName = "John Doe",
    Age = 32,
    DateOfBirth = DateTime.UtcNow,
    Gender = "Male",
    IsMarried = false
};
await helperDB.CreatePersonAsync(newPerson);

var allPersons = await helperDB.GetAllPersonsAsync();
foreach (var person in allPersons)
{
    Console.WriteLine($"ID: {person.Id}, Name: {person.FullName}, Age: {person.Age}");
}
