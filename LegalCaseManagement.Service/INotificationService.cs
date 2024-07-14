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
        Task SendTaskDueNotificationsAsync();
        Task<List<Notification>> GetNotificationsForUser(string userId);
        /// <summary>
        /// Creates a new notification for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user to receive the notification.</param>
        /// <param name="message">The content of the notification.</param>
        Task CreateNotification(string userId, string message);

        /// <summary>
        /// Retrieves all unread notifications for a given user.
        /// </summary>
        /// <param name="userId">The ID of the user whose unread notifications to retrieve.</param>
        /// <returns>A list of unread Notification objects.</returns>
        Task<List<Notification>> GetUnreadNotificationsForUser(string userId);

        /// <summary>
        /// Marks a specific notification as read.
        /// </summary>
        /// <param name="notificationId">The ID of the notification to mark as read.</param>
        Task MarkAsRead(int notificationId);
    }
}

