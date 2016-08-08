using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services.Contracts
{
    interface IEmployeeService
    {
        IEnumerable<Employee> GetPage(int pageNum, int pageSize);
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
        void Save(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
