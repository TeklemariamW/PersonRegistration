using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class PersonForCreationDto
    {
        [Required(ErrorMessage = "First Name is required")]
        public string? FristName { get; set; }
        public string? NickName { get; set; }
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Birth place name is required")]
        public string? BornPlace { get; set; }

        [Required(ErrorMessage = "Father's full-name is required")]
        public string? FathersFullName { get; set; }
        [Required(ErrorMessage = "Mother's full-name is required")]
        public string? MothersFullName { get; set; }
    }
}
