using BackendApp.Infrastructure.Irepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebPortal.Database;
using WebPortal.DTO;
using WebPortal.Infrastructure.Irepository;
using WebPortal.Models;
using WebPortal.Services;

namespace WebPortal.Infrastructure.Repository
{
    public class AuthenticationRepository : IAuthentication
    {
      
        public UserManager<ApplicationUser> _userManager;    
        public SignInManager<ApplicationUser> _signInManager;
        private readonly DataCtxt _dbCntxt;
        
        public AuthenticationRepository(UserManager<ApplicationUser> userManager,   SignInManager<ApplicationUser> signInManager, DataCtxt dataCtxt)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbCntxt = dataCtxt;
          

        }


        async Task<SignInResult> IAuthentication.SigInAsync(SignIn signIn)
        {
            var result = await _signInManager.PasswordSignInAsync(signIn.Email, signIn.Password, true, false);
            return result;
        }

       

        async Task<List<Order>> IAuthentication.UserDetail(string id)
        {

            var result = await _userManager.FindByIdAsync(id);

            var orders =  _dbCntxt.orders.Where(x => x.Id == id).ToList();

            return orders;


            



        }

        async Task<IdentityResult> IAuthentication.SignUpAsync(SignUp signUp)
        {
            var user = new ApplicationUser()
            {
                FullName = signUp.FullName,
                Email = signUp.Email,
                UserName=signUp.Email

            };
            var result =await _userManager.CreateAsync(user, signUp.Password);

            return result;


        }

        async Task<List< UserData>> IAuthentication.GetallUser()
        {
           var result = await _userManager.Users.ToListAsync();
            var resul = await _userManager.Users.ToListAsync();

           

            var courses = await _dbCntxt.courses.ToListAsync();
            var orders = await _dbCntxt.orders.ToListAsync();




            var st = (from s in result
                      join o in orders
                      on s.Id equals o.Id
                      join c in courses
                      on o.OrderId equals c.OrderId

                      select new UserData()
                      {

                          Id=o.OrderId,

                          Name = s.FullName,

                          Status = o.Status,
                          Course = c.Name,


                      }).ToList();

            if (st != null)
            {
                return st;
            }
            return null;



             


        }
    }
}
