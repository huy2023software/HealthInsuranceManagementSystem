using HealthInsuranceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthInsuranceManagementSystem.Controllers
{
    public class PolicyController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Index(string search = "", string SortColumn = "PolicyId", 
            string IconClass="fa-solid fa-sort-down")
        {
            List<Policy> policies = dbContext.Policies.Where(policy => 
                policy.PolicyName.Contains(search)).ToList();

            ViewBag.Search = search;
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            switch (SortColumn)
            {
                case "PolicyId": 
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            policies = policies.OrderBy(policy => policy.PolicyId).ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            policies = policies.OrderByDescending(policy => policy.PolicyId).ToList();
                            break;
                    }
                    break;

                case "PolicyName":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            policies = policies.OrderBy(policy => policy.PolicyName).ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            policies = policies.OrderByDescending(policy => policy.PolicyName).ToList();
                            break;
                    }
                    break;

                case "Amount":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            policies = policies.OrderBy(policy => policy.Amount).ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            policies = policies.OrderByDescending(policy => policy.Amount).ToList();
                            break;
                    }
                    break;

                case "EMI":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            policies = policies.OrderBy(policy => policy.EMI).ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            policies = policies.OrderByDescending(policy => policy.EMI).ToList();
                            break;
                    }
                    break;

                case "CompanyId":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            policies = policies.OrderBy(policy => policy.CompanyId).ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            policies = policies.OrderByDescending(policy => policy.CompanyId).ToList();
                            break;
                    }
                    break;

                case "MedicalId":
                    switch (IconClass)
                    {
                        case "fa-solid fa-sort-down":
                            policies = policies.OrderBy(policy => policy.MedicalId).ToList();
                            break;
                        case "fa-solid fa-sort-up":
                            policies = policies.OrderByDescending(policy => policy.MedicalId).ToList();
                            break;
                    }
                    break;
            }

            return View(policies);
        }

        public ActionResult Details(int id)
        {
            Policy detailPolicy = dbContext.Policies.Where(policy => policy.PolicyId == id)
                .FirstOrDefault();
            return View(detailPolicy);
        }

        public ActionResult Add()
        {
            ViewBag.InsuranceCompanies = dbContext.InsuranceCompanies;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Policy policy)
        {
            ViewBag.InsuranceCompanies = dbContext.InsuranceCompanies;
            if (ModelState.IsValid)
            {
                dbContext.Policies.Add(policy);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Add");
        }

        public ActionResult Update(int id)
        {
            Policy updatedPolicy = dbContext.Policies.Where(policy => policy.PolicyId == id)
                .FirstOrDefault();
            ViewBag.InsuranceCompanies = dbContext.InsuranceCompanies.ToList();
            return View(updatedPolicy);
        }

        [HttpPost]
        public ActionResult Update(int id,  Policy newPolicy)
        {
            ViewBag.InsuranceCompanies = dbContext.InsuranceCompanies.ToList();
            if (ModelState.IsValid)
            {
                Policy updatedPolicy = dbContext.Policies
                .Where(policy => policy.PolicyId == newPolicy.PolicyId).FirstOrDefault();
                updatedPolicy.PolicyName = newPolicy.PolicyName;
                updatedPolicy.Description = newPolicy.Description;
                updatedPolicy.Amount = newPolicy.Amount;
                updatedPolicy.EMI = newPolicy.EMI;
                updatedPolicy.MedicalId = newPolicy.MedicalId;
                updatedPolicy.CompanyId = newPolicy.CompanyId;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public ActionResult Delete(int id) 
        {
            Policy deletedPolicy = dbContext.Policies.Where(policy => policy.PolicyId == id)
                .FirstOrDefault();
            return View(deletedPolicy);
        }

        [HttpPost]
        public ActionResult Delete(int id, Policy deletedPolicy)
        {
            Policy policy = dbContext.Policies.Where(pol => pol.PolicyId == id)
                .FirstOrDefault();
            dbContext.Policies.Remove(policy);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}