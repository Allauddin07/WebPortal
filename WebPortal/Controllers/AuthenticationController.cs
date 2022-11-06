using BackendApp.Infrastructure.Irepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Database;
using WebPortal.Models;
using WebPortal.Services;

namespace WebPortal.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetUserID _GetuserId;
        public UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private DataCtxt _dataCtxt;
        
        public AuthenticationController(IUnitOfWork unitOfWork, IGetUserID GetuserId,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            DataCtxt dataCtxt)
        {
            _unitOfWork = unitOfWork;
            _GetuserId = GetuserId;
            _userManager = userManager;
            _roleManager = roleManager;
            _dataCtxt= dataCtxt;    

            
        }

        // GET: Authentication Sign up
        public ActionResult SignUp()
        {
            return View();
        }

        // GET: Authentication Sign
        
        public ActionResult SignIn()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public ActionResult AdminDashboard()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> Adminboard()
        {

            try {
                var users = await _unitOfWork.authentication.GetallUser();
                if (users == null)
                {
                    ModelState.AddModelError("", "No data available");
                    return View();
                }
                else
                {
                    return View(users);
                }
               
            }
            catch(Exception ex) {
                
                ModelState.AddModelError("", "Somthing went wrong");
                return View();
            }
           
        }

        [Authorize]
        public async Task<ActionResult> Userboard()
        {
            try {
                var id = _GetuserId.UserID();


                var order = _unitOfWork.authentication.UserDetail(id).Result;

                if (order!=null) {

                    return View(order);
                }
                return View();

                
            }
            catch (Exception ex) {
            
                return View("Somethin went wrong");
            }


           
        }



        //public async Task<ActionResult> LogOff()
        //{
        //    await _signInManager.SignOutAsync();   
        //    return RedirectToAction("SignIn", "Authentication");
           
        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(SignUp signUp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var result= await _unitOfWork.authentication.SignUpAsync(signUp);
                    if (result.Succeeded)
                    {
                        
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                       foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                       return View(signUp);   
                    }
                    ModelState.Clear();
                }

                    
                
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(SignIn signIn)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _unitOfWork.authentication.SigInAsync(signIn);
                    if (result.Succeeded)
                    {

                       
                        var data = _userManager.FindByNameAsync(signIn.Email).Result;
                       
                        var role = await _userManager.GetRolesAsync(data);

                        if (role[0] == "Admin")
                        {
                            return RedirectToAction("Adminboard", "Authentication");

                        }
                        else
                        {
                            return RedirectToAction("Userboard",  "Authentication");

                        }

                        

                        
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Credential");

                       return View(signIn); 
                    }
                   
                }



                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }



    }
}
