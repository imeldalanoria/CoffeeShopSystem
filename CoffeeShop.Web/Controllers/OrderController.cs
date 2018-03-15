using CoffeeShop.EntityFramework;
using CoffeeShop.Model;
using CoffeeShop.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController()
        {
            _unitOfWork = new UnitOfWork(new CoffeeShopContext());
        }

        public ActionResult Index(int? SelectedOffice, string type)
        {
            var offices = _unitOfWork.Offices.GetAll().Select(o => AutoMapper.Mapper.Map<OfficeModel>(o)).ToList();
            ViewBag.SelectedOffice = new SelectList(offices, "OfficeID", "OfficeName", SelectedOffice);
            if (ModelState.IsValid)
            {
                switch (type)
                {
                    case "DoubleAmericano":
                        DoubleAmericano(SelectedOffice);
                        break;
                    case "SweetLatte":
                        SweetLatte(SelectedOffice);
                        break;
                    case "FlatWhite":
                        FlatWhite(SelectedOffice);
                        break;
                }
            }
            return View();
        }

        public void DoubleAmericano(int? officeId)
        {
            //var offices = _unitOfWork.Offices.GetAll().Select(o => AutoMapper.Mapper.Map<OfficeModel>(o)).ToList();
            //ViewBag.SelectedOffice = new SelectList(offices, "OfficeID", "OfficeName", SelectedOffice);
            //int officeId = SelectedOffice.GetValueOrDefault();
            var model = AutoMapper.Mapper.Map<ProductModel>(_unitOfWork.Products.GetDataByProductName(officeId, "Coffee Beans"));
            var productCoffeeBeansCount = model.Unit;
            var unitId = _unitOfWork.Products.Get(model.ProductID);
            unitId.Unit = productCoffeeBeansCount - 3;
            _unitOfWork.Products.Update(unitId);
            _unitOfWork.Complete();
            //return RedirectToAction("Index", "Product", officeId);
        }

        public ActionResult OrderDoubleAmericano()
        {
            return View();
        }
        private void FlatWhite(int? selectedOffice)
        {
            throw new NotImplementedException();
        }

        private void SweetLatte(int? selectedOffice)
        {
            throw new NotImplementedException();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
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

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
