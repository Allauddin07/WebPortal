using WebPortal.Infrastructure.Irepository;

namespace BackendApp.Infrastructure.Irepository
{
    public interface IUnitOfWork
    {
        

        ICourse course { get; }

        IOrder order { get; }

        IAuthentication authentication { get; }
       
        Task<bool> SaveChangesAsync();


    }
}
