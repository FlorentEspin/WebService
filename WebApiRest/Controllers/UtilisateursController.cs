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
    public class UtilisateursController : ApiController
    {
        private GameSearchContext db = new GameSearchContext();

        // GET api/Utilisateurs
        public IEnumerable<UTILISATEUR> GetUTILISATEURs()
        {
            return db.UTILISATEURs.AsEnumerable();
        }

        // GET api/Utilisateurs/5
        public UTILISATEUR GetUTILISATEUR(int id)
        {
            UTILISATEUR utilisateur = db.UTILISATEURs.Find(id);
            if (utilisateur == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return utilisateur;
        }
        [System.Web.Services.WebMethod()]
        [HttpGet]
        public UTILISATEUR GetUTILISATEURbyName(string name)
        {
            UTILISATEUR utilisateur = new UTILISATEUR();
  
            var users = GetUTILISATEURs();
            foreach (var i in users)
            {
                if (i.LOGIN == name) utilisateur = i;
                
            }
            if (utilisateur == null || utilisateur.LOGIN == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return utilisateur;
        }


        // PUT api/Utilisateurs/5
        public HttpResponseMessage PutUTILISATEUR(int id, UTILISATEUR utilisateur)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != utilisateur.ID_UTILISATEUR)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            UTILISATEUR existing = GetUTILISATEUR(id);

            ((IObjectContextAdapter)db).ObjectContext.Detach(existing);


            db.Entry(utilisateur).State = EntityState.Modified;

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

        // POST api/Utilisateurs
        public HttpResponseMessage PostUTILISATEUR(UTILISATEUR utilisateur)
        {
            if (GetUTILISATEUR(utilisateur.ID_UTILISATEUR) != null)
            {
              var response =  PutUTILISATEUR(utilisateur.ID_UTILISATEUR, utilisateur);
              return response;
            }
            else
            if (ModelState.IsValid)
            {
                db.UTILISATEURs.Add(utilisateur);
         
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, utilisateur);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = utilisateur.ID_UTILISATEUR }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Utilisateurs/5
        public HttpResponseMessage DeleteUTILISATEUR(int id)
        {
            UTILISATEUR utilisateur = db.UTILISATEURs.Find(id);
            if (utilisateur == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.UTILISATEURs.Remove(utilisateur);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, utilisateur);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}