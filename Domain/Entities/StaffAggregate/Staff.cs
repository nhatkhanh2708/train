namespace Domain.Entities.StaffAggregate
{
    public class Staff : Person
    {
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public byte[] Img { get; set; }
        public bool Status { get; set; }
    }
}
