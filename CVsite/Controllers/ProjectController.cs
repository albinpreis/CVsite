using Data;
using Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVsite.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var projects = ctx.Projects.ToList();
                return View(projects);
            }
           
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(Project project)
        {
            var currentUser = User.Identity.GetUserId();
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var newProject = new Project()

                    {
                        Title = project.Title,
                        Description = project.Description,

                    };

                    var projectApplicationUser = new ProjectApplicationUser()
                    {
                        ApplicationUserId = currentUser,
                        ProjectId = newProject.Id,
                    };

                    
                    ctx.Projects.Add(newProject);
                    ctx.SaveChanges();
                    //ctx..Add(projectApplicationUser);
                    //ctx.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
