using Cantini.Database;
using Cantini.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Cantini.Repo
{
    public class OrderRepo
    {
        private readonly ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public OrderRepo()
        {

        }
        public List<Order> GetOrder()
        {
            return _context.Order.Include(x => x.OrderDetail).ToList();
        }

        public void Add(Order model)
        {
            _context.Order.Add(model);
            _context.SaveChanges();
        }

        public void Update(Order model)
        {
            _context.Order.Update(model);
            _context.SaveChanges();
        }
            public void Delete(Order model)
        {
            _context.Order.Remove(model);
            _context.SaveChanges();
        }

        public Order GetById(int? id)
        {
            return _context.Order.Include(x=>x.OrderDetail).FirstOrDefault(x=>x.OId == id);

        }
    }
}