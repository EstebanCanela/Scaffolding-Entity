using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MBB.Abrigo.Core.DTO;
using MBB.Abrigo.Infrastructure;
using MBB.Abrigo.Infrastructure.Managers;

namespace MBB.Abrigo.WebApi.Controllers
{
    public class PersonController : ApiController
    {
        private PersonManager personManager = new PersonManager();

        // GET: api/Person
        [Authorize]
        public IEnumerable<PersonDTO> GetPersons()
        {
            return personManager.GetAll();
        }

        
        // GET: api/Person/5
        [ResponseType(typeof(PersonDTO))]
        public IHttpActionResult GetPerson(string id)
        {
            
            PersonDTO personDTO = personManager.FindById(id);
            if (personDTO == null)
            {
                return NotFound();
            }

            return Ok(personDTO);
        }
        
        // PUT: api/Person/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonDTO(string id, PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personDTO.Id)
            {
                return BadRequest();
            }

            return Ok(personManager.Edit(personDTO));
        }
        
        // POST: api/Person
        [ResponseType(typeof(PersonDTO))]
        public IHttpActionResult PostPersonDTO(PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(personManager.Add(personDTO));
        }
        
        // DELETE: api/Person/5
        [ResponseType(typeof(PersonDTO))]
        public IHttpActionResult DeletePersonDTO(string id)
        {
            
            if (id != null)
            {
                return Ok(personManager.Remove(id));
            }
            else
            {
                return BadRequest();
            }
        }
        
    }
}