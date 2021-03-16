using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class RecoverPassword 
    {
        public string Email { get; set; }
        public string code { get; set; }
        public string NewPassword { get; set; }
    }
}