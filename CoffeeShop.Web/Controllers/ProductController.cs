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
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController()
        {
            _unitOfWork = new UnitOfWork(new CoffeeShopContext());
        }



        public ActionResult Index(int? SelectedOffice)
        {
            var products = GetProductByOffice(SelectedOffice);
            return View(products);
        }

        public JsonResult GetProduct(int id)
        {
            var product = GetProductByOffice(id);
            return Json(new
            {
                data = product
            },
            JsonRequestBehavior.AllowGet);
        }

        private List<ProductModel> GetProductByOffice(int? id)
        {
            var offices = _unitOfWork.Offices.GetAll().Select(o => AutoMapper.Mapper.Map<OfficeModel>(o)).ToList();
            ViewBag.SelectedOffice = new SelectList(offices, "OfficeID", "OfficeName", id);
            int officeId = id.GetValueOrDefault();
            var product = _unitOfWork.Products.GetDataByOfficeId(officeId).Select(o => AutoMapper.Mapper.Map<ProductModel>(o)).ToList();
            return product;
        }

        //private Product ConvertToEntity(ProductModel model)
        //{
        //    Product product = new Product();
        //    product.ProductID = model.ProductID;
        //    product.ProductName = model.ProductName;
        //    product.Unit = model.Unit;
        //    product.OfficeInfo.OfficeID = model.OfficeInfo_OfficeID;
        //    return product;
        //}
        //private ProductModel ConvertToModel(Product productTable)
        //{
        //    ProductModel productModel = new ProductModel();
        //    productModel.ProductID = productTable.ProductID;
        //    productModel.ProductName = productTable.ProductName;
        //    productModel.Unit = productTable.Unit;
        //    productModel.OfficeInfo_OfficeID = productTable.OfficeInfo.OfficeID;
        //    return productModel;
        //}

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
