using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SadeghiTest.Models;

namespace SadeghiTest.Controllers
{
    public class SadeghiController : Controller
    {
        private readonly SadeghiDbContext _context;

        public SadeghiController(SadeghiDbContext context)
        {
            _context = context;
        }

        public IndexViewModel LoadMyData()
        {
            var viewModel = new IndexViewModel();
            var dlTypeOptions = _context.DLTypes.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            var myModels = _context.MyModels.Take(200).ToList();
            viewModel.DLTypeOptions = dlTypeOptions;
            viewModel.MyModels = myModels;
            return viewModel;
        }
        [Route("/")]
        [Route("/Sadeghi")]
        [HttpGet]
        public IActionResult Index()
        {
            var indexModel =  LoadMyData();
            return View(new IndexViewModel { MyModels = indexModel.MyModels, DLTypeOptions = indexModel.DLTypeOptions });
        }

        [HttpPost]
        public IActionResult Index([FromBody] UpdateViewModel formData)
        {
            var entity = _context.MyModels.FirstOrDefault(e => e.Serial == formData.Serial);

            if (entity == null)
            {
                return NotFound();
            }
            entity.Title = formData.Title;
            entity.Active = formData.Active;
            entity.DLTyperef = formData.DLTyperef;
            entity.Dsr = formData.Dsr;

            _context.SaveChanges();
            //var indexModel = LoadMyData();

            return View();
        }


   }
}
