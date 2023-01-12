
using CustomStore.Core.Messages;
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

        public async Task<bool> SendCommand<T>(T command) where T : Command
        {
            return await mediatr.Send(command); //request
        }
    }
}
