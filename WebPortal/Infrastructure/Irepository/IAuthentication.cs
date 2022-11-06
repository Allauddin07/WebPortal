using Microsoft.AspNetCore.Identity;
using WebPortal.DTO;
using WebPortal.Models;

namespace WebPortal.Infrastructure.Irepository
{
    public interface IAuthentication
    {
         Task<IdentityResult> SignUpAsync(SignUp signUp);
        Task<SignInResult> SigInAsync( SignIn signIn);

        Task<List<UserData>> GetallUser();
        Task<List<Order>> UserDetail(string id);
    }
}
