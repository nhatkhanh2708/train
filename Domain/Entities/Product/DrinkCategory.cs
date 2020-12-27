using Domain.Entities.Common;

namespace Domain.Entities.Product
{
    public class DrinkCategory : EntityBase, IAggregateRoot
    {
        public string Title { get; set; }
    }
}
