namespace RealState.Application.Login.Queries.LoginUser
{
    public class UserAuthenticated
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string[] RolesList { get; set; }
    }
}