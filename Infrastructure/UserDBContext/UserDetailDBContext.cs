using MediatR.Domain.UserDetail;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MediatR.Infrastructure.UserDBContext
{
    public class UserDetailDBContext: DbContext
    {
        protected readonly IConfiguration _configuration;

        public UserDetailDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<UserDetail> UserDetail { get; set; }
    }
}
