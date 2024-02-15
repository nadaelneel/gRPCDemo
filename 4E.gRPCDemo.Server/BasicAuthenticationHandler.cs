using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Encodings.Web;

namespace _4E.gRPCDemo.Server
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(Request.Headers.ContainsKey("Autherization"))
            {
                var header = Request.Headers["Autherization"].ToString();
                //Basic username:password
                if(header.StartsWith("Basic"))
                {
                    // username:password
                    var token = header.Split(' ')[1];

                    var bytes = Convert.FromBase64String(token);
                    var plaintext = Encoding.UTF8.GetString(bytes);

                    var seperator = plaintext.IndexOf(':');
                    var username = plaintext.Substring(0, seperator);
                    var password = plaintext.Substring(seperator + 1);

                    if(username == "device" && password == "p@ssword")
                    {

                    }
                }
            }
            return Task.FromResult(AuthenticateResult.Fail("UnAutherzation"));
        }
    }
}
