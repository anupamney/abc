using Microsoft.AspNetCore.Mvc;

namespace mbaspnetcore6.Controllers
{
    public class DisplayController : Controller
    {
        private readonly IServiceRepository<Department, int> deptRepo;
        private readonly IServiceRepository<Employee, int> empRepo;

        public DisplayController(IServiceRepository<Employee, int> empRepo, IServiceRepository<Department, int> deptRepo)
        {
            this.empRepo = empRepo;
            this.deptRepo = deptRepo;
        }
        public IActionResult Index()
        {
            var data = new Displaydata
            {
                Employees = empRepo.GetRecords().Records.ToList(),
                Departments = deptRepo.GetRecords().Records.ToList()
            };
            return View(data);
        }
    }
}
