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
    public class rdvPatientForCalController : ApiController
    {
        private medicalEntities db = new medicalEntities();
       
        // GET: api/rdvPatientForCal
        public List<getAllRdv_Result> GetrdvPatientForCal()
        {
            return db.getAllRdv().ToList();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }       
    }
}