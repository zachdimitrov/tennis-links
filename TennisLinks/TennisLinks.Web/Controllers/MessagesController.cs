using AutoMapper;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Models.Messages;
using TennisLinks.Web.Infrastructure;
using System.Net;

namespace TennisLinks.Web.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        // private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IMessageService messageService;

        public MessagesController(
            IUserService userService,
            IMessageService messageService)
        {
            this.userService = userService;
            this.messageService = messageService;
        }

        public ActionResult All()
        {
            return this.View();
        }

        public ActionResult Received()
        {
            var userName = this.User.Identity.GetUserName();
            var receivedMessages = this.messageService
                .GetAll()
                .Where(m => m.Recipient == userName)
                .MapTo<MessageViewModel>()
                .ToList();

            return this.View(receivedMessages);
        }

        public ActionResult Sent()
        {
            var userName = this.User.Identity.GetUserName();
            var sentMessages = this.messageService
                .GetAll()
                .Where(m => m.Author == userName)
                .MapTo<MessageViewModel>()
                .ToList();

            return this.View(sentMessages);
        }

        [HttpGet]
        public ActionResult Write(string recipient)
        {
            var userName = this.User.Identity.GetUserName();

            var model = new MessageViewModel()
            {
                Recipient = recipient,
                Author = userName
            };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Write(MessageViewModel model)
        {
            var userName = this.User.Identity.GetUserName();
            var message = new TennisLinks.Models.Message()
            {
                Author = userName,
                Recipient = model.Recipient,
                Title = model.Title,
                Content = model.Content
            };

            var result = this.messageService.Add(message);

            if (result > 0)
            {
                return this.RedirectToAction("Sent");
            }

            return this.MessageValidationFailure();
        }

        public HttpStatusCodeResult MessageValidationFailure()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Validation failed! Message was not sent!");
        }
    }
}