using System.Threading.Tasks;
using RealState.Application.Common.Models;
using RealState.Application.Notifications.Models;

namespace RealState.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
        Task SendEmailHTMLAsync(Message message);
    }
}