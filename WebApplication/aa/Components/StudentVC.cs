using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Project.Service;
using Project.Model;

namespace Project.Components
{
    public class StudentVC: ViewComponent
    {
        private readonly IStudentService<Student> _service;

        public StudentVC(IStudentService<Student> service)
        {
            _service = service;
        }

        /*
         *
         */

        public IViewComponentResult Invoke()
        {
            var count = _service.GetAll().Count().ToString();

            return View("Default", count);
        }

    }
}
