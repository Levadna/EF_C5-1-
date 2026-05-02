using EF_C5_1_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_C5_1_
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Создаем контекст базы данных
            using (var context = new MyShop())
            {
                // Создаем сервис магазина
                //var serviceShop = new ServiceShop(context);

                //// Добавляем клиентов
                //serviceShop.AddClient(new Client { Name = "Иван", Email = "ivan@example.com" });
                //serviceShop.AddClient(new Client { Name = "Мария", Email = "maria@example.com" });

                //// Добавляем продукты
                //serviceShop.AddProduct(new Product { Name = "Ноутбук", Price = 1000 });
                //serviceShop.AddProduct(new Product { Name = "Смартфон", Price = 500 });

                //// Получаем всех клиентов
                //var clients = serviceShop.GetAllClients().ToList();
                //Console.WriteLine("Список клиентов:");
                //foreach (var client in clients)
                //{
                //    Console.WriteLine($"ID: {client.Id}, Имя: {client.Name}, Email: {client.Email}");
                //}
                //Console.WriteLine();

                //// Получаем всех продуктов
                //var products = serviceShop.GetAllProducts().ToList();
                //Console.WriteLine("Список продуктов:");
                //foreach (var product in products)
                //{
                //    Console.WriteLine($"ID: {product.Id}, Название: {product.Name}, Цена: {product.Price}");
                //}
                //Console.WriteLine();

                //// Добавляем заказ
                //var order = new Order
                //{
                //    ClientId = clients.First().Id,
                //    Products = products
                //};
                //serviceShop.AddOrder(order);

                // Получаем все заказы с деталями
                //var orders = serviceShop.GetAllOrdersWithDetails().ToList();
                //Console.WriteLine("Список заказов с деталями:");
                //foreach (var ord in orders)
                //{
                //    Console.WriteLine($"ID заказа: {ord.Id}, Клиент: {ord.Client.Name}, Продукты:");
                //    foreach (var prod in ord.Products)
                //    {
                //        Console.WriteLine($"  - {prod.Name}, Цена: {prod.Price}");
                //    }
                //}
                //Console.WriteLine("Enter some key for exit:");

                //Створити клас EmployeeService
                //Додати методи CRUD, Details
                //Змінити назву таблиці Employees на EmployeeShop
                //Додати співробітників до таблиці EmployeeShop
                //протестувати їх методи через сервіс в методі main


                //    employeeService.AddEmployee(new Employee { Name = "Olena", Department = "HR", Salary = 15000 });

                //    Console.WriteLine("CREATE: Employees added\n");
                //Console.WriteLine("INITIAL EMPLOYEES LIST:");
                //var employees = employeeService.GetAllEmployees();
                //foreach (var e in employees)
                //{
                //    Console.WriteLine($"{e.Id} - {e.Name} - {e.Department} - {e.Salary}");
                //}
                //var ivan = employeeService.GetById(1);
                //if (ivan != null)
                //{
                //    ivan.Name = "Ivan_Updated";
                //    ivan.Salary = 30000;
                //    employeeService.Update(ivan);

                //    Console.WriteLine("\nUPDATE: Ivan updated");
                //}
                //Console.WriteLine("\nBEFORE DELETE:");
                //foreach (var e in employeeService.GetAllEmployees())
                //{
                //    Console.WriteLine($"{e.Id} - {e.Name}");
                //}
                //Console.WriteLine("\nAFTER UPDATE:");
                //foreach (var e in employeeService.GetAllEmployees())
                //{
                //    Console.WriteLine($"{e.Id} - {e.Name} - {e.Department} - {e.Salary}");
                //}
                //var olena = employeeService.GetAllEmployees().FirstOrDefault(e => e.Name == "Olena");
                //if (olena != null)
                //{
                //    employeeService.Delete(olena.Id);
                //    Console.WriteLine("\nDELETE: Olena removed");
                //}
                //Console.WriteLine("\nFINAL EMPLOYEES LIST:");
                //foreach (var e in employeeService.GetAllEmployees())
                //{
                //    Console.WriteLine($"{e.Id} - {e.Name} - {e.Department} - {e.Salary}");
                //}

                var employeeService = new EmployeeService(context);

                employeeService.AddEmployee(new Employee { Name = "Ivan", Department = "IT", Salary = 20000 });
                employeeService.AddEmployee(new Employee { Name = "Olena", Department = "HR", Salary = 15000 });
                employeeService.AddEmployee(new Employee { Name = "Petro", Department = "IT", Salary = 31000 });
                employeeService.AddEmployee(new Employee { Name = "Anna", Department = "Finance", Salary = 18000 });
                employeeService.AddEmployee(new Employee { Name = "John", Department = "IT", Salary = 27000 });
                Console.WriteLine("\nIT EMPLOYEES:");
                var itEmployees = employeeService.GetByDepartment("IT");
                foreach (var e in itEmployees)
                {
                    Console.WriteLine($"{e.Name} - {e.Salary}");
                }
                var top = employeeService.GetHighestSalaryEmployee();
                Console.WriteLine($"\nHIGHEST SALARY: {top?.Name} - {top?.Salary}");
                var avg = employeeService.GetAverageSalary();
                Console.WriteLine($"\nAVERAGE SALARY: {avg}");
                Console.WriteLine("\nSEARCH 'an':");
                var search = employeeService.SearchByName("an");
                foreach (var e in search)
                {
                    Console.WriteLine(e.Name);
                }
                Console.WriteLine("\nSORTED BY SALARY:");
                var sorted = employeeService.GetEmployeesSortedBySalary();
                foreach (var e in sorted)
                {
                    Console.WriteLine($"{e.Name} - {e.Salary}");
                }

                Console.ReadKey();
            }
        }
    }
}
