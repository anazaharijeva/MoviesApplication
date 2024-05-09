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
using MoviesApplication.Models;

namespace MoviesApplication.Controllers
{
    public class ClientsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ClientsApi
        public IQueryable<Client> GetClients()
        {
            return db.Clients;
        }

        // GET: api/ClientsApi/5
        [ResponseType(typeof(ClientsDTO))]
        public IHttpActionResult GetClient(int id)
        {
            ClientsDTO client = db.Clients.Where(z => z.Id == id).Select(z => new ClientsDTO
            {
               Id=z.Id,
               Name=z.Name,
               Address=z.Address,
               Age=z.Age, 
               MovieCard=z.MovieCard,
               Telephone=z.Telephone, 
               IsSubscribed=z.IsSubscribed

            }).FirstOrDefault();
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/ClientsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.Id)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/ClientsApi
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.Id }, client);
        }

        // DELETE: api/ClientsApi/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.Id == id) > 0;
        }
    }
}