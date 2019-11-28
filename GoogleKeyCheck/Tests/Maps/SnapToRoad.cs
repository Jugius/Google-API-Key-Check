using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using System;

namespace GoogleKeyCheck.Tests.Maps
{
    sealed class SnapToRoad : BaseTest
    {
        public SnapToRoad()
        {
            this.Api = "Maps/Roads";
        }

        public override Status RunTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new[]
                {
                    new Location(60.170880, 24.942795),
                    new Location(60.170879, 24.942796),
                    new Location(60.170877, 24.942796)
                }
            };
            var result = GoogleMaps.SnapToRoad.Query(request);

            return result.Status ?? throw new Exception("Status Is Null");
        }
    }
}
