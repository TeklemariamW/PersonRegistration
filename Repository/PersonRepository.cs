using Entities;
using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        { 
        }

        public IEnumerable<Person> GetAll()
        {
            return FindAll()
                .OrderByDescending(birth => birth.BirthDate)
                .ToList();
        }

        public Person GetPersonById(Guid id)
        {
            return FindByCondition(p => p.PersonId.Equals(id))
                .FirstOrDefault();
        }

        public Person PersonDetails(Guid id)
        {
            return FindByCondition(p => p.PersonId.Equals(id))
                .FirstOrDefault();
        }

        public void AddPerson(Person person)
        {
            Create(person);
        }

        public void UpdatePerson(Person person)
        {
            Update(person);
        }
        public void DeletePerson(Person person)
        {
            Delete(person);
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
