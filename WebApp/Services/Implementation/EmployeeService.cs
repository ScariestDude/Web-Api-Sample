using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;
using WebApp.Repositories.Contracts;
using WebApp.Repositories.Implementation;
using WebApp.Services.Contracts;

namespace WebApp.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository employeeRepository;

        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
        }
        public void Delete(int id)
        {
            employeeRepository.Delete(id);
        }

        public Employee Get(int id)
        {
            return employeeRepository.Get(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        public IEnumerable<Employee> GetPage(int pageNum, int pageSize)
        {
            int skip = (pageNum - 1) * pageSize;

            var page = employeeRepository.GetAll().Skip(skip).Take(pageSize);

            return page.ToList();
        }

        public void Save(Employee employee)
        {
            employeeRepository.Save(employee);
        }

        public void Update(Employee employee)
        {
            employeeRepository.Update(employee);
        }
    }
}