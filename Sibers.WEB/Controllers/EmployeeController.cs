using Sibers.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace Sibers.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        IUnitOfWork db;
        public EmployeeController(IUnitOfWork context) => this.db = context;
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Employees.GetAll().ToList());
        }
    }
}