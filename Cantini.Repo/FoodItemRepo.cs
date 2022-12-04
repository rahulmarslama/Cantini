using Cantini.Database;
using Cantini.Database.Model;

namespace Cantini.Repo
{
    public class FoodItemRepo
    {
        private readonly ApplicationDbContext _context;

        public FoodItemRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public FoodItemRepo()
        {

        }
        public List<FoodItem> GetFoodItem()
        {
            return _context.FoodItem.ToList();
        }

        public void Add(FoodItem model)
        {
            _context.FoodItem.Add(model);
            _context.SaveChanges();
        }

        public void Update(FoodItem model)
        {
            _context.FoodItem.Update(model);
            _context.SaveChanges();
        }
            public void Delete(FoodItem model)
        {
            _context.FoodItem.Remove(model);
            _context.SaveChanges();
        }

        public FoodItem GetById(int? id)
        {
            return _context.FoodItem.Find(id);

        }
    }
}