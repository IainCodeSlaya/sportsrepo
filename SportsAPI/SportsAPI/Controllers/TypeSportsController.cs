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
using SportsAPI.Models;

namespace SportsAPI.Controllers
{
    public class TypeSportsController : ApiController
    {
        private SportSafeEntities db = new SportSafeEntities();

        // GET: api/TypeSports
        public IQueryable<TypeSport> GetTypeSports()
        {
            return db.TypeSports;
        }

        // GET: api/TypeSports/5
        [ResponseType(typeof(TypeSport))]
        public IHttpActionResult GetTypeSport(int id)
        {
            TypeSport typeSport = db.TypeSports.Find(id);
            if (typeSport == null)
            {
                return NotFound();
            }

            return Ok(typeSport);
        }

        // PUT: api/TypeSports/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeSport(int id, TypeSport typeSport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeSport.TypeSportID)
            {
                return BadRequest();
            }

            db.Entry(typeSport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeSportExists(id))
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

        // POST: api/TypeSports
        [ResponseType(typeof(TypeSport))]
        public IHttpActionResult PostTypeSport(TypeSport typeSport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeSports.Add(typeSport);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeSport.TypeSportID }, typeSport);
        }

        // DELETE: api/TypeSports/5
        [ResponseType(typeof(TypeSport))]
        public IHttpActionResult DeleteTypeSport(int id)
        {
            TypeSport typeSport = db.TypeSports.Find(id);
            if (typeSport == null)
            {
                return NotFound();
            }

            db.TypeSports.Remove(typeSport);
            db.SaveChanges();

            return Ok(typeSport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeSportExists(int id)
        {
            return db.TypeSports.Count(e => e.TypeSportID == id) > 0;
        }
    }
}