using HNG.Abstractions.Contracts;

namespace HNG.Abstractions.Services.Business
{
    public interface IHelloService : IBusinessService
    {
        VisitorIPAddressDTO GreetUser(string? Ip, string? CountryName, string? VisitorName);
    }
}
