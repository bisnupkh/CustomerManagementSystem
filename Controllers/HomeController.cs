using HimlayanEverestInsurance.Models;
using Microsoft.AspNetCore.Mvc;

namespace HimlayanEverestInsurance.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository customers;

        public HomeController(ICustomerRepository _customers)
        {
            customers = _customers; 
        }
        public IActionResult Index()
        {
            
            return View(customers.GetAll());
        }

        [HttpGet]
        public IActionResult CreateUser()
        {

            return View();
        }


        [HttpPost]
        public IActionResult CreateUser(Customer model)
        {  if(ModelState.IsValid)
            {

                customers.Add(model);
                TempData["Message"] = "User Created Sucessfully";
                return RedirectToAction("Index");   

            }

            return View(model);
        }


        [HttpGet]
        public IActionResult EditUser(int Id)
        {
            Customer model = customers.Get(Id);
            if(model!=null)
            {
                return View(model);

            }

            TempData["Message"] = "Employee Not Found";
            return RedirectToAction("Index");

            
        }
        [HttpPost]

        public IActionResult EditUser(Customer ctr)
        {
            Customer model = customers.Get(ctr.Customer_Id);
            if (ModelState.IsValid)
            {

               
                if (model != null)
                {
                    customers.Update(ctr);
                    TempData["Message"] = "Record Update Sucessfully";
                    return RedirectToAction("Index");
                    

                }
                else
                {
                    TempData["Message"] = "Customer Not Found";
                    return RedirectToAction("Index");
                }
            }
            else
                return View(model);

           


        }


        [HttpGet]
        public IActionResult Details(int Id)
        {
            Customer model = customers.Get(Id);
            if (model != null)
            {
                return View(model);

            }

            TempData["Message"] = "Employee Not Found";
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult DeleteUser(int Id)
        {
            Customer model = customers.Get(Id);
            if (model != null)
            {
                return View(model);

            }

            TempData["Message"] = "Employee Not Found";
            return RedirectToAction("Index");


        }

        [HttpPost]
        public IActionResult DeleteUser(int Id,int? a)
        {
            customers.Delete(Id);
            TempData["Message"] = "Record Deleted Sucessfully";
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult SearchUser(string CustomerName)
        {
            if (CustomerName != null)
            {


                IEnumerable<Customer> model = customers.GetAll().Where(x => x.Customer_Name.ToLower() == CustomerName.ToLower()).ToList();
                if (model.Any())
                {

                    return View("Index", model);
                }
            }
            
                TempData["Message"] = $"NO Any User With THE Name {CustomerName}";
                   return RedirectToAction("Index");   

            
            


        }



    }
}
