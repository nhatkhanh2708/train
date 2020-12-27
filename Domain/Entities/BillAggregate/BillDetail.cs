using Domain.Entities.Common;
using Domain.Entities.Product;

namespace Domain.Entities.BillAggregate
{
    public class BillDetail : EntityBase, IAggregateRoot
    {
        public int BillId { get; set; }
        public int DrinkId { get; set; }
        public int Quantity { get; set; }
        public Bill Bill { get; set; }
        public Drink Drink { get; set; }
    }
}
