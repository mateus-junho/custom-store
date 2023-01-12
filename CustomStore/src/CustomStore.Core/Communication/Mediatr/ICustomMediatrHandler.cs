using CustomStore.Core.Messages;
using System.Threading.Tasks;

namespace CustomStore.Core.Communication
{
    public interface ICustomMediatrHandler
    {
        Task PublishEvent<T>(T customEvent) where T : Event;
        Task<bool> SendCommand<T>(T command) where T : Command;
    }
}
