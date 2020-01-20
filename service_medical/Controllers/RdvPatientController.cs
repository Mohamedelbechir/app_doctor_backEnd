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
    public class RdvPatientController : ApiController
    {
        private medicalEntities db = new medicalEntities();

        // GET: api/RdvPatient
        public IQueryable<rdv> GetrdvPatient()
        {
            return db.rdv;
        }
      

        // GET: api/RdvPatient/5
        [ResponseType(typeof(rdv))]
        public IHttpActionResult GetrdvPatient(string id)
        {
            rdv rdvPatient = db.rdv.Find(id);
            if (rdvPatient == null)
            {
                return NotFound();
            }

            return Ok(rdvPatient);
        }

        // PUT: api/RdvPatient/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutrdvPatient(decimal id, rdv rdv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rdv.id)
            {
                return BadRequest();
            }

            db.Entry(rdv).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rdvPatientExists(id))
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

        // POST: api/RdvPatient
        [ResponseType(typeof(rdv))]
        public IHttpActionResult PostrdvPatient(rdv rdv)
        {
           /* if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            db.rdv.Add(rdv);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (rdvPatientExists(rdv.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rdv.id }, rdv);
        }

        // DELETE: api/RdvPatient/5
        [ResponseType(typeof(rdv))]
        public IHttpActionResult DeleterdvPatient(string id)
        {
            rdv rdv = db.rdv.Find(id);
            if (rdv == null)
            {
                return NotFound();
            }

            db.rdv.Remove(rdv);
            db.SaveChanges();

            return Ok(rdv);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool rdvPatientExists(decimal id)
        {
            return db.rdv.Count(e => e.id == id) > 0;
        }
    }
}