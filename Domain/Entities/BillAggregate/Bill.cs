using Domain.Entities.Common;
using Domain.Entities.PromotionAggregate;
using Domain.Entities.StaffAggregate;
using System;
using System.Collections.Generic;

namespace Domain.Entities.BillAggregate
{
    public class Bill : EntityBase, IAggregateRoot
    {
        public int StaffId { get; set; }
        public DateTime DayOfSale { get; set; }
        public int? PromotionDetailId { get; set; }
        public Staff Staff { get; set; }
        public PromotionDetail PromotionDetail { get; set; }
        public IList<BillDetail> BillDetails { get; set; }
    }
}
