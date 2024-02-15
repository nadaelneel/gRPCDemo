using _4E.gRPCDemo.Server.Protos;
using Grpc.Core;
using Grpc.Net.Client;
using System.Threading.Channels;

namespace _4E.gRPCDEMO.client
{
    public class TrackingServiceClientWrapper
    {
        private readonly TrackingService.TrackingServiceClient _client;

        public TrackingServiceClientWrapper()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7271/"); ;
            _client = new TrackingService.TrackingServiceClient(channel);
        }

        public async Task<TrackingResponse> SendRequest(TrackingMessage request)
        {
            var response = await _client.SendMessageAsync(request);
            return response;
        }
    }
}
