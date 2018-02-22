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
using Ead2Ca1Template.Models;

namespace Ead2Ca1Template.Controllers
{
    public class GenericsController : ApiController
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: api/Generics
        public IQueryable<Generic> GetGenerics()
        {
            return db.Generics;
        }

        // GET: api/Generics/5
        [ResponseType(typeof(Generic))]
        public IHttpActionResult GetGeneric(int id)
        {
            Generic generic = db.Generics.Find(id);
            if (generic == null)
            {
                return NotFound();
            }

            return Ok(generic);
        }

        // PUT: api/Generics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGeneric(int id, Generic generic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != generic.ID)
            {
                return BadRequest();
            }

            db.Entry(generic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenericExists(id))
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

        // POST: api/Generics
        [ResponseType(typeof(Generic))]
        public IHttpActionResult PostGeneric(Generic generic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Generics.Add(generic);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = generic.ID }, generic);
        }

        // DELETE: api/Generics/5
        [ResponseType(typeof(Generic))]
        public IHttpActionResult DeleteGeneric(int id)
        {
            Generic generic = db.Generics.Find(id);
            if (generic == null)
            {
                return NotFound();
            }

            db.Generics.Remove(generic);
            db.SaveChanges();

            return Ok(generic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GenericExists(int id)
        {
            return db.Generics.Count(e => e.ID == id) > 0;
        }
    }
}