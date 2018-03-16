using CoffeeShop.EntityFramework;
using CoffeeShop.Model;
using CoffeeShop.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index()
        {
            var offices = _unitOfWork.Offices.GetAll().Select(o => AutoMapper.Mapper.Map<OfficeModel>(o)).ToList();
            return View(offices);
        }

        [HttpPost]
        public ActionResult Create(OfficeModel officeModel)
        {
            try
            {
                var model = AutoMapper.Mapper.Map<OfficeModel, Office>(officeModel);
                _unitOfWork.Offices.Add(model);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var office = AutoMapper.Mapper.Map<OfficeModel>(_unitOfWork.Offices.GetByOfficeId(id));
            return View(office);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ProductModel productModel = new ProductModel();
                ProductModel productModel2 = new ProductModel();
                ProductModel productModel3 = new ProductModel();

                var productNames = collection["products.ProductName"].ToString().Split(',');
                var units = collection["products.Unit"].ToString().Split(',');
                List<string> inputPN = new List<string>();
                List<string> inputU = new List<string>();
                foreach (var productName in productNames)
                {
                    inputPN.Add(productName);
                }
                foreach (var unit in units)
                {
                    inputU.Add(unit);
                }
                productModel.ProductName = inputPN[0];
                productModel.Unit = Convert.ToInt32(inputU[0]);
                UpdateOfficeProduct(productModel, id);

                productModel2.ProductName = inputPN[1];
                productModel2.Unit = Convert.ToInt32(inputU[1]);
                UpdateOfficeProduct(productModel2, id);

                productModel3.ProductName = inputPN[2];
                productModel3.Unit = Convert.ToInt32(inputU[2]);
                UpdateOfficeProduct(productModel3, id);

                OfficeModel officeModel = new OfficeModel();
                officeModel.OfficeID = id;
                officeModel.OfficeName = collection["OfficeName"].ToString();
                officeModel.PantryName = collection["PantryName"].ToString();
                var model = AutoMapper.Mapper.Map<OfficeModel, Office>(officeModel);

                _unitOfWork.Offices.Update(model);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }

        private void UpdateOfficeProduct(ProductModel productModel, int id)
        {
            var model = AutoMapper.Mapper.Map<ProductModel, Product>(productModel);
            model.OfficeID = id;
            var item = AutoMapper.Mapper.Map<ProductModel>(_unitOfWork.Products.GetDataByProductName(id, productModel.ProductName));
            if (item == null)
            {
                _unitOfWork.Products.Add(model);
            }
        }
    }
}
