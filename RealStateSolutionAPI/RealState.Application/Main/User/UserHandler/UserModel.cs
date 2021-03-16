using System;

namespace RealState.Application.Main.UserHandler
{
    public class UserModel
    {
        public int? IdUser { get; set; }
        public string IdLogin { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifyUser { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ActiveDirectory { get; set; }
        public bool State { get; set; }
    }
}