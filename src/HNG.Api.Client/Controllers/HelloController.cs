using HNG.Abstractions.Contracts;
using HNG.Abstractions.Services.Business;
using IPinfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace HNG.Api.Client.Controllers
{
    /// <summary>
    /// Hello Controller - greet user sending request to this endpoint
    /// </summary>
    [Tags("Stage 1 - Greet User")]
    [Route("api/hello")]
    public class HelloController : BaseApiController
    {
        readonly IHelloService HelloService;
        /// <summary>
        /// HelloController constructor
        /// </summary>
        public HelloController(IHelloService helloService)
        {
            HelloService = helloService;
        }

        /// <summary>
        /// Greet user - returns a greeting with user's location and ip address
        /// </summary>
        [HttpGet]
        public ActionResult<VisitorIPAddressDTO> GreetUser([FromQuery] HelloUserParamDTO UserParam)
        {
            IPResponse? Ip = null;
            if (HttpContext.Items.TryGetValue("IpInfo", out var ipInfo)) { Ip = ipInfo as IPResponse; }
            return Ok(HelloService.GreetUser(Ip?.IP, Ip?.CountryName, UserParam?.visitor_name));
        }
    }
}
