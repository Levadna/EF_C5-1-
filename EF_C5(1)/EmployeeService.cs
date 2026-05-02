using EF_C5_1_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_C5_1_
{
    public class EmployeeService
    {
        private readonly MyShop _context;

        public EmployeeService(MyShop context)
        {
            _context = context;
        }
        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }
        public void Update(Employee employee)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Department = employee.Department;
                emp.Salary = employee.Salary;

                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
        }
        public List<Employee> GetByDepartment(string department)
        {
            return _context.Employees
                .Where(e => e.Department == department)
                .ToList();
        }
        public Employee GetHighestSalaryEmployee()
        {
            return _context.Employees
                .OrderByDescending(e => e.Salary)
                .FirstOrDefault();
        }
        public decimal GetAverageSalary()
        {
            return _context.Employees.Any()
                ? _context.Employees.Average(e => e.Salary)
                : 0;
        }
        public List<Employee> SearchByName(string name)
        {
            return _context.Employees
                .Where(e => e.Name.Contains(name))
                .ToList();
        }
        public List<Employee> GetEmployeesSortedBySalary()
        {
            return _context.Employees
                .OrderByDescending(e => e.Salary)
                .ToList();
        }
    }
}
