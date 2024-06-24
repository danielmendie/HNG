using HNG.Abstractions.Contracts;
using HNG.Abstractions.Services.Business;
using SimpleValidator;

namespace HNG.Business
{
    public class HelloService : BaseBusinessLayerService, IHelloService
    {
        public HelloService()
        { }

        public VisitorIPAddressDTO GreetUser(string? Ip, string? CountryName, string? VisitorName)
        {
            var validator = new Validator();
            validator
            .IsNotNullOrEmpty(nameof(Ip), Ip ?? string.Empty, "Your IP information could not found*")
            .IsNotNullOrEmpty(nameof(VisitorName), VisitorName ?? string.Empty, "Visitor name is required*")
            .EnsureNoHtml(nameof(Ip), Ip ?? string.Empty, "IP must not contain html content*")
            .EnsureNoHtml(nameof(VisitorName), VisitorName ?? string.Empty, "Visitor name must not contain html content*");
            validator.ThrowValidationExceptionIfInvalid();

            var ipdetail = new VisitorIPAddressDTO
            {
                Client_Ip = Ip!,
                Location = CountryName!,
                Greeting = $"Hello, {VisitorName}"
            };

            return ipdetail;
        }
    }
}
