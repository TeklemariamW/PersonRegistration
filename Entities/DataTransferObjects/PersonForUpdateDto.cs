using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class PersonForUpdateDto
    {
        public Guid PersonId { get; set; }
        public string? FristName { get; set; }
        public string? NickName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public string? BornPlace { get; set; }
        public string? DeathPlace { get; set; }
        public bool IsAlive { get; set; } = true;
        public string? FathersFullName { get; set; }
        public string? MothersFullName { get; set; }
    }
}
