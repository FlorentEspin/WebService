﻿using System;
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
        [System.Web.Services.WebMethod()]
        [HttpGet]
        public EDITEUR GetEDITEUR(string name)
        {
            EDITEUR editor = new EDITEUR();

            var editors = GetEDITEURs();
            foreach (var i in editors)
            {
                if (i.NOM_EDITEUR == name) editor = i;

            }
            if (editor == null || editor.NOM_EDITEUR == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return editor;
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
            EDITEUR existing = GetEDITEUR(id);

            ((IObjectContextAdapter)db).ObjectContext.Detach(existing);

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

            if (editeur.ID_EDITEUR != -1)
            {
                if (GetEDITEUR(editeur.ID_EDITEUR) != null)
                {
                    var response = PutEDITEUR(editeur.ID_EDITEUR, editeur);
                    return response;
                }
            }

            if (ModelState.IsValid)
            {
                if (editeur.ID_EDITEUR == -1)
                {
                    int maxValue = 0;
                    foreach (var item in GetEDITEURs())
                    {
                        if (maxValue < item.ID_EDITEUR) maxValue = item.ID_EDITEUR;
                    }
                    editeur.ID_EDITEUR = (maxValue + 1);
                }

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