using HealthInsuranceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthInsuranceManagementSystem.Controllers
{
    public class InsuranceCompanyController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Index(string search = "", string SortColumn = "CompanyId",
            string IconClass = "fa-solid fa-sort-down")
        {
            List<InsuranceCompany> insuranceCompanies = dbContext.InsuranceCompanies
                .Where(company => company.CompanyName.Contains(search)).ToList();
            ViewBag.Search = search;
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            switch (SortColumn)
            {
                case "CompanyId":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            insuranceCompanies = insuranceCompanies.OrderBy(company =>
                        company.CompanyId).ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            insuranceCompanies = insuranceCompanies.OrderByDescending(company =>
                        company.CompanyId).ToList();
                            break;
                    }
                    break;
                case "CompanyName":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            insuranceCompanies = insuranceCompanies.OrderBy(company =>
                        company.CompanyName).ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            insuranceCompanies = insuranceCompanies.OrderByDescending(company =>
                        company.CompanyName).ToList();
                            break;
                    }
                    break;
                case "Address":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            insuranceCompanies = insuranceCompanies.OrderBy(company =>
                        company.Address).ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            insuranceCompanies = insuranceCompanies.OrderByDescending(company =>
                        company.Address).ToList();
                            break;
                    }
                    break;
                case "CompanyWebsite":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            insuranceCompanies = insuranceCompanies.OrderBy(company =>
                        company.CompanyWebsite).ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            insuranceCompanies = insuranceCompanies.OrderByDescending(company =>
                        company.CompanyWebsite).ToList();
                            break;
                    }
                    break;

            }

            return View(insuranceCompanies);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            InsuranceCompany insuranceCompany = dbContext
                .InsuranceCompanies.Where(company => company.CompanyId == id).FirstOrDefault();
            return View(insuranceCompany);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(InsuranceCompany insuranceCompany)
        {
            if (ModelState.IsValid)
            {
                dbContext.InsuranceCompanies.Add(insuranceCompany);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Add");
        }

        public ActionResult Update(int id)
        {
            InsuranceCompany insuranceCompany = dbContext.InsuranceCompanies
                .Where(company => company.CompanyId == id).FirstOrDefault();
            return View(insuranceCompany);
        }

        [HttpPost]
        public ActionResult Update(int id, InsuranceCompany insuranceCompany)
        {
            if (ModelState.IsValid)
            {
                InsuranceCompany insuranceCompanyUpdate = dbContext.InsuranceCompanies
                .Where(company => company.CompanyId == insuranceCompany.CompanyId).FirstOrDefault();
                insuranceCompanyUpdate.CompanyId = insuranceCompany.CompanyId;
                insuranceCompanyUpdate.CompanyName = insuranceCompany.CompanyName;
                insuranceCompanyUpdate.Address = insuranceCompany.Address;
                insuranceCompanyUpdate.Phone = insuranceCompany.Phone;
                insuranceCompanyUpdate.CompanyWebsite = insuranceCompany.CompanyWebsite;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Update");
        }

        public ActionResult Delete(int id)
        {
            InsuranceCompany insuranceCompany = dbContext.InsuranceCompanies
                .Where(company => company.CompanyId == id).FirstOrDefault();
            return View(insuranceCompany);
        }

        [HttpPost]
        public ActionResult Delete(int id, InsuranceCompany insuranceCompany)
        {
            InsuranceCompany insuranceCompanyDeleted = dbContext.InsuranceCompanies
                .Where(company => company.CompanyId == id).FirstOrDefault();
            dbContext.InsuranceCompanies.Remove(insuranceCompanyDeleted);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}