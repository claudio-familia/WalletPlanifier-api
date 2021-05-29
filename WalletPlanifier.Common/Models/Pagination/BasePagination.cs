using System;
using System.Collections.Generic;
using System.Text;

namespace WalletPlanifier.Common.Models.Pagination
{
   public class BasePagination
    {
        public int? PageNumber { get; set; } = 0;
        public int? PageSize { get; set; } = 15;
        public string IncludeTotal { get; set; } = "true";
    }
}
