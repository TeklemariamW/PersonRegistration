﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetPersonById(Guid personId);
        Person PersonDetails(Guid personId);
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
        void Save();
    }
}
