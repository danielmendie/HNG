using HNG.Abstractions.Contracts;
using IPinfo.Models;
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
        public IActionResult GreetUser([FromQuery] HelloUserParamDTO UserParam)
        {
            if (HttpContext.Items.TryGetValue("IpInfo", out var ipInfo))
            {
                IPResponse? IP = ipInfo as IPResponse;
                if (IP != null)
                {
                    var ipdetail = new GreetUserDTO
                    {
                        Client_Ip = IP.IP,
                        Location = IP.CountryName,
                        Greeting = $"hello, {UserParam.Visitor_Name}"
                    };

                    return Ok(ipdetail);
                }
            }

            return NotFound("Your IP information not found");
        }
    }
}
