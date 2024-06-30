using LegalCaseManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service
{
    internal interface IMessagingService
    {
        Task SendMessage(Message message);
        //Task<List<Message>> GetMessagesBetweenUsers(string user1Id, string user2Id);
        Task MarkAsRead(int messageId);
    }
}
