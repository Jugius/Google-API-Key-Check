using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using System;

namespace GoogleKeyCheck.Tests.Maps
{
    sealed class NearestRoads : BaseTest
    {
        public NearestRoads()
        {
            this.Api = "Maps/Roads";
        }

        public override Status RunTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey,
                Points = new[]
                 {
                    new Location(60.170880, 24.942795),
                    new Location(60.170879, 24.942796),
                    new Location(60.170877, 24.942796)
                }
            };

            var result = GoogleMaps.NearestRoads.Query(request);
            return result.Status ?? throw new Exception("Status Is Null");
        }
    }
}
