using System;
using System.ComponentModel.DataAnnotations;
using WalletPlanifier.Common.Models;

namespace WalletPlanifier.Domain
{
    public class BaseEntity : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public int? DeleterUserId { get; set; }
    }
}
