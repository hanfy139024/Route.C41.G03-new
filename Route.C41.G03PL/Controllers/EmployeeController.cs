using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Route.C41.G03.BLL.Interfaces;
using Route.C41.G03.BLL.Repositories;
using Route.C41.G03.Dal.Data;
using Route.C41.G03.Dal.Models;
using System;

namespace Route.C41.G03PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository  _employeeRepository;
        private readonly IWebHostEnvironment env;

        public EmployeeController(IEmployeeRepository employeeRepository ,IWebHostEnvironment env)
        {
          //  employeeRepository = employeeRepository;
            _employeeRepository = employeeRepository;
            this.env = env;
        }

        public IActionResult Index()
        {
            var Employees=_employeeRepository.GetAll();

            return View(Employees);
        }
        public IActionResult Crate() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(ModelState .IsValid)
            {
                var Count=_employeeRepository .Add(employee);
                if(Count > 0)
                {
                    return RedirectToAction (nameof(Index));
                }
                return View(Employee);

            }
        }
        public IActionResult Details(int? id, string viewName ="Details")
        {
            if (!id.HasValue)
            {
                return BadRequest();

            }
            var employee=_employeeRepository.Get(id.Value);
            if (employee is null )
            {
                return NotFound();
                return View(viewName, Employee);

            }
            
        }
        }



        [HttpGet]

        public IActionResult Eidt([FromRoute] int id, Employee Employee)
        {
            if (id != Employee.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
                return View(Employee);
            try
            {
                EmployeeRepo.Add(Employee);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {

                if (env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "An Error Has Ocurred During Updating The Department");
                return View(Employee);

            }
            public IActionResult Delete(int? id)
            {
                return Details(id, "Delete");
            }

            //[HttpPost]
            public IActionResult Delete(Employee employee)
            {
                try
                {
                    _employeeRepository.Delete(Employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (env.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        ModelState.AddModelError(string.Empty, "An Error Has Ocurred During Updating The Department");
                    return View(Employee);
                }

            }
        }
    }
}
