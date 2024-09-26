using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Models;
using Application.Service;
using DTOs.Department;
using Presentation.Filters;
using Microsoft.AspNetCore.OutputCaching;

namespace Presentation.Controllers
{

    public class DepartmentsController : Controller
    {
        //private readonly CompanyContext _context; 
        private readonly IDepartmentService _departmentservice; 
        private readonly IWebHostEnvironment _webHostEnvironment;


        public DepartmentsController(IDepartmentService departmentService, IWebHostEnvironment webHostEnvironment)
        {
            _departmentservice = departmentService; 
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Departments 
        //[AuthorizationFilter]
        // [ResponseCache(Duration = 3600000, Location = ResponseCacheLocation.Client, NoStore = false)] 
        
        public async Task<IActionResult> Index()
        {
            var data = await _departmentservice.GetAllAsync();
            return View(data);
        }

        // GET: Departments/Details/5
       // [ResponseCache(Duration = 3600000, Location = ResponseCacheLocation.Client, NoStore = false)]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                

        
            var _department = (await _departmentservice.GetAllAsync())
                .Where(d => d.Id == id)
                .FirstOrDefault();

            return View(_department);
        }
        //[ResponseCache(Duration = 120, Location = ResponseCacheLocation.Client, NoStore = false)]

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Name,ManagerName,Id,CreatedBy,Created,UpdatedBy,Updated,IsDeleted")] CreateDepartmentDTO department)
        {
            if (ModelState.IsValid)
            {
               var dept =await _departmentservice.CreateAsync(department);
        
                return  RedirectToAction("Index");
            }
            return View();
        }

        // GET: Departments/Edit/5
       // [ResponseCache(Duration = 1200, Location = ResponseCacheLocation.Client, NoStore = false)]

        public async Task<IActionResult> Edit(int? id)
        {
             if (id == null)
            {
                return NotFound();
            }

            //var department = await _context.Departments.FindAsync(id); 
            var department = (await _departmentservice.GetAllAsync()).FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ManagerName,Id,CreatedBy,Created,UpdatedBy,Updated,IsDeleted")] CreateDepartmentDTO department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _departmentservice.UpdateAsync(department);
                    //_context.Update(department);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!DepartmentExists(department.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var DeletedDepartment = (await _departmentservice.GetAllAsync())
                .Where(d => d.Id == id)
                .Select(d => new CreateDepartmentDTO() {Id=d.Id, Name = d.Name, ManagerName = d.ManagerName })
                .FirstOrDefault();
               

            var department = await _departmentservice.DeleteAsync(DeletedDepartment);
             
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        { 
   
            var department =(await _departmentservice.GetAllAsync()).Find(dept => dept.Id == id);
            if(department!=null)
            {
               
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DepartmentExists(int id)
        {
            return (await _departmentservice.GetAllAsync()).Any(e => e.Id == id);
        }
    }
}
