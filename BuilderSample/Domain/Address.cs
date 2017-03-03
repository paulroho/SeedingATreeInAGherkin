using System;

namespace BuilderSample.Domain
{
    public class Address
    {
        public Address(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}