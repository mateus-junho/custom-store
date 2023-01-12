using CustomStore.Core.Communication;
using CustomStore.Core.Data;
using CustomStore.Core.Messages;
using CustomStore.Sales.Data.Extensions;
using CustomStore.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomStore.Sales.Data.Contexts
{
    public class SalesContext : DbContext, IUnitOfWork
    {
        private readonly ICustomMediatrHandler mediatrHandler;

        public SalesContext(DbContextOptions<SalesContext> options, ICustomMediatrHandler mediatrHandler)
            : base(options)
        {
            this.mediatrHandler = mediatrHandler;
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("nvarchar(250)");
            }

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.HasSequence<int>("MySequence").StartsAt(1000).IncrementsBy(1);
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegisterDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("RegisterDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("RegisterDate").IsModified = false;
                }
            }

            var success = await base.SaveChangesAsync() > 0;
            if (success)
            {
                await mediatrHandler.PublishEvents(this);
            }

            return success;
        }
    }
}
