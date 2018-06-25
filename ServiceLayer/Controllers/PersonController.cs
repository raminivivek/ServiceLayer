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
using ServiceLayer;

namespace ServiceLayer.Controllers
{
    public class PersonController : ApiController
    {
        private ReqprojectEntities db = new ReqprojectEntities();

        // GET: api/Person
        public IQueryable<Person_T> GetPerson_T()
        {
            return db.Person_T;
        }

        // GET: api/Person/5
        [ResponseType(typeof(Person_T))]
        public IHttpActionResult GetPerson_T(int id)
        {
            Person_T person_T = db.Person_T.Find(id);
            if (person_T == null)
            {
                return NotFound();
            }

            return Ok(person_T);
        }

        // PUT: api/Person/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson_T(int id, Person_T person_T)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person_T.Person_IDNO)
            {
                return BadRequest();
            }

            db.Entry(person_T).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Person_TExists(id))
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
        [ResponseType(typeof(Person_T))]
        public IHttpActionResult PostPerson_T(Person_T person_T)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Person_T.Add(person_T);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Person_TExists(person_T.Person_IDNO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = person_T.Person_IDNO }, person_T);
        }

        // DELETE: api/Person/5
        [ResponseType(typeof(Person_T))]
        public IHttpActionResult DeletePerson_T(int id)
        {
            Person_T person_T = db.Person_T.Find(id);
            if (person_T == null)
            {
                return NotFound();
            }

            db.Person_T.Remove(person_T);
            db.SaveChanges();

            return Ok(person_T);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Person_TExists(int id)
        {
            return db.Person_T.Count(e => e.Person_IDNO == id) > 0;
        }
    }
}