using MediatR;

namespace RealState.Application.Main.UserHandler
{
    public class UserCreationCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string UserCreates { get; set; }
        public string Token { get; set; }
    }
}