using LegalCaseManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service
{
    internal interface INotificationService
    {
        Task CreateNotification(Notification notification);
        Task<List<Notification>> GetNotificationsForUser(string userId);
        Task MarkAsRead(int notificationId);
    }
}

