using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Models;

namespace CVsite.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserCreateModel model)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var user = new User()
                    {
                        UserName = model.UserName,
                        Password = model.Password,
                        Address = model.Address,
                        Email = model.Address,
                        PhoneNumber = model.Phone,
                        PrivateUser = model.PrivateUser
                    };

                    var filename = model.Image.FileName;
                    var filepath = Server.MapPath("~/UploadedImages");
                    model.Image.SaveAs(filepath + "/" + filename);

                    user.ImagePath = filename;

                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
