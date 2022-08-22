using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mbaspnetcore6.Controllers
{

    /// <summary>
    /// Inject the Repository using Constructor Injection
    /// </summary>
    public class DepartmentController : Controller
    {
        private readonly IServiceRepository<Department, int> deptRepo;

       

        /// <summary>
        /// Injection
        /// </summary>
        /// <param name="repo"></param>
        public DepartmentController(IServiceRepository<Department, int> repo)
        {
            deptRepo = repo;
        }
        /// <summary>
        /// Action Method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var response = deptRepo.GetRecords();
            return View(response.Records);
        }

        /// <summary>
        /// Method to Create a new Department
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            var dept = new Department();
            // return an EMpty View for Department 
            return View(dept);
        }

        /// <summary>
        /// The Post method that will be used mapp the Http Post Request
        /// to the Current Action Method and Read data from Http Request Message Body
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            try
            {
                var xx = deptRepo.GetRecords().Records;
                var isIdValid = DepartmentValidator.Validateid(xx, dept.DeptNo);
                if (!isIdValid)
                {
                    List<string>a=new List<string>();
                    a.Add("DeptNo already exists");
                    ViewBag.ErrorMessages = a;
                    return View(dept);
                }
                if (ModelState.IsValid)
                {

                    var response = deptRepo.CreateRecord(dept);
                    // If the Add is successful then Redirect to the 'Idnex' Action Method
                    return RedirectToAction("Index");
                }
                else
                {
                    // Stey on the Same Page
                    return View(dept);
                }
            }
            catch (Exception ex)
            {
                return View(dept);
            }
        }

        public IActionResult Edit(int id)
        {
            var respose = deptRepo.GetRecord(id);
            ViewBag.Message = "The Edit View";
            //ViewBag.ErrorMessages = new List<string>();
            // returna View with the data toi be edited
            return View(respose.Record);
        }

        [HttpPost]
        public IActionResult Edit(int id, Department dept)
        {
            try
            {
                var errorMessage = DepartmentValidator.ValidationMessages(dept);
                
                if (errorMessage.Count() > 0)
                {
                    // passing additional data to View
                    ViewBag.ErrorMessages = errorMessage;
                    return View(dept);
                }
                else
                {
                    var response = deptRepo.UpdateRecord(id, dept);
                    // If the Add is successful then Redirect to the 'Idnex' Action Method
                    return RedirectToAction("Index");
                }

                
            }
            catch (Exception ex)
            {
                return View(dept);
            }
        }

        public IActionResult Delete(int id)
        {
            var respose = deptRepo.DeleteRecord(id);
            // returna View with the data toi be edited
            return RedirectToAction("Index");
        }

        public IActionResult ShowEmployees(int id)
        {
            // Store the DeptNo in TempData
            TempData["DeptNo"] = id;
            // Navigate to an Index() action method of the Employee Controller
            return RedirectToAction("Index", "Employee");
        }
    }
}