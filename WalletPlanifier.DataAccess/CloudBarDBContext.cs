using WalletPlanifier.Common.Services.Contracts;
using WalletPlanifier.Domain;
using WalletPlanifier.Domain.General;
using WalletPlanifier.Domain.Purchase;
using WalletPlanifier.Domain.Sale;
using WalletPlanifier.Domain.Security;
using WalletPlanifier.Domain.Warehouse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
                        auditableEntity.Entity.CreatedAt = DateTime.Now;
                        auditableEntity.Entity.CreatedBy = _currentUserService.UserId.Value;
                    }

                    auditableEntity.Entity.UpdatedAt = DateTime.Now;
                    auditableEntity.Entity.UpdatedBy = _currentUserService.UserId;
                }
            }

            return base.SaveChanges();
        }

        #endregion

        #region Security
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        #region General
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Person> People { get; set; }
        #endregion

        #region Purchase
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierItem> SupplierItems { get; set; }
        #endregion

        #region Sale
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        #endregion

        #region Warehouse
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        #endregion
    }
}
