using System;

public class Intro
{
    string GetFormattedValue(decimal value, ValueFormat format)
    {
        // ...
    }

    public void GetFormattedValue_ShouldFormatNegativeValues()
    {
        var actual = GetFormattedValue(-1.23m, ValueFormat.Currency);
        Assert.AreEqual("-1,23 €", actual);
    }
}

public class WhatIsNeeded
{
    public void Dummy()
    {
        var address = new Address
        {
            Country = "Austria",
            City = "Vienna",
            ZipCode = "1010",
            Street = "Stephansplatz 1",
        };

        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            CusteromNo = 1234,
            FirstName = "Susi",
            LastName = "Mayer",
            Address = address,
        };

        using (var session = new AutoCleanupServerSession())
        {
            AddressDataAccess.Instance.Insert(session, address);
            CustomerDataAccess.Instance.Insert(session, customer);

            // ...
        }

        var address = CreateAddress("Austria", "Vienna");
        var customer = CreateCustomer(123, "Susi", "Mayer", address);

        var customer = CreateCustomerWithAddress(123, "Susi", "Mayer", 
                                                 "Austria", "Vienna");

        var address = an.Address().InCountry("Austria")
                                  .InCity("Vienna")
                                  .Build();
        var customer = a.Customer().LivingAt(address)
                                   .Build();

        TestExecutor.ExecuteTest(a =>
        {
            var customer = a.DomesticCustomer().LivingIn("Vienna");

            // ...
        });

        TestExecutor.ExecuteDbTest(aDb =>
        {
            var customer = aDb.DomesticCustomer().LivingIn("Vienna");

            // ...
        });
    }

    public Customer CreateCustomerWithAddress(int customerNo, string firstName, string lastName, string country, string city);
}

public enum ValueFormat
{
    Currency
}


public class Address { }
public class Customer { }

public class AddressDataAccess
{
    static AddressDataAccess Instance { get; }
}
public class CustomerDataAccess
{
    static CustomerDataAccess Instance { get; }
}

public class TestExecutor
{ }