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
    public class JeuxController : ApiController
    {
        private GameSearchContext db = new GameSearchContext();

        // GET api/Jeux
        public IEnumerable<JEU> GetJEUs()
        {
            var jeus = db.JEUs;//.Include(j => j.NORME);
            return jeus.AsEnumerable();
        }
        [System.Web.Services.WebMethod()]
        [HttpGet]
        public JEU GetUTILISATEURbyName(string name)
        {
            JEU jeu = new JEU();

            var users = GetJEUs();
            foreach (var i in users)
            {
                if (i.NOM_JEU == name) jeu = i;

            }
            if (jeu == null || jeu.NOM_JEU == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return jeu;
        }

        // GET api/Jeux/5
        public JEU GetJEU(int id)
        {
            JEU jeu = db.JEUs.Find(id);
            if (jeu == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return jeu;
        }

        // PUT api/Jeux/5
        public HttpResponseMessage PutJEU(int id, JEU jeu)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != jeu.ID_JEU)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(jeu).State = EntityState.Modified;

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

        // POST api/Jeux
        public HttpResponseMessage PostJEU(JEU jeu)
        {
            if (ModelState.IsValid)
            {
                db.JEUs.Add(jeu);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, jeu);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = jeu.ID_JEU }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Jeux/5
        public HttpResponseMessage DeleteJEU(int id)
        {
            JEU jeu = db.JEUs.Find(id);
            if (jeu == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.JEUs.Remove(jeu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, jeu);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}