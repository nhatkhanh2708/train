using Domain.Entities.Common;
using Domain.Entities.StaffAggregate;

namespace Domain.Entities.ManageAccount
{
    public class Account : EntityBase,IAggregateRoot
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int StaffId { get; set; }
        public bool Status { get; set; }
        public Staff Staff { get; set; }
    }
}
