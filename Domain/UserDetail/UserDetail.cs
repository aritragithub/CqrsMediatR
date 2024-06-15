namespace MediatR.Domain.UserDetail
{
    public class UserDetail
    {
        public int Id { get; set; } 
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }

        public UserDetail() 
        {

        }
        public UserDetail(string name, string email, string address)
        {
            Name = name;    
            Email = email;
            Address = address;
        }

    }

}
