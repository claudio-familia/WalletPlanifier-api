using System;

namespace WalletPlanifier.Common.Models
{
    public interface IAuditableEntity
    {
        public bool? Active { get; set; }
        public DateTime CreationDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
