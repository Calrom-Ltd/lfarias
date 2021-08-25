using System.Collections.Generic;
using System.Linq;

namespace API_projTraining.Services
{
    public class MessageServices : Message
    {
        public ApplicationDbContext _context;
        public MessageServices(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public List<Message> GetAllMessages() =>
            _context.Messages.ToList();

        public List<Message> GetMessagesFromTheList(string email)
        {

            var inboxMessages = new List<Message>();

            var listForInboxMessages = _context.Messages.Where(p => p.UserId.Email == email);

            foreach (var messagecontent in listForInboxMessages)
            {
                inboxMessages.Add(messagecontent);
            }
            return inboxMessages;
        }
    }
}