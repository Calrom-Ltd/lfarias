using API_projTraining.Libraries;
using System.Collections.Generic;

namespace API_projTraining.Services
{
    public interface IMessageServices
    {
        void AddMessageToList(Message message);
        void DeleteMessages(string email);
        List<Message> GetAllMessages();
        List<Message> GetListOfMessagesForOneUser(string email);
    }
}