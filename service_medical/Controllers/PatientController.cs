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
    public class PatientController : ApiController
    {
        private medicalEntities db = new medicalEntities();

        // GET: api/Patient
        public IQueryable<patient> Getpatient()
        {
            return db.patient;
        }

        // GET: api/Patient/5
        [ResponseType(typeof(patient))]
        public IHttpActionResult Getpatient(double id)
        {
            patient patient = db.patient.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // PUT: api/Patient/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpatient(decimal id, patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.id)
            {
                return BadRequest();
            }

            db.Entry(patient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!patientExists(id))
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

        // POST: api/Patient
        [ResponseType(typeof(patient))]
        public IHttpActionResult Postpatient(patient patient)
        {
          /*  if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */
            db.patient.Add(patient);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (patientExists(patient.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = patient.id }, patient);
        }

        // DELETE: api/Patient/5
        [ResponseType(typeof(patient))]
        public IHttpActionResult Deletepatient(decimal id)
        {
            patient patient = db.patient.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            db.patient.Remove(patient);
            db.SaveChanges();

            return Ok(patient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool patientExists(decimal id)
        {
            return db.patient.Count(e => e.id == id) > 0;
        }
    }
}