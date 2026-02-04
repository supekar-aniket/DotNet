using _40_CRUD_using_ADO.NET.Models;
using _40_CRUD_using_ADO.NET.Utility;
using Microsoft.AspNetCore.Mvc;

namespace _40_CRUD_using_ADO.NET.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataAccessLayer data;

        public EmployeeController()
        {
            data = new DataAccessLayer();
        }

        public IActionResult Index()
        {
            List<Employee> employees = data.GetAllEmployees();

            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            try
            {
                data.AddEmployee(employee);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public IActionResult Edit(int id)
        {
            try
            {
                Employee employee =  data.GetEmployeeById(id);

                return View(employee);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            try
            {
                data.UpdateEmployee(employee);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                Employee employee = data.GetEmployeeById(id);

                return View(employee);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Employee employee = data.GetEmployeeById(id);

                return View(employee);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(Employee employee)
        {
            try
            {
                data.DeleteEmployee(employee.Id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }
}
