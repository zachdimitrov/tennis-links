using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Services
{
    public class MessageService : IMessageService
    {
        private readonly IEfRepository<Message> messageRepo;
        private readonly ISaveContext context;

        public MessageService(IEfRepository<Message> messageRepo, ISaveContext context)
        {
            this.messageRepo = messageRepo;
            this.context = context;
        }

        public int Add(Message message)
        {
            this.messageRepo.Add(message);
            return this.context.Commit();
        }

        public IQueryable<Message> GetAll()
        {
            return this.messageRepo.All;
        }

        public int Update(Message message)
        {
            this.messageRepo.Update(message);
            return this.context.Commit();
        }

        public int Delete(Message message)
        {
            this.messageRepo.Delete(message);
            return this.context.Commit();
        }
    }
}
