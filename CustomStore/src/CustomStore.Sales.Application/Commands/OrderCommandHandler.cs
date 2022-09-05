using CustomStore.Core.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomStore.Sales.Application.Commands
{
    public class OrderCommandHandler : IRequestHandler<AddOrderItemCommand, bool>
    {
        public async Task<bool> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request))
            {
                return false;
            }

            return true;
        }

        private bool ValidateCommand(Command message)
        {
            if (message.IsValid())
            {
                return true;
            }

            foreach (var error in message.ValidationResult.Errors)
            {
                // throw error event
            }

            return false;
        }
    }
}
