using System;
using System.Linq;
using Project.Model;

using Microsoft.AspNetCore.Mvc;
using Project.Service;
using Project.VM;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService<Student> _service;

        public StudentController(IStudentService<Student> service)
        {
            _service = service;
        }

        /*
         * 
         */
         
        // 得到 记录 集合
        public IActionResult Index()
        {
            var list = _service.GetAll();

            var result = new StudentIndex
            {
                list = list.Select(item => new StudentVM
                {
                    Id = item.Id,
                    Name = $"{item.FirstName} {item.LastName}",
                    Age = DateTime.Now.Subtract(item.BirthDate).Days / 365
                })
            };
        
            return View(result);
        }

        // 得到 记录 细节
        public IActionResult Detail(int id)
        {
            var result = _service.GetById(id);

            if(result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(result);
        }
        
        //{
        // 得到 表单 填写，不是数据页面
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // post 写入并重定向，不是数据页面
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(StudentCreate student)
        {
            if (ModelState.IsValid)
            {
                var result = _service.Add(new Student()
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BirthDate = student.BirthDate,
                    Gender = student.Gender
                });

                return RedirectToAction(nameof(Detail), new { id = result });
            }

            return View();
        }
        //}

    }
}