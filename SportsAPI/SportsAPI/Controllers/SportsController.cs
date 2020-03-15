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
    public class SportsController : ApiController
    {
        private SportSafeEntities db = new SportSafeEntities();

        // GET: api/Sports
        public IQueryable<Sport> GetSports()
        {
            return db.Sports;
        }

        // GET: api/Sports/5
        [ResponseType(typeof(Sport))]
        public IHttpActionResult GetSport(int id)
        {
            Sport sport = db.Sports.Find(id);
            if (sport == null)
            {
                return NotFound();
            }

            return Ok(sport);
        }

        // PUT: api/Sports/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSport(int id, Sport sport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sport.SportID)
            {
                return BadRequest();
            }

            db.Entry(sport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportExists(id))
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

        // POST: api/Sports
        [ResponseType(typeof(Sport))]
        public IHttpActionResult PostSport(Sport sport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sports.Add(sport);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sport.SportID }, sport);
        }

        // DELETE: api/Sports/5
        [ResponseType(typeof(Sport))]
        public IHttpActionResult DeleteSport(int id)
        {
            Sport sport = db.Sports.Find(id);
            if (sport == null)
            {
                return NotFound();
            }

            db.Sports.Remove(sport);
            db.SaveChanges();

            return Ok(sport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SportExists(int id)
        {
            return db.Sports.Count(e => e.SportID == id) > 0;
        }
    }
}