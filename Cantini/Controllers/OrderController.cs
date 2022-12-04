using Cantini.Database.Model;
using Cantini.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Cantini.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderRepo _repo;


        public OrderController(OrderRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            List<Order> item = _repo.GetOrder();
            return View(item);

        }
        public IActionResult Details(int id)
        {
            Order item = _repo.GetById(id);
            return View(item);

        }

        public IActionResult Create()
        {
            Order order = new Order();
            order.OrderDetail = new List<OrderDetail>() ;
            order.OrderDetail.Add(new OrderDetail
            {
                Id = 1
            });


            return View(order);


            //Order customer = new Order();
            //customer.OrderDetail.Add(new OrderDetail() { 
            //    Id = 1,
            //    FId='1',
            //    Quantity=2,
            //    Rate=3,
            //});
            //return View(customer);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order obj)
        {
                _repo.Add(obj);
                return RedirectToAction("Index");
        }

    }
}

       

