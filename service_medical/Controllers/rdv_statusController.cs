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
    public class rdv_statusController : ApiController
    {
        private medicalEntities db = new medicalEntities();

        // GET: api/rdv_status
        public IQueryable<rdv_status> Getrdv_status()
        {
            return db.rdv_status;
        }

        // GET: api/rdv_status/5
        [ResponseType(typeof(rdv_status))]
        public IHttpActionResult Getrdv_status(int id)
        {
            rdv_status rdv_status = db.rdv_status.Find(id);
            if (rdv_status == null)
            {
                return NotFound();
            }

            return Ok(rdv_status);
        }

        // PUT: api/rdv_status/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putrdv_status(int id, rdv_status rdv_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rdv_status.id)
            {
                return BadRequest();
            }

            db.Entry(rdv_status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rdv_statusExists(id))
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

        // POST: api/rdv_status
        [ResponseType(typeof(rdv_status))]
        public IHttpActionResult Postrdv_status(rdv_status rdv_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.rdv_status.Add(rdv_status);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rdv_status.id }, rdv_status);
        }

        // DELETE: api/rdv_status/5
        [ResponseType(typeof(rdv_status))]
        public IHttpActionResult Deleterdv_status(int id)
        {
            rdv_status rdv_status = db.rdv_status.Find(id);
            if (rdv_status == null)
            {
                return NotFound();
            }

            db.rdv_status.Remove(rdv_status);
            db.SaveChanges();

            return Ok(rdv_status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool rdv_statusExists(int id)
        {
            return db.rdv_status.Count(e => e.id == id) > 0;
        }
    }
}