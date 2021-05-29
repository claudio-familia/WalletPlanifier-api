using System;
using System.ComponentModel.DataAnnotations;
using WalletPlanifier.Common.Models;

namespace WalletPlanifier.Domain
{
    public class BaseEntity : IAuditableEntity
    {
        public int Id { get; set; }
        public bool? Active { get; set; }
        public DateTime CreationDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
