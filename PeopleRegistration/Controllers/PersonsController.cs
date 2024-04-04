using AutoMapper;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PeopleRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _personRep;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public PersonsController(
            IPersonRepository personRepository,
            ILoggerManager logger,
            IMapper mapper)
        {
            _personRep = personRepository;
            _logger= logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllPersons([FromQuery] PersonParameters personParameters)
        {
            try
            {
                var persons = _personRep.GetAll(personParameters);

                var metadata = new
                {
                    persons.TotalCount,
                    persons.PageSize,
                    persons.CurrentPage,
                    persons.TotalPages,
                    persons.HasNext,
                    persons.HasPrevious
                };

                var personsResult = _mapper.Map<IEnumerable<PersonDto>>(persons);

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                _logger.LogInfo($"Return {personsResult.Count()}owner from the Database");

                return Ok(personsResult);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPersons action: {ex.Message}");

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "PersonById")]
        public IActionResult GetPersons(Guid id)
        {
            try
            {
                var person = _personRep.GetPersonById(id);

                if (person == null)
                {
                    return NotFound();
                }

                var personResult = _mapper.Map<PersonDto>(person);

                return Ok(personResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/details")]
        public IActionResult GetPersonDetails(Guid id)
        {
            try
            {
                var person = _personRep.GetPersonById(id);
                if (person == null)
                {
                    return NotFound();
                }

                var personDetail = _mapper.Map<PersonDetailsDto>(person);
                return Ok(personDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonForCreationDto person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest("Person object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                //for ( int i = 3; i < 100; i ++)
                //{
                //    person.FristName = $"First Name_{i}";
                //    person.NickName = $"Nick Name_{i}";
                //    person.MiddleName = $"Middle Name_{i}";
                //    person.LastName = $"Last Name_{i}";
                //    person.BirthDate = DateTime.UtcNow;
                //    person.BornPlace = $"Born place_{i}";
                //    person.FathersFullName = $"Father's Full Name_{i}";
                //    person.MothersFullName = $"Mother's Full Name_{i}";

                //    var personEntity = _mapper.Map<Person>(person);

                //    _personRep.AddPerson(personEntity);
                //    _personRep.Save();
                //}

                var personEntity = _mapper.Map<Person>(person);

                _personRep.AddPerson(personEntity);
                _personRep.Save();

                var createdPerson = _mapper.Map<PersonDto>(personEntity);

                return CreatedAtRoute("PersonById", new { id = personEntity.PersonId }, createdPerson); ;
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(Guid id, [FromBody]PersonForUpdateDto personForUpdateDto)
        {
            try
            {
                if (personForUpdateDto == null)
                {
                    return BadRequest("Person object is null");
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var personEntity = _personRep.GetPersonById(id);
                if (personEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(personForUpdateDto,personEntity);

                _personRep.UpdatePerson(personEntity);
                _personRep.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(Guid id)
        {
            try
            {
                var person = _personRep.GetPersonById(id);
                if (person == null)
                {
                    return NotFound();
                }

                _personRep.DeletePerson(person);
                _personRep.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
