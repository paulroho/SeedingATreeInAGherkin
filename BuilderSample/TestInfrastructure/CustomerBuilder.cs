using System;
using BuilderSample.Domain;

namespace BuilderSample.TestInfrastructure
{
    public class CustomerBuilder
    {
        private Customer _customer = new Customer(Guid.NewGuid())
        {
            FirstName = "The first name",
            LastName = "The last name",
            Address = BuilderRoot.An.Address,
        };

        public static implicit operator Customer(CustomerBuilder builder) => builder.Build();

        private Customer Build() => _customer;

        public CustomerBuilder WithId(string idAsString)
        {
            _customer = new Customer(Guid.Parse(idAsString))
            {
                FirstName = _customer.FirstName,
                LastName = _customer.LastName,
                Address = _customer.Address,
            };
            return this;
        }

        public CustomerBuilder WithFirstName(string firstName)
        {
            _customer.FirstName = firstName;
            return this;
        }

        public CustomerBuilder Named(string lastName)
        {
            _customer.LastName = lastName;
            return this;
        }

        public CustomerBuilder LivingAt(Address address)
        {
            _customer.Address = address;
            return this;
        }
    }
}