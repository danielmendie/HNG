namespace HNG.Abstractions.Contracts
{
    public class GreetUserDTO
    {
        public string Client_Ip { get; set; } = null!;
        public string? Location { get; set; }
        public string Greeting { get; set; } = null!;
    }
}
