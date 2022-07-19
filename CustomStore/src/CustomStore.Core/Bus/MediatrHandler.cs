
using CustomStore.Core.Messages;
using MediatR;
using System.Threading.Tasks;

namespace CustomStore.Core.Bus
{
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator mediatr;

        public async Task PublishEvent<T>(T customEvent) where T : Event
        {
            await mediatr.Publish(customEvent);
        }
    }
}
