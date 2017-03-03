using System;
using BuilderSample.Domain;

namespace BuilderSample.TestInfrastructure
{
    public class AddressBuilder
    {
        private Address _address = new Address(Guid.NewGuid())
        {
            Zip = "A-12345",
            City = "A city",
            Street = "A street",
        };
        public static implicit operator Address(AddressBuilder builder) => builder.Build();

        private Address Build() => _address;

        public AddressBuilder WithId(string idAsString)
        {
            _address = new Address(Guid.Parse(idAsString))
            {
                City = _address.City,
                Zip = _address.Zip,
                Street = _address.Street,
            };
            return this;
        }

        public AddressBuilder WithZip(int zip)
        {
            _address.Zip = zip.ToString();
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            _address.City = city;
            return this;
        }

        public AddressBuilder WithStreet(string street)
        {
            _address.Street = street;
            return this;
        }
    }
}