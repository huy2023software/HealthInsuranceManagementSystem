using HealthInsuranceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthInsuranceManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        
        public ActionResult Index(
            string search = "", 
            string SortColumn = "EmpNo", 
            string IconClass = "fa-solid fa-sort-down")
        {
            List<Employee> employees = dbContext.Employees
                .Where(emp => emp.FirstName.Contains(search)).ToList();

            ViewBag.Search = search;
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            switch (SortColumn)
            {
                case "EmpNo":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            employees = employees.OrderBy(emp => emp.EmpNo)
                        .ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            employees = employees.OrderByDescending(emp => emp.EmpNo)
                        .ToList();
                            break;
                    }
                    break;
                case "Designation":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            employees = employees.OrderBy(emp => emp.Designation)
                        .ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            employees = employees.OrderByDescending(emp => emp.Designation)
                        .ToList();
                            break;
                    }
                    break;
                case "Salary":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            employees = employees.OrderBy(emp => emp.Salary)
                        .ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            employees = employees.OrderByDescending(emp => emp.Salary)
                        .ToList();
                            break;
                    }
                    break;
                case "JoinDate":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            employees = employees.OrderBy(emp => emp.JoinDate)
                        .ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            employees = employees.OrderByDescending(emp => emp.JoinDate)
                        .ToList();
                            break;
                    }
                    break;
                case "Address":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            employees = employees.OrderBy(emp => emp.Address)
                        .ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            employees = employees.OrderByDescending(emp => emp.Address)
                        .ToList();
                            break;
                    }
                    break;
                case "State":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            employees = employees.OrderBy(emp => emp.State)
                        .ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            employees = employees.OrderByDescending(emp => emp.State)
                        .ToList();
                            break;
                    }
                    break;
                case "Country":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            employees = employees.OrderBy(emp => emp.Country)
                        .ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            employees = employees.OrderByDescending(emp => emp.Country)
                        .ToList();
                            break;
                    }
                    break;
                case "City":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            employees = employees.OrderBy(emp => emp.City)
                        .ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            employees = employees.OrderByDescending(emp => emp.City)
                        .ToList();
                            break;
                    }
                    break;
                case "PolicyId":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            employees = employees.OrderBy(emp => emp.PolicyId)
                        .ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            employees = employees.OrderByDescending(emp => emp.PolicyId)
                        .ToList();
                            break;
                    }
                    break;
                case "PolicyStatus":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            employees = employees.OrderBy(emp => emp.PolicyStatus)
                        .ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            employees = employees.OrderByDescending(emp => emp.PolicyStatus)
                        .ToList();
                            break;
                    }
                    break;
            }
            return View(employees);
        }

        public ActionResult Details(int empNo)
        {
            Employee employee = dbContext.Employees
                .Where(emp => emp.EmpNo == empNo).FirstOrDefault();
            return View(employee);
        }

        public ActionResult Add()
        {
            ViewBag.Policies = dbContext.Policies.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            ViewBag.Policies = dbContext.Policies.ToList();
            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Add");
        }

        public ActionResult Update(int empNo)
        {
            Employee employee = dbContext.Employees.Where(emp => emp.EmpNo == empNo)
                .FirstOrDefault();
            ViewBag.Policies = dbContext.Policies.ToList();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Update(int empNo, Employee employee)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Policies = dbContext.Policies.ToList();
                Employee employeeUpdated = dbContext.Employees
                    .Where(emp => emp.EmpNo == employee.EmpNo)
                .FirstOrDefault();
                employeeUpdated.Designation = employee.Designation;
                employeeUpdated.JoinDate = employee.JoinDate;
                employeeUpdated.Salary = employee.Salary;
                employeeUpdated.FirstName = employee.FirstName;
                employeeUpdated.LastName = employee.LastName;
                employeeUpdated.Username = employee.Username;
                employeeUpdated.Password = employee.Password;
                employeeUpdated.Address = employee.Address;
                employeeUpdated.ContactNo = employee.ContactNo;
                employeeUpdated.State = employee.State;
                employeeUpdated.Country = employee.Country;
                employeeUpdated.City = employee.City;
                employeeUpdated.PolicyId = employee.PolicyId;
                employeeUpdated.PolicyStatus = employee.PolicyStatus;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Update");
        }

        public ActionResult Delete(int empNo)
        {
            Employee employee = dbContext.Employees.Where(emp => emp.EmpNo == empNo)
                .FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int empNo, Employee employee)
        {
            Employee employeeDeleted = dbContext.Employees.Where(emp => emp.EmpNo == empNo)
                .FirstOrDefault();
            dbContext.Employees.Remove(employeeDeleted);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}