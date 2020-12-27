using Domain.Entities.Common;
using Domain.ValueObjects;
using System;

namespace Domain.Entities.StaffAggregate
{
    public class Person : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}
