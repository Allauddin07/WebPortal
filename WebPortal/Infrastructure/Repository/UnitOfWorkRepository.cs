


using BackendApp.Infrastructure.Irepository;
using Microsoft.AspNetCore.Identity;
using WebPortal.Database;
using WebPortal.Infrastructure.Irepository;
using WebPortal.Infrastructure.Repository;
using WebPortal.Models;

namespace BackendApp.Infrastructure.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly DataCtxt _dbCntxt;
        public UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _signManager;
        
        public UnitOfWorkRepository(DataCtxt dbCntxt, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser>signInManager)
        {
            _dbCntxt = dbCntxt;
            _userManager = userManager;
            _signManager=signInManager;
        }
       
        public ICourse course => new CourseRepository(_dbCntxt);

        public IOrder order => new OrderRepository(_dbCntxt);

        public IAuthentication authentication => new AuthenticationRepository(_userManager, _signManager, _dbCntxt);


        public async Task<bool> SaveChangesAsync()
        {
            return await _dbCntxt.SaveChangesAsync() > 0;  
            
        }
    }
}
