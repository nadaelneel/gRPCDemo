using _4E.gRPCDemo.Server.Protos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4E.gRPCDEMO.client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly TrackingServiceClientWrapper _Client;

        public ClientController(TrackingServiceClientWrapper Client)
        {
            _Client = Client;
        }
        [HttpPost]
        public async Task<IActionResult> Request( TrackingMessage request)
        {
            var response = await _Client.SendRequest(request);
            return Ok(response);
        }
    }
}
