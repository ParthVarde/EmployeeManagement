using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeesList;

        public MockEmployeeRepository()
        {
            _employeesList = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Parth", Email = "abc@gmail.com", Department = Dept.IT},
                new Employee { Id = 2, Name = "Dhaval", Email = "def@gmail.com", Department = Dept.HR},
                new Employee { Id = 3, Name = "Dharmik", Email = "ghi@gmail.com", Department = Dept.Marketing},
            };
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeesList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeesList.FirstOrDefault(x => x.Id == Id);
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeesList.Max(x => x.Id) + 1;
            _employeesList.Add(employee);
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeesList.FirstOrDefault(x => x.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employee.Department;
            }
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeesList.FirstOrDefault(x => x.Id == id);
            if(employee != null)
            {
                _employeesList.Remove(employee);
            }
            return employee;
        }
    }
}
