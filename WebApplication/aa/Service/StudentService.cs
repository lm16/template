using Project.Data;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Service
{
    public class StudentService: IStudentService<Student>
    {
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }
        /*
         * 
         */

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public Student Add(Student one)
        {
            _context.Students.Add(one);
            _context.SaveChanges();

            return one;
        }
    }
}
