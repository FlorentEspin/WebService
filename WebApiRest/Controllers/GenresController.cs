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
using WebApiRest.Models;

namespace WebApiRest.Controllers
{
    public class GenresController : ApiController
    {
        private GameSearchContext db = new GameSearchContext();

        // GET api/Genres
        public IEnumerable<GENRE> GetGENREs()
        {
            return db.GENREs.AsEnumerable();
        }

        // GET api/Genres/5
        public GENRE GetGENRE(int id)
        {
            GENRE genre = db.GENREs.Find(id);
            if (genre == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return genre;
        }

        // PUT api/Genres/5
        public HttpResponseMessage PutGENRE(int id, GENRE genre)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != genre.ID_GENRE)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(genre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Genres
        public HttpResponseMessage PostGENRE(GENRE genre)
        {
            if (ModelState.IsValid)
            {
                db.GENREs.Add(genre);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, genre);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = genre.ID_GENRE }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Genres/5
        public HttpResponseMessage DeleteGENRE(int id)
        {
            GENRE genre = db.GENREs.Find(id);
            if (genre == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.GENREs.Remove(genre);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, genre);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}