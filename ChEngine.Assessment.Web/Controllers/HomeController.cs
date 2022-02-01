using ChEngine.Assessment.Services.Contracts;
using ChEngine.Assessment.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChEngine.Assessment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAssessmentService _assessmentService;

        public HomeController(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }

        /// <summary>
        /// Home page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var result = await _assessmentService.DoBusinessLogic();
            var viewModel = new HomeViewModel(result);

            return View(viewModel);
        }
    }
}