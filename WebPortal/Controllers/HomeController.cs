using BackendApp.Infrastructure.Irepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using WebPortal.Database;
using WebPortal.Models;

namespace WebPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;
        private DataCtxt _dataCtxt;




        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, DataCtxt dataCtxt)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _dataCtxt = dataCtxt;
           
        }
        
        public async Task<IActionResult> Index()
        {

           

            return View();
        }

        [Authorize]
        [Route("Home/GetUserCourse/{OrderId}")]
        public async Task<IActionResult> GetUserCourse(int OrderId)
        {

            var data =await _unitOfWork.course.GetAsync(OrderId);



            return View(data);
        }


       

        [Authorize(Roles = "Admin")]
        [Route("Home/ChangeStatus/{Id}")]
        public async Task<IActionResult> ChangeStatus(int Id)
        {
            var order =await  _unitOfWork.order.GetAsync(Id);
           



            return  View(order);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        [Route("Home/ChangeStatus/{Id}")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ChangeStatus(int Id, Order order)
        {
            
               var data = await _unitOfWork.order.UpdateAsync( Id, order);
            
           // var dat = _dataCtxt.orders.Find(Id);  
            if (data)
            {
                await _unitOfWork.SaveChangesAsync();

                //_dataCtxt.orders.Attach(dat);

                //dat.Status = order.Status;
                return RedirectToAction("Adminboard", "Authentication");
            }
            else
            {
                return RedirectToAction("ChangeStatus", "Home");
            }




            
        }

      




        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}