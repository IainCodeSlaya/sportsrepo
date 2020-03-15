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
    public class SportSeasonsController : ApiController
    {
        private SportSafeEntities db = new SportSafeEntities();

        // GET: api/SportSeasons
        public IQueryable<SportSeason> GetSportSeasons()
        {
            return db.SportSeasons;
        }

        // GET: api/SportSeasons/5
        [ResponseType(typeof(SportSeason))]
        public IHttpActionResult GetSportSeason(int id)
        {
            SportSeason sportSeason = db.SportSeasons.Find(id);
            if (sportSeason == null)
            {
                return NotFound();
            }

            return Ok(sportSeason);
        }

        // PUT: api/SportSeasons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSportSeason(int id, SportSeason sportSeason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sportSeason.SportSeasonID)
            {
                return BadRequest();
            }

            db.Entry(sportSeason).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportSeasonExists(id))
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

        // POST: api/SportSeasons
        [ResponseType(typeof(SportSeason))]
        public IHttpActionResult PostSportSeason(SportSeason sportSeason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SportSeasons.Add(sportSeason);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sportSeason.SportSeasonID }, sportSeason);
        }

        // DELETE: api/SportSeasons/5
        [ResponseType(typeof(SportSeason))]
        public IHttpActionResult DeleteSportSeason(int id)
        {
            SportSeason sportSeason = db.SportSeasons.Find(id);
            if (sportSeason == null)
            {
                return NotFound();
            }

            db.SportSeasons.Remove(sportSeason);
            db.SaveChanges();

            return Ok(sportSeason);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SportSeasonExists(int id)
        {
            return db.SportSeasons.Count(e => e.SportSeasonID == id) > 0;
        }
    }
}