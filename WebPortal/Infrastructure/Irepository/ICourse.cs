

using WebPortal.Models;

namespace BackendApp.Infrastructure.Irepository
{
    public interface ICourse
    {
        Task<ICollection<Course>> GetAllAsync();

        Task<ICollection<Course>> GetAsync(int id);   

      

        Task<bool> createAsync(Course course);
    }
}

