using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models.ViewModels;
using StudentPortal.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Views.Shared.Component {
    public class InfoCardViewComponent : ViewComponent {
        // Private database contexts are made for better security using the repository.
        private ISchoolDatabaseRepository _repository;

        public InfoCardViewComponent(ISchoolDatabaseRepository repository) {
            _repository = repository;
        }
        public IViewComponentResult Invoke() {
            //var viewData = new DatabaseVM();
            async Task<DatabaseVM> GenerateVM() {
                var viewData = new DatabaseVM();
                viewData.Students = await _repository.GetStudents();
                viewData.Professors = await _repository.GetProfessors();
                viewData.ScheduledClasses = await _repository.GetScheduledClasses();
                viewData.ProgressBars = await _repository.GetProgressBars();
                return viewData;
            }
            

            return View(GenerateVM());
        }
    }
}
