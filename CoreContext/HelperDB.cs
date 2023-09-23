using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testDD.Context;
using testDD.Models;

namespace CoreContext
{
    public class HelperDB
    {
        private readonly YourDbContext _context;

        public HelperDB(YourDbContext context)
        {
            _context = context;
        }

        public async Task<Person> GetPersonAsync(Guid id)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task CreatePersonAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePersonAsync(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(Guid id)
        {
            var person = await GetPersonAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
