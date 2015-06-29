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
    public class NormesController : ApiController
    {
        private GameSearchContext db = new GameSearchContext();

        // GET api/Normes
        public IEnumerable<NORME> GetNORMEs()
        {
            return db.NORMEs.AsEnumerable();
        }

        // GET api/Normes/5
        public NORME GetNORME(int id)
        {
            NORME norme = db.NORMEs.Find(id);
            if (norme == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return norme;
        }

        // PUT api/Normes/5
        public HttpResponseMessage PutNORME(int id, NORME norme)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != norme.ID_NORME)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(norme).State = EntityState.Modified;

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

        // POST api/Normes
        public HttpResponseMessage PostNORME(NORME norme)
        {
            if (ModelState.IsValid)
            {
                db.NORMEs.Add(norme);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, norme);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = norme.ID_NORME }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Normes/5
        public HttpResponseMessage DeleteNORME(int id)
        {
            NORME norme = db.NORMEs.Find(id);
            if (norme == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.NORMEs.Remove(norme);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, norme);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}