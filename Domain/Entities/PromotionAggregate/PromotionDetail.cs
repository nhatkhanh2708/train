using Domain.Entities.Common;

namespace Domain.Entities.PromotionAggregate
{
    public class PromotionDetail : EntityBase, IAggregateRoot
    {
        public int PromotionId { get; set; }
        public string Content { get; set; }
        public decimal Discount { get; set; }
        public Promotion Promotion { get; set; }
    }
}
