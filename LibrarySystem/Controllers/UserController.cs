using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Models;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibrarySystem.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context;

        public UserController()
        {
            context = new ApplicationDbContext();
        }

        // GET: User
        public ActionResult Index()
        {
            var users = context.Users;            
            return View(users);
        }

        public ActionResult Edit(string Id)
        {
            var user = context.Users.Find(Id);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            ViewBag.Roles = roleManager.Roles;
            ViewBag.role = new SelectList(context.Roles.ToList(), "Name", "Name");
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(string Id, string Email, string PhoneNumber, string role)
        {
            var user = context.Users.Find(Id);
            user.Email = Email;
            user.PhoneNumber = PhoneNumber;
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            IdentityUserRole userrole = new IdentityUserRole();

            userrole.RoleId = roleManager.FindByName(role).Id;
            userrole.UserId = Id;

            user.Roles.Add(userrole);

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}