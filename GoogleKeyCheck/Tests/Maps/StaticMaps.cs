using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using System;

namespace GoogleKeyCheck.Tests.Maps
{
    sealed class StaticMaps : BaseTest
    {
        public StaticMaps()
        {
            this.Api = "Maps";
        }

        public override Status RunTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(60.170877, 24.942796),
                ZoomLevel = 1
            };
            var result = GoogleMaps.StaticMaps.Query(request);
            return result.Status ?? throw new Exception("Status Is Null");
        }
    }
}
