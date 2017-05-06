using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Book
        public ActionResult Index(string SearchQuery)
        {
            using (var context = new LibraryDatabaseContainer())
            {
                var authors = context.Authors.Include("Books").ToList();
                if (string.IsNullOrEmpty(SearchQuery))
                {
                    var SearchResult = from author in authors where author.Name.Contains(SearchQuery) select author;
                    return View(authors);
                } else
                {
                    return View(authors);
                }
                
            }
        }

        public ActionResult Details(int id)
        {
            using (var context = new LibraryDatabaseContainer())
            {
                var author = context.Authors.Include("Books").ToList().Where(b => b.AuthorId == id).SingleOrDefault(); ;
                return (author != null) ? View(author) : View("Error");
            }

        }

        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            using (var context = new LibraryDatabaseContainer())
            {
                
                return View();
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Create(Author author, HttpPostedFileBase file)
        {
            using (var context = new LibraryDatabaseContainer())
            {
                if (ModelState.IsValid && FileHandler.isValidFile(file, new[] { "image/jpg", "image/jpeg", "image/png" }))
                {
                    author.Image = FileHandler.FileSave(file, "~/Images/Authors", this);
                    context.Authors.Add(author);
                    context.SaveChanges();
                    TempData["Created"] = author.AuthorId;
                    return RedirectToAction("Index");
                }
                return View(author);
            }

        }

        [Authorize(Roles = "Manager")]
        public ActionResult Edit(int id)
        {
            using (var context = new LibraryDatabaseContainer())
            {
                var author = context.Authors.Find(id);
                
                return (author != null)? View(author) : View("Error");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author author, HttpPostedFileBase file)
        {
            using (var context = new LibraryDatabaseContainer())
            {
                if (ModelState.IsValid && FileHandler.isValidFile(file, new[] { "image/jpg", "image/jpeg", "image/png" }))
                {
                    Author oldAuthor = context.Authors.Find(author.AuthorId);
                    oldAuthor.Image = FileHandler.FileSave(file, "~/Images/Authors", this);
                    oldAuthor.Name = author.Name;
                    oldAuthor.BirthDate = author.BirthDate;
                    oldAuthor.Specialty = author.Specialty;
                    oldAuthor.Description = author.Description;
                    context.SaveChanges();
                    TempData["Edited"] = author.AuthorId;
                    return RedirectToAction("Index");
                }
                return View(author);
            }
            
        }
    }
}