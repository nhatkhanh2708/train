using Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities.PromotionAggregate
{
    public class Promotion : EntityBase, IAggregateRoot
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public sbyte Status { get; set; }
        public IList<PromotionDetail> PromotionDetails { get; set; }
    }
}
