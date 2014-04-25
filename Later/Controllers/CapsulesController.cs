using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Later.Models;

namespace Later.Controllers
{
    public class CapsulesController : ApiController
    {
        private LaterContext db = new LaterContext();

        // GET api/Equipments
		public IEnumerable<Capsule> GetEquipments()
        {
			return db.Capsules.AsEnumerable();
        }

        // GET api/Equipments/5
		public Capsule GetEquipment(int id)
        {
			var equipment = db.Capsules.Find(id);
            if (equipment == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return equipment;
        }

        // POST api/Equipments
		public HttpResponseMessage PostEquipment(Capsule equipment)
        {
            if (ModelState.IsValid)
            {
				db.Capsules.Add(equipment);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, equipment);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = equipment.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}