using _4E.gRPCDemo.Server.Protos;
using Grpc.Core;

namespace _4E.gRPCDemo.Server.Services
{
    public class TelemetryTrackingService  : TrackingService.TrackingServiceBase
    {
        private readonly ILogger<TelemetryTrackingService> _logger;
        public TelemetryTrackingService(ILogger<TelemetryTrackingService> logger)
        {
            this._logger = logger;
        }
        public override Task<TrackingResponse> SendMessage(TrackingMessage request, ServerCallContext context)
        {
            //if (request.List.Count == 0)
            //{
            //    throw new RpcException(new Status(statusCode: StatusCode.InvalidArgument, ""));
            //}
            _logger.LogInformation($"New Message: deviceId :{request.DeviceId} , speed: {request.Speed}  , Date&Time : {request.DateTime} , list count : {request.List.Count}");
            return Task.FromResult( new TrackingResponse {Succsess = true });
        }
    }
}
