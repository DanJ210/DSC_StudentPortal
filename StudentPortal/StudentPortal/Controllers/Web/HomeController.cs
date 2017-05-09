using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Models.ViewModels;
using StudentPortal.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortal.Controllers.Web {
    public class HomeController : Controller {
        //private SchoolDatabaseContext _context;
        private ISchoolDatabaseRepository _repository;

        public HomeController(ISchoolDatabaseRepository repository) {
            //_context = context;
            _repository = repository;
        }

        public async Task<IActionResult> Index() {
            var viewData = new DatabaseVM();

            viewData.Students = await _repository.GetStudents();
            viewData.Professors = await _repository.GetProfessors();
            viewData.ScheduledClasses = await _repository.GetScheduledClasses();
            viewData.ProgressBars = await _repository.GetProgressBars();

            ViewBag.Students = await _repository.GetStudents();
            ViewBag.Professors = await _repository.GetProfessors();
            ViewBag.ScheduledClasses = await _repository.GetScheduledClasses();
            ViewBag.ProgressBars = await _repository.GetProgressBars();

            return View();
        }
        
    }
}
