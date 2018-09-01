using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Sibers.BLL.DTO;
using Sibers.BLL.Interfaces;
using Sibers.DAL.EF;
using Sibers.WEB.Models;

namespace Sibers.WEB.Controllers
{
    public class ProjectsController : Controller
    {
        public IProjectDtoService projectDtoService;

        public ProjectsController(
                                 IProjectDtoService projectDto)
        {
            projectDtoService = projectDto;
        }
        // GET: Projects
        public ActionResult Index()
        {
            IEnumerable<ProjectDTO> projectDTOs = projectDtoService.GetAll();
            // Map DTO to ViewModel using Dtos data
            var projects = Mapper.Map<IEnumerable<ProjectDTO>, List<ProjectViewModel>>(projectDTOs);
            return View(projects);
        }

        // GET: Projects/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDTO projectDto = projectDtoService.Get(id);
            var project = Mapper.Map<ProjectDTO, ProjectViewModel>(projectDto);

            if (project == null)
            {
                return HttpNotFound();
            }

            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
            
            ViewBag.Employees = project.Employees.ToList();
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            IEnumerable<EmployeeDTO> employeeDTOs = projectDtoService.GetAllEmployees();
            // Map DTO to ViewModel using Dtos data
            var employees = Mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(employeeDTOs);
            ViewBag.Employees = employees.ToList();
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectViewModel projectViewModel, Guid[] selectedEmployees)
        {
            if (ModelState.IsValid)
            {
                ProjectDTO projectDto = Mapper.Map<ProjectViewModel, ProjectDTO>(projectViewModel);
                projectDto.PId = Guid.NewGuid();
                projectDtoService.AddProject(projectDto, selectedEmployees);
                return RedirectToAction("Index");
            }
            IEnumerable<EmployeeDTO> employeeDTOs = projectDtoService.GetAllEmployees();
            // Map DTO to ViewModel using Dtos data
            var employees = Mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(employeeDTOs);
            ViewBag.Employees = employees.ToList();
            return View(projectViewModel);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDTO projectDto = projectDtoService.Get(id);
            var project = Mapper.Map<ProjectDTO, ProjectViewModel>(projectDto);

            if (project == null)
            {
                return HttpNotFound();
            }
            IEnumerable<EmployeeDTO> employeeDTOs = projectDtoService.GetSelectedEmployees(projectDto);
            // Map DTO to ViewModel using Dtos data
            var employees = Mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(employeeDTOs);
            ViewBag.Employees = employees.ToList();
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectViewModel projectViewModel, Guid[] selectedEmployees)
        {
            if (ModelState.IsValid)
            {
                ProjectDTO projectDto = Mapper.Map<ProjectViewModel, ProjectDTO>(projectViewModel);
                projectDtoService.UpdateProject(projectDto, selectedEmployees);
                return RedirectToAction("Index");
            }
            return View(projectViewModel);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDTO projectDto = projectDtoService.Get(id);
            var projectViewModel = Mapper.Map<ProjectDTO, ProjectViewModel>(projectDto);
            if (projectViewModel == null)
            {
                return HttpNotFound();
            }
            return View(projectViewModel);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ProjectDTO projectDto = projectDtoService.Get(id);
            projectDtoService.DeleteProject(projectDto);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    projectDtoService.Dispose();
                }
                catch { }
            }
            base.Dispose(disposing);
        }
    }
}
