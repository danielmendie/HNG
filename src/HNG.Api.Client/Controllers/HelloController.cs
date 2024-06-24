using HNG.Abstractions.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HNG.Api.Client.Controllers
{
    /// <summary>
    /// Hello Controller - greet user sending request to this endpoint
    /// </summary>
    [Tags("Greet User")]
    [Route("api/hello")]
    public class HelloController : BaseApiController
    {
        /// <summary>
        /// HelloController constructor
        /// </summary>
        public HelloController() { }

        /// <summary>
        /// Greet user - returns a greeting with user's location and ip address
        /// </summary>
        [HttpGet]
        public GreetUserDTO GreetUser([FromQuery] HelloUserParamDTO UserParam)
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            return new GreetUserDTO { Client_Ip = remoteIpAddress ?? "127.0.0.1", Location = "Nigeria", Greeting = $"hello, {UserParam.Visitor_Name}" };
        }
    }
}
