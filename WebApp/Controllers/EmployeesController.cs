using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Services.Contracts;
using WebApp.Services.Implementation;

namespace WebApp.Controllers
{
    public class EmployeesController : ApiController
    {


        private IEmployeeService employeeService;

        EmployeesController()
        {
            this.employeeService = new EmployeeService();
        }

        // GET: api/Employees
        public IEnumerable<Employee> Get()
        {
            return this.employeeService.GetAll();
        }

        // GET: api/Employees 
        public IEnumerable<Employee> GetPage(int pageNum, int pageSize)
        {
            return this.employeeService.GetPage(pageNum, pageSize);
        }

        // GET: api/Employees/5
        public Employee Get(int id)
        {
            return this.employeeService.Get(id);
        }

        // POST: api/Employees
        public void Post(Employee employee)
        {
            employeeService.Save(employee);
        }

        // PUT: api/Employees/5
        public void Put(int id, Employee employee)
        {
            employeeService.Update(employee);
        }

        // DELETE: api/Employees/5
        public void Delete(int id)
        {
            employeeService.Delete(id);
        }


    }
}
