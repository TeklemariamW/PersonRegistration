using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Person
    {
        public Guid PersonId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string? FristName { get; set; }
        public string? NickName { get; set; }
        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime BirthDate { get; set;}
        public DateTime DeathDate { get; set;}
        [Required(ErrorMessage = "Birth place name is required")]
        public string? BornPlace { get; set; }
        public string? DeathPlace { get; set; }
        public bool IsAlive { get; set;} = true;

        [Required(ErrorMessage = "Father's full-name is required")]
        public string? FathersFullName { get; set; }
        [Required(ErrorMessage = "Mother's full-name is required")]
        public string? MothersFullName { get; set; }
    }
}
