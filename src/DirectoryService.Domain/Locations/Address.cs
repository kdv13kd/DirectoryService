using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;
using Const = DirectoryService.Domain.Shared.Constants;

namespace DirectoryService.Domain.Locations;

public record Address
{
    private const string ZIP_CODE_PATTERN = @"^(\d{5}[- ]?\d{4}|\d{5}|\d{6})$";

    private Address(string street, string city, string country, string? zipCode)
    {
        Street = street;
        City = city;
        Country = country;
        ZipCode = zipCode;
    }

    public string Street { get; private set; }

    public string City { get; private set; }

    public string Country { get; private set; }

    public string? ZipCode { get; private set; }


    public static Result<Address> Create(string street, string city, string country, string? zipCode = null)
    {
        if (string.IsNullOrWhiteSpace(street) || street.Length > Const.MAX_LENGTH)
        {
            Result.Failure<Address>(
                $"{nameof(Street)} должен быть строкой не более {Const.MAX_LENGTH} символов!");
        }

        if (string.IsNullOrWhiteSpace(city) || city.Length > Const.MAX_LENGTH)
        {
            Result.Failure<Address>(
                $"{nameof(City)} должен быть строкой не более {Const.MAX_LENGTH} символов!");
        }

        if (string.IsNullOrWhiteSpace(country) || country.Length > Const.MAX_LENGTH)
        {
            Result.Failure<Address>(
                $"{nameof(Country)} должен быть строкой не более {Const.MAX_LENGTH} символов!");
        }

        if (zipCode is null || !Regex.IsMatch(zipCode, ZIP_CODE_PATTERN))
        {
            Result.Failure<Address>($"{nameof(ZipCode)} должен быть в корректной форме!");
        }

        return Result.Success(new Address(street, city, country, zipCode));
    }
}
