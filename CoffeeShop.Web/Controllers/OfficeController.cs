using CoffeeShop.EntityFramework;
using CoffeeShop.EntityFramework.Repositories;
using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.Web.Controllers
{
    public class OfficeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OfficeController()
        {
            _unitOfWork = new UnitOfWork(new CoffeeShopContext());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var offices = _unitOfWork.Offices.GetAll().Select(o => AutoMapper.Mapper.Map<OfficeModel>(o)).ToList();
            return View(offices);
        }

        // GET: Office/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Office/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Office/Create
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

        // GET: Office/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Office/Edit/5
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

        // GET: Office/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Office/Delete/5
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
