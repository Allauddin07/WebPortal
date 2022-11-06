
using BackendApp.Infrastructure.Irepository;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebPortal.Database;
using WebPortal.Models;

namespace BackendApp.Infrastructure.Repository
{
    public class CourseRepository:ICourse
    {
        private readonly DataCtxt _dbCntxt;

        public CourseRepository(DataCtxt dbCntxt)
        {
            _dbCntxt = dbCntxt;
        }

        Task<bool> ICourse.createAsync(Course course)
        {
            throw new NotImplementedException();
        }
        async Task<ICollection<Course>> ICourse.GetAsync(int id)
        {
           var data = await  _dbCntxt.courses.Where(x=>x.OrderId==id).ToListAsync();
            return data;
        }

        Task<ICollection<Course>> ICourse.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
