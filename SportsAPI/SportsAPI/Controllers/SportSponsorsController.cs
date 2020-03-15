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
    public class SportSponsorsController : ApiController
    {
        private SportSafeEntities db = new SportSafeEntities();

        // GET: api/SportSponsors
        public IQueryable<SportSponsor> GetSportSponsors()
        {
            return db.SportSponsors;
        }

        // GET: api/SportSponsors/5
        [ResponseType(typeof(SportSponsor))]
        public IHttpActionResult GetSportSponsor(int id)
        {
            SportSponsor sportSponsor = db.SportSponsors.Find(id);
            if (sportSponsor == null)
            {
                return NotFound();
            }

            return Ok(sportSponsor);
        }

        // PUT: api/SportSponsors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSportSponsor(int id, SportSponsor sportSponsor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sportSponsor.SportSponsorID)
            {
                return BadRequest();
            }

            db.Entry(sportSponsor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportSponsorExists(id))
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

        // POST: api/SportSponsors
        [ResponseType(typeof(SportSponsor))]
        public IHttpActionResult PostSportSponsor(SportSponsor sportSponsor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SportSponsors.Add(sportSponsor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sportSponsor.SportSponsorID }, sportSponsor);
        }

        // DELETE: api/SportSponsors/5
        [ResponseType(typeof(SportSponsor))]
        public IHttpActionResult DeleteSportSponsor(int id)
        {
            SportSponsor sportSponsor = db.SportSponsors.Find(id);
            if (sportSponsor == null)
            {
                return NotFound();
            }

            db.SportSponsors.Remove(sportSponsor);
            db.SaveChanges();

            return Ok(sportSponsor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SportSponsorExists(int id)
        {
            return db.SportSponsors.Count(e => e.SportSponsorID == id) > 0;
        }
    }
}