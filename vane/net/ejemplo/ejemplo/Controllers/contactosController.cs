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
using ejemplo;

namespace ejemplo.Controllers
{
    public class contactosController : ApiController
    {
        private prueba db= new prueba();

        // GET: api/contactos
        public IQueryable<contacto> Getcontacto()
        {
            return db.contacto;
        }

        // GET: api/contactos/5
        [ResponseType(typeof(contacto))]
        public IHttpActionResult Getcontacto(int id)
        {
            contacto contacto = db.contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return Ok(contacto);
        }

        // PUT: api/contactos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcontacto(int id, contacto contacto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contacto.id)
            {
                return BadRequest();
            }

            db.Entry(contacto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!contactoExists(id))
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

        // POST: api/contactos
        [ResponseType(typeof(contacto))]
        public IHttpActionResult Postcontacto(contacto contacto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.contacto.Add(contacto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contacto.id }, contacto);
        }

        // DELETE: api/contactos/5
        [ResponseType(typeof(contacto))]
        public IHttpActionResult Deletecontacto(int id)
        {
            contacto contacto = db.contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            db.contacto.Remove(contacto);
            db.SaveChanges();

            return Ok(contacto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool contactoExists(int id)
        {
            return db.contacto.Count(e => e.id == id) > 0;
        }
    }
}