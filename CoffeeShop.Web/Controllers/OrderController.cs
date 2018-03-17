using CoffeeShop.EntityFramework;
using CoffeeShop.Model;
using CoffeeShop.Transport;
using System;
using System.Linq;
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

        public ActionResult Index(int? SelectedOffice)
        {
            var products = _unitOfWork.Products.GetAll().Select(o => AutoMapper.Mapper.Map<ProductModel>(o)).ToList();
            var offices = _unitOfWork.Offices.GetAll().Select(o => AutoMapper.Mapper.Map<OfficeModel>(o)).ToList();

            var result = (from p in products
                          join o in offices on p.OfficeID equals o.OfficeID
                          select o).Distinct();

            ViewBag.SelectedOffice = new SelectList(result, "OfficeID", "OfficeName", SelectedOffice);
            return View();
        }

        public JsonResult GetOrders()
        {
            var id = Convert.ToInt32(TempData["Id"].ToString());
            var orders = _unitOfWork.OrderItems.GetOrderByOfficeId(id).Select(o=> AutoMapper.Mapper.Map<OrderItemModel>(o)).ToList();
            var results = from order in orders
                          where order.OfficeID == id
                          group order by order.OrderName
             into grp
                         select new
                         {
                             Name = grp.Key,
                             Count = grp.Select(x => x.OrderName).Count()
                         };

            return Json(new
            {
                data = results
            },
            JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderDrink(int? SelectedOffice, string clientName, string DoubleAmericano, string SweetLatte, string FlatWhite)
        {
            var id = SelectedOffice.GetValueOrDefault();

            if (ModelState.IsValid)
            {
                var type = DoubleAmericano ?? SweetLatte ?? FlatWhite;

                OrderItemModel model = new OrderItemModel();
                model.OrderName = type;
                model.ClientName = clientName;
                model.OfficeID = id;
                model.AddedDate = DateTime.Now;

                switch (type)
                {
                    case "Double Americano":
                        if (!OrderDoubleAmericano(model))
                            return RedirectToAction("Index", "Order", TempData["msg"] = "<script>alert('Insufficient Product');</script>");
                        break;
                    case "Sweet Latte":
                        if(!OrderSweetLatte(model))
                            return RedirectToAction("Index", "Order", TempData["msg"] = "<script>alert('Insufficient Product');</script>");                       
                        break;
                    case "Flat White":
                        if(!OrderFlatWhite(model))
                            return RedirectToAction("Index", "Order", TempData["msg"] = "<script>alert('Insufficient Product');</script>");
                        break;
                }
            }

            TempData["Id"] = id;
            var orderItems = _unitOfWork.OrderItems.GetOrderByOfficeId(id).Select(o => AutoMapper.Mapper.Map<OrderItemModel>(o)).ToList();
            return View(orderItems);
        }

        public bool OrderDoubleAmericano(OrderItemModel ordermodel)
        {
           return Order(ordermodel, 3, 0, 0);
        }

        private bool OrderFlatWhite(OrderItemModel ordermodel)
        {
            return Order(ordermodel, 2, 1, 4);
        }

        private bool OrderSweetLatte(OrderItemModel ordermodel)
        {
            return Order(ordermodel,2,5,3);
        }

        private bool Order(OrderItemModel ordermodel, int coffeeBeans, int sugar, int milk)
        {
            var result = true;
            var modelCF = AutoMapper.Mapper.Map<ProductModel>(_unitOfWork.Products.GetDataByProductName(ordermodel.OfficeID, "Coffee Beans"));
            var productCoffeeBeansCount = modelCF.Unit;
            var unitCF = _unitOfWork.Products.Get(modelCF.ProductID);
            unitCF.Unit = productCoffeeBeansCount - coffeeBeans;
            if (unitCF.Unit < 0)
            {
                return false;
            }
            _unitOfWork.Products.Update(unitCF);

            var modelSugar = AutoMapper.Mapper.Map<ProductModel>(_unitOfWork.Products.GetDataByProductName(ordermodel.OfficeID, "Sugar"));
            var productSugar = modelSugar.Unit;
            var unitSugar = _unitOfWork.Products.Get(modelSugar.ProductID);
            unitSugar.Unit = productSugar - sugar;
            if (unitSugar.Unit < 0)
            {
                return false;
            }
            _unitOfWork.Products.Update(unitSugar);

            var modelMilk = AutoMapper.Mapper.Map<ProductModel>(_unitOfWork.Products.GetDataByProductName(ordermodel.OfficeID, "Milk"));
            var productMilk = modelMilk.Unit;
            var unitMilk = _unitOfWork.Products.Get(modelMilk.ProductID);
            unitMilk.Unit = productMilk - milk;
            if (unitMilk.Unit < 0)
            {
                return false;
            }
            _unitOfWork.Products.Update(unitMilk);

            var ordermodels = AutoMapper.Mapper.Map<OrderItemModel, OrderItem>(ordermodel);
            _unitOfWork.OrderItems.Add(ordermodels);

            _unitOfWork.Complete();
            return result;
        }
    }
}
