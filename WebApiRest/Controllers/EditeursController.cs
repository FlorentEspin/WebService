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
    public class EditeursController : ApiController
    {
        private GameSearchContext db = new GameSearchContext();

        // GET api/Editeurs
        public IEnumerable<EDITEUR> GetEDITEURs()
        {
            return db.EDITEURs.AsEnumerable();
        }

        // GET api/Editeurs/5
        public EDITEUR GetEDITEUR(int id)
        {
            EDITEUR editeur = db.EDITEURs.Find(id);
            if (editeur == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return editeur;
        }

        // PUT api/Editeurs/5
        public HttpResponseMessage PutEDITEUR(int id, EDITEUR editeur)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != editeur.ID_EDITEUR)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(editeur).State = EntityState.Modified;

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

        // POST api/Editeurs
        public HttpResponseMessage PostEDITEUR(EDITEUR editeur)
        {
            if (ModelState.IsValid)
            {
                db.EDITEURs.Add(editeur);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, editeur);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = editeur.ID_EDITEUR }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Editeurs/5
        public HttpResponseMessage DeleteEDITEUR(int id)
        {
            EDITEUR editeur = db.EDITEURs.Find(id);
            if (editeur == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.EDITEURs.Remove(editeur);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, editeur);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}