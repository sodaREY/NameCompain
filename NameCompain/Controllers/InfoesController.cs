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
using NameCompain.Models;

namespace NameCompain.Controllers
{
    public class InfoesController : ApiController
    {
        private user23Entities db = new user23Entities();

        //[HttpGet]

        public IHttpActionResult Login(string login, string password)
        {
            return ();
        }

        // GET: api/Infoes
        public IQueryable<Info> GetInfo()
        {
            return db.Info;
        }

        // GET: api/Infoes/5
        [ResponseType(typeof(Info))]
        public IHttpActionResult GetInfo(int id)
        {
            Info info = db.Info.Find(id);
            if (info == null)
            {
                return NotFound();
            }

            return Ok(info);
        }

        // PUT: api/Infoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInfo(int id, Info info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != info.id)
            {
                return BadRequest();
            }

            db.Entry(info).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoExists(id))
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

        // POST: api/Infoes
        [ResponseType(typeof(Info))]
        public IHttpActionResult PostInfo(Info info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Info.Add(info);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = info.id }, info);
        }

        // DELETE: api/Infoes/5
        [ResponseType(typeof(Info))]
        public IHttpActionResult DeleteInfo(int id)
        {
            Info info = db.Info.Find(id);
            if (info == null)
            {
                return NotFound();
            }

            db.Info.Remove(info);
            db.SaveChanges();

            return Ok(info);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InfoExists(int id)
        {
            return db.Info.Count(e => e.id == id) > 0;
        }
    }
}