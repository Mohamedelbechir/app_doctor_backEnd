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
using model_medical;

namespace service_medical.Controllers
{
    public class type_rdvController : ApiController
    {
        private medicalEntities db = new medicalEntities();

        // GET: api/type_rdv
        public IQueryable<type_rdv> Gettype_rdv()
        {
            return db.type_rdv;
        }

        // GET: api/type_rdv/5
        [ResponseType(typeof(type_rdv))]
        public IHttpActionResult Gettype_rdv(int id)
        {
            type_rdv type_rdv = db.type_rdv.Find(id);
            if (type_rdv == null)
            {
                return NotFound();
            }

            return Ok(type_rdv);
        }

        // PUT: api/type_rdv/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttype_rdv(int id, type_rdv type_rdv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != type_rdv.id)
            {
                return BadRequest();
            }

            db.Entry(type_rdv).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!type_rdvExists(id))
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

        // POST: api/type_rdv
        [ResponseType(typeof(type_rdv))]
        public IHttpActionResult Posttype_rdv(type_rdv type_rdv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.type_rdv.Add(type_rdv);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = type_rdv.id }, type_rdv);
        }

        // DELETE: api/type_rdv/5
        [ResponseType(typeof(type_rdv))]
        public IHttpActionResult Deletetype_rdv(int id)
        {
            type_rdv type_rdv = db.type_rdv.Find(id);
            if (type_rdv == null)
            {
                return NotFound();
            }

            db.type_rdv.Remove(type_rdv);
            db.SaveChanges();

            return Ok(type_rdv);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool type_rdvExists(int id)
        {
            return db.type_rdv.Count(e => e.id == id) > 0;
        }
    }
}