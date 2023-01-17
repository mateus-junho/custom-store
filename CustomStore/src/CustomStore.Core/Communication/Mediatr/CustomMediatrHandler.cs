
using CustomStore.Core.Messages;
using CustomStore.Core.Messages.CommonMessages.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace CustomStore.Core.Communication
{
    public class CustomMediatrHandler : ICustomMediatrHandler
    {
        private readonly IMediator mediatr;

        public CustomMediatrHandler(IMediator mediator)
        {
            mediatr = mediator;
        }

        public async Task PublishEvent<T>(T customEvent) where T : Event
        {
            await mediatr.Publish(customEvent);
        }

        public async Task PublishNotification<T>(T notification) where T : DomainNotification
        {
            await mediatr.Publish(notification);
        }

        public async Task<bool> SendCommand<T>(T command) where T : Command
        {
            return await mediatr.Send(command); //request
        }
    }
}
