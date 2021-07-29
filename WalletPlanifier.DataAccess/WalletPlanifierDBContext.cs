using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WalletPlanifier.Common.Models;
using WalletPlanifier.Common.Services.Contracts;
using WalletPlanifier.Domain.Transactions;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.DataAccess
{
    public class WalletPlanifierDBContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public WalletPlanifierDBContext(DbContextOptions<WalletPlanifierDBContext> options,
                                        ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        #region Save Changes
        public override int SaveChanges()
        {
            var auditableEntitySet = ChangeTracker.Entries<IAuditableEntity>();

            if (auditableEntitySet != null)
            {
                foreach (var auditableEntity in auditableEntitySet.Where(c => c.State == EntityState.Added || c.State == EntityState.Modified))
                {
                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreationTime = DateTime.Now;
                        auditableEntity.Entity.CreatorUserId = _currentUserService.UserId ?? 0;
                    }

                    auditableEntity.Entity.LastModificationTime = DateTime.Now;
                    auditableEntity.Entity.LastModifierUserId = _currentUserService.UserId ?? 0;
                }
            }

            return base.SaveChanges();
        }

        #endregion

        public DbSet<User> Users { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public DbSet<Debt> Debt { get; set; }
        public DbSet<Frecuency> Frecuency { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Wallet> Wallet { get; set; }

    }
}
