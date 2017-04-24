using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    public class RoleController : Controller
    {

        // GET: Role
        public ActionResult Index()
        {
            using(var context = new ApplicationDbContext())
            {
                
                return View(context.Roles.ToList());
            }
            
        }

        public ActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            using(var context = new ApplicationDbContext())
            {
                context.Roles.Add(role);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }

    }
}