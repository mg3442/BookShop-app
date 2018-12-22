﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookShop.Models;
using BookShop.DTOs;

namespace BookShop.Controllers
{
    public class BooksController : ApiController
    {
        private BookShopContext db = new BookShopContext();

        // GET: api/Books
        public IQueryable<BookDTO> GetBooks()
        {
            var books = from b in db.Books
                        .Include(b => b.Author)
                        select new BookDTO()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Genre = b.Genre,
                            Year = b.Year,
                            Price = b.Price,
                            AuthorName = b.Author.Name,
                            AuthorId = b.AuthorId
                        };
            return books;

            

        }

        // GET: api/Books/5
        [ResponseType(typeof(BookDTO))]
        public IHttpActionResult GetBook(int id)
        {
            var book = db.Books
                .Include(b => b.Author)
                        .Select (b => new BookDTO()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Genre = b.Genre,
                            Year = b.Year,
                            Price = b.Price,
                            AuthorName = b.Author.Name
                        }).SingleOrDefault(b => b.Id == id);
           
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}