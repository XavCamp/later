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
using System.Web.Mvc;

namespace Later.Controllers
{
    public class CapsulesController : ApiController
    {
        // GET api/Equipments/5
		public Capsule GetCapsule(int id)
        {
			using (var db = new LaterContext())
			{
				var capsule = db.Capsules.Find(id);
				if (capsule == null)
				{
					throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
				}

				return capsule;
			}
        }

        // POST api/Equipments
		public HttpResponseMessage PostCapsule(Capsule capsule)
		{
			if (ModelState.IsValid)
			{
				using (var db = new LaterContext())
				{
					db.Capsules.Add(capsule);
					db.SaveChanges();
				}

				var response = Request.CreateResponse(HttpStatusCode.Created, capsule);
				response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = capsule.ID, controller= "capsules" }));
				return response;
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}
		}
    }
}