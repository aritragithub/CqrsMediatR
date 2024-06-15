using CqrsMediatr.CommandHandler;
using CqrsMediatr.QueryHandler;
using MediatR.Domain.UserDetail;
using MediatR.Infrastructure.UserDBContext;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatr.Infrastructure.Repository
{
    public class UserDetailRepository
    {
        private readonly UserDetailDBContext _userDetailDBContext;

        public UserDetailRepository(UserDetailDBContext userDetailDBContext)
        {
            _userDetailDBContext = userDetailDBContext;
        }


        public async Task<int> AddUserDetail(UserDetail userDetail)
        {
            try 
            {
                _userDetailDBContext.UserDetail.Add(userDetail);
                return await _userDetailDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
           
            
        }

        public async Task<UserDetail> GetUserDetail(int id) 
        {
            try
            {
                var userDetail = await _userDetailDBContext.UserDetail.Where(o => o.Id == id).SingleOrDefaultAsync() ?? new UserDetail();
                return userDetail;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
