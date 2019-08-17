using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.WebApi.Pessoas.Controllers
{
    public class TestarApiController : Controller
    {
        // GET: TestarApi
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestarApi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestarApi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestarApi/Create
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

        // GET: TestarApi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestarApi/Edit/5
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

        // GET: TestarApi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestarApi/Delete/5
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
