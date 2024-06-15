using CqrsMediatr.Infrastructure.Repository;
using MediatR;
using MediatR.Domain.UserDetail;
using MediatR.Infrastructure.UserDBContext;

namespace CqrsMediatr.CommandHandler
{
    public class UserDetailCommandHandler : IRequestHandler<UserDetailCommand, int>
    {
        private readonly UserDetailRepository _userDetailRepository;

        public UserDetailCommandHandler(UserDetailRepository userDetailRepository)
        
        {
            _userDetailRepository = userDetailRepository;
        }

        public async Task<int> Handle(UserDetailCommand userDetailCommand, CancellationToken cancellationToken)
        {

            var userDetail = new UserDetail(userDetailCommand.Name, userDetailCommand.Email, userDetailCommand.Address);
            return await _userDetailRepository.AddUserDetail(userDetail);
        }
    }

    public class UserDetailCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Address { get; set; }
    }
}
