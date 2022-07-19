using CustomStore.Core.Messages;
using System.Threading.Tasks;

namespace CustomStore.Core.Bus
{
    public interface IMediatrHandler
    {
        Task PublishEvent<T>(T customEvent) where T : Event;
    }
}
