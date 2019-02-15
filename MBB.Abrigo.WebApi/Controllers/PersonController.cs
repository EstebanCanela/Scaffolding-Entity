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
        public IEnumerable<PersonDTO> GetPersons()
        {
            return personManager.GetAll();
        }

        
        // GET: api/Person/5
        [ResponseType(typeof(PersonDTO))]
        public IHttpActionResult GetPerson(int id)
        {
            PersonDTO personDTO = personManager.FindById(id);
            if (personDTO == null)
            {
                return NotFound();
            }

            return Ok(personDTO);
        }
        /*
        // PUT: api/Person/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonDTO(int id, PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personDTO.Id)
            {
                return BadRequest();
            }

            db.Entry(personDTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonDTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Person
        [ResponseType(typeof(PersonDTO))]
        public IHttpActionResult PostPersonDTO(PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonDTOes.Add(personDTO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personDTO.Id }, personDTO);
        }

        // DELETE: api/Person/5
        [ResponseType(typeof(PersonDTO))]
        public IHttpActionResult DeletePersonDTO(int id)
        {
            PersonDTO personDTO = db.PersonDTOes.Find(id);
            if (personDTO == null)
            {
                return NotFound();
            }

            db.PersonDTOes.Remove(personDTO);
            db.SaveChanges();

            return Ok(personDTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonDTOExists(int id)
        {
            return db.PersonDTOes.Count(e => e.Id == id) > 0;
        }*/
    }
}