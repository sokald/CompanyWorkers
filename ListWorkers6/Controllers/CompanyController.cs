﻿using ListWorkers6.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace ListWorkers6.Controllers
{
    public class CompanyController : ApiController
    {
        // show all company
        [BasicAuthentication]
        public IHttpActionResult GetAllCompany()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            if (username == "a")
            {
                IList<CompanyViewModel> company = null;

                using (var ctx = new ListWorkersEntities())
                {
                    company = ctx.Companies.Include("Company")
                        .Select(s => new CompanyViewModel()
                        {
                            IdCompany = s.IdCompany,
                            NameComapny = s.NameComapny,
                            DateCreation = s.DateCreation
                        }).ToList<CompanyViewModel>();
                }

                if (company.Count == 0)
                {
                    return NotFound();
                }

                return Ok(company);
            }
            else {
                return NotFound();
            }
        }

        // serach company
        [HttpGet]
        public IHttpActionResult SearchCompany(string searchCompany)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (searchCompany == null)
                return BadRequest("Not a valid model");

            IList<CompanyViewModel> company = new List<CompanyViewModel>();

            using (var ctx = new ListWorkersEntities())
            {
                company = ctx.Companies.Include("Company")
                    .Select(s => new CompanyViewModel()
                    {
                        IdCompany = s.IdCompany,
                        NameComapny = s.NameComapny,
                        DateCreation = s.DateCreation
                    }).ToList<CompanyViewModel>();
            }

            var result = company.Where(i => i.NameComapny.Contains(searchCompany)).ToList();

            if (result == null)
            {
                return BadRequest("Not a valid model");
            }

            return Ok(result);
        }

        //inset now company
        [BasicAuthentication]
        public IHttpActionResult PostNewcompany(CompanyViewModel company)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            if (username == "a")
            {
                    if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                using (var ctx = new ListWorkersEntities())
                {
                    ctx.Companies.Add(new Company()
                    {
                        NameComapny = company.NameComapny,
                        DateCreation = company.DateCreation
                    });

                    ctx.SaveChanges();
                }

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // update company
        [BasicAuthentication]
        public IHttpActionResult PutCompany(CompanyViewModel company)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            if (username == "a")
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");

                using (var ctx = new ListWorkersEntities())
                {
                    var existingCompany = ctx.Companies.Where(s => s.IdCompany == company.IdCompany)
                                                            .FirstOrDefault<Company>();

                    if (existingCompany != null)
                    {
                        existingCompany.NameComapny = company.NameComapny;
                        existingCompany.DateCreation = company.DateCreation;

                        ctx.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }
                }

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult DeleteCompany(int id)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            if (username == "a")
            {
                if (id <= 0)
                    return BadRequest("Not a valid student id");

                using (var ctx = new ListWorkersEntities())
                {
                    var company = ctx.Companies
                        .Where(s => s.IdCompany == id)
                        .FirstOrDefault();

                    ctx.Entry(company).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();
                }

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
