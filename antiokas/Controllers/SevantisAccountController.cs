using antiokas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace antiokas.Controllers
{
    public class SevantisAccountController : Controller
    {
        // GET: SevantisAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: SevantisAccount/Details/
        public ActionResult Details()
        {
            var sevantisAccount = new SevantisAccount { AccountNumber = "000012345", Credit = 0.0123M, FirstName = "Jon", LastName = "Mackerel" };
            return View(sevantisAccount);
        }

        // GET: SevantisAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SevantisAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SevantisAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SevantisAccount/Edit/5
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

        // GET: SevantisAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SevantisAccount/Delete/5
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
