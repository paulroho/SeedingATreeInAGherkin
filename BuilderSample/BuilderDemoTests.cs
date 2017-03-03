using System;
using BuilderSample.Domain;
using BuilderSample.TestInfrastructure;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuilderSample
{
    [TestClass]
    public class BuilderDemoTests
    {
        // For the brevity on the side of usage
        private readonly BuilderRoot A = BuilderRoot.A;
        private readonly BuilderRoot An = BuilderRoot.A;

        [TestMethod]
        public void Just_AnAddress_CreatesAFullyInitializedAddress()
        {
            // Act
            Address address = An.Address;

            address.Id.Should().NotBeEmpty();
            address.Zip.Should().NotBeNullOrWhiteSpace();
            address.City.Should().NotBeNullOrWhiteSpace();
            address.Street.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void AnAddress_WithEverythingSpecified_ConsidersTheseValues()
        {
            // Act
            Address address = An.Address.WithId("{8CCECC6F-B758-4136-A3F8-CFBB46676617}")
                                        .WithZip(1010)
                                        .WithCity("Vienna")
                                        .WithStreet("Stephansplatz");

            // Assert
            address.Id.Should().Be("{8CCECC6F-B758-4136-A3F8-CFBB46676617}");
            address.Zip.Should().Be("1010");
            address.City.Should().Be("Vienna");
            address.Street.Should().Be("Stephansplatz");
        }

        [TestMethod]
        public void Just_ACustomer_CreatesAFullyInitializedCustomer()
        {
            // Act
            Customer customer = A.Customer;

            customer.Id.Should().NotBeEmpty();
            customer.FirstName.Should().NotBeNullOrWhiteSpace();
            customer.LastName.Should().NotBeNullOrWhiteSpace();
            customer.Address.Should().NotBeNull();
        }

        [TestMethod]
        public void ACustomer_WithEverythingSpecified_ConsidersTheseValues()
        {
            // Act
            Address anyAddress = An.Address;
            Customer customer = A.Customer.WithId("{CD8ADFB1-E3C9-4556-845C-E149AB6343E5}")
                .Named("Mayer")
                .WithFirstName("Susi")
                .LivingAt(anyAddress);

            // Assert
            customer.Id.Should().Be("{CD8ADFB1-E3C9-4556-845C-E149AB6343E5}");
            customer.FirstName.Should().Be("Susi");
            customer.LastName.Should().Be("Mayer");
        }

        [TestMethod]
        public void WhenSomePartsAreSpecified_TheSpecifiedPartsGetUsed_AndTheUnspecifiedAreInitialized()
        {
            // Act
            Customer customer = A.Customer.WithFirstName("Hans")
                                          .LivingAt(An.Address.WithZip(1234));

            customer.Id.Should().NotBeEmpty();
            customer.FirstName.Should().Be("Hans");
            customer.LastName.Should().NotBeNullOrWhiteSpace();

            var address = customer.Address;
            address.Id.Should().NotBeEmpty();
            address.Zip.Should().Be("1234");
            address.City.Should().NotBeNullOrWhiteSpace();
            address.Street.Should().NotBeNullOrWhiteSpace();
        }
    }
}
