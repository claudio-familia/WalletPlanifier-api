using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WalletPlanifier.Common.Models;
using WalletPlanifier.Common.Services.Contracts;

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
                    }                    

                    auditableEntity.Entity.LastModificationTime = DateTime.Now;
                    auditableEntity.Entity.LastModifierUserId = _currentUserService.UserId.HasValue ? 
                                                                _currentUserService.UserId.Value : 0;
                }
            }

            return base.SaveChanges();
        }

        #endregion

    }
}
