using CustomStore.Core.Bus;
using CustomStore.Core.DomainObjects;
using CustomStore.Sales.Data.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace CustomStore.Sales.Data.Extensions
{
    public static class CustomMediatrExtension
    {
        public static async Task PublishEvents(this ICustomMediatrHandler mediator, SalesContext ctx)
        {
            //var domainEntities = ctx.ChangeTracker
            //    .Entries<Entity>()
            //    .Where(x => x.Entity != null && x.Entity.Notifications.Any());

            //var domainEvents = domainEntities
            //    .SelectMany(x => x.Entity.Notifications)
            //    .ToList();

            //domainEntities.ToList()
            //    .ForEach(entity => entity.Entity.ClearEvents());

            //var tasks = domainEvents
            //    .Select(async (domainEvent) => {
            //        await mediator.PublishEvent(domainEvent);
            //    });

            //await Task.WhenAll(tasks);
        }
    }
}
