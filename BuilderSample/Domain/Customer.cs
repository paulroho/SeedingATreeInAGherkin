using System;

namespace BuilderSample.Domain
{
    public class Customer
    {
        public Customer(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
}