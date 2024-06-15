using CqrsMediatr.CommandHandler;
using CqrsMediatr.Infrastructure.Repository;
using MediatR;
using MediatR.Domain.UserDetail;

namespace CqrsMediatr.QueryHandler
{
    public class UserDetailQueryHandler : IRequestHandler<UserQueryCommand, UserDetail>
    {
        private readonly UserDetailRepository _userDetailRepository;

        public UserDetailQueryHandler(UserDetailRepository userDetailRepository)

        {
            _userDetailRepository = userDetailRepository;
        }
        public async Task<UserDetail> Handle(UserQueryCommand userQueryCommand, CancellationToken cancellationToken)
        {
           var userDetail =  await _userDetailRepository.GetUserDetail(userQueryCommand.Id);
           return userDetail;

        }
    }

    public class UserQueryCommand : IRequest<UserDetail>
    {
        public int Id { get; set; }
  
    }
}
