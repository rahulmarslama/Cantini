using Cantini.Database;
using Cantini.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Cantini.Repo
{
    public class StudentRepo
    {
        private readonly ApplicationDbContext _context;

        public StudentRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public StudentRepo()
        {

        }
        public List<Student> GetStudent()
        {
            return _context.Student.ToList();
        }
        public void Add(Student model)
        {
            _context.Student.Add(model);
            _context.SaveChanges();
        }


        

        public void Update(Student model)
        {
            _context.Student.Update(model);
            _context.SaveChanges();
        }
        public void Delete(Student model)
        {
            _context.Student.Remove(model);
            _context.SaveChanges();
        }

        public Student GetById(int? id)
        {
            return _context.Student.Find(id);

        }
    }
}