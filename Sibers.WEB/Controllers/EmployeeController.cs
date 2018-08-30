using Sibers.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Sibers.BLL.DTO;
using AutoMapper;
using Sibers.WEB.Models;

namespace Sibers.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        public IEmployeeDtoService employeeDtoService;

        public EmployeeController(IEmployeeDtoService employeeDtoServ)
        {
            employeeDtoService = employeeDtoServ;
        }
    
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeDTO> employeeDTOs = employeeDtoService.GetAllEmployees();
            // Map DTO to ViewModel using Dtos data
            var employees = Mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(employeeDTOs);
            return View(employees);
        }
        // GET: Employee/Details/{Guid}
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDTO employeeDto = employeeDtoService.Get(id);
            var employee = Mapper.Map<EmployeeDTO, EmployeeViewModel>(employeeDto);

            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;

            IEnumerable<ProjectDTO> projectDTOs = employeeDtoService.GetSelectedProjects(employeeDto);
            // Map DTO to ViewModel using Dtos data
            var projects = Mapper.Map<IEnumerable<ProjectDTO>, List<ProjectViewModel>>(projectDTOs);
            ViewBag.Projects = employee.Projects;
            return View(employee);
        }
        
        // GET: Employee/Create
        public ActionResult Create()
        {
            //IEnumerable<ProjectDTO> projectDTOs = employeeDtoService.GetSelectedProjects(employeeDto);
            //// Map DTO to ViewModel using Dtos data
            //var projects = Mapper.Map<IEnumerable<ProjectDTO>, List<ProjectViewModel>>(projectDTOs);
            //ViewBag.Projects = projects;
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employeeViewModel, Guid[] selectedProjects)
        {
            if (ModelState.IsValid)
            {
                EmployeeDTO employeeDto = Mapper.Map<EmployeeViewModel, EmployeeDTO>(employeeViewModel);
                employeeDto.EId = Guid.NewGuid();
                employeeDtoService.AddEmployee(employeeDto, selectedProjects);
                return RedirectToAction("Index");
            }
            //IEnumerable<ProjectDTO> projectDTOs = employeeDtoService.GetSelectedProjects(employeeDto);
            //// Map DTO to ViewModel using Dtos data
            //var projects = Mapper.Map<IEnumerable<ProjectDTO>, List<ProjectViewModel>>(projectDTOs);
            //ViewBag.Projects = projects;
            return View(employeeViewModel);
        }

        // GET: Employee/Delete/{Guid}
        public ActionResult Delete(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDTO employeeDto = employeeDtoService.Get(Id);
            var employeeViewModel = Mapper.Map<EmployeeDTO, EmployeeViewModel>(employeeDto);
            if (employeeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeViewModel);
        }

        // POST: Employee/Delete/{Guid}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid Id)
        {
            EmployeeDTO employeeDto = employeeDtoService.Get(Id);
            employeeDtoService.DeleteEmployee(employeeDto);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    employeeDtoService.Dispose();
                }
                catch { }
            }
            base.Dispose(disposing);
        }
    }
}