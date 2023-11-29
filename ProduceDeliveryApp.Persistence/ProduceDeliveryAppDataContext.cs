using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.Domain;
using ProduceDeliveryApp.Persistence.IdentityModels;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.Persistence
{
    public class ProduceDeliveryAppDataContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IProduceDeliveryAppDataContext
    {
        public ProduceDeliveryAppDataContext(DbContextOptions<ProduceDeliveryAppDataContext> options)
            : base(options) { }


        public DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IMarker).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken token)
        {
            return Database.BeginTransactionAsync(token);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken token)
        {
            return Database.BeginTransactionAsync(isolationLevel, token);
        }

        async Task IProduceDeliveryAppDataContext.SaveChangesAsync(CancellationToken token)
        {
            await SaveChangesAsync(token);
        }
    }
}
