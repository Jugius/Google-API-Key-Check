using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
using System;

namespace GoogleKeyCheck.Tests.Maps
{
    sealed class Directions : BaseTest
    {
        public Directions()
        {
            this.Api = "Maps";
        }

        public override Status RunTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA")
            };
            var result = GoogleMaps.Directions.Query(request);
            //var overviewPath = result.Routes.First().OverviewPath;
            //var polyline = result.Routes.First().Legs.First().Steps.First().PolyLine;

            return result.Status ?? throw new Exception("Status Is Null");
        }
    }
}
