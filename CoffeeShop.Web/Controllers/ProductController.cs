using CoffeeShop.EntityFramework;
using CoffeeShop.Model;
using CoffeeShop.Transport;
using System.Collections.Generic;
using System.Linq;
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
            var products = GetProductByOffice(id);
            return Json(new
            {
                data = products
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

        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            try
            {
                Product prodModel = new Product();
                prodModel.OfficeID = productModel.OfficeID;
                var model = AutoMapper.Mapper.Map<ProductModel, Product>(productModel);
                _unitOfWork.Products.Add(model);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
