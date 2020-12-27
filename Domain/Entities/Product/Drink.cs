using Domain.Entities.Common;

namespace Domain.Entities.Product
{
    public class Drink : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public int DrinkCategoryId { get; set; }
        public string Descript { get; set; }
        public decimal Price { get; set; }
        public byte[] Img { get; set; }
        public bool Status { get; set; }
        public DrinkCategory DrinkCategory { get; set; }
    }
}
