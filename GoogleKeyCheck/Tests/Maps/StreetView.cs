using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.StreetView.Request;
using System;

namespace GoogleKeyCheck.Tests.Maps
{
    sealed class StreetView : BaseTest
    {
        public StreetView()
        {
            this.Api = "Maps";
        }

        public override Status RunTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                Location = new Location(60.170877, 24.942796)
            };

            var result = GoogleMaps.StreetView.Query(request);

            return result.Status ?? throw new Exception("Status Is Null");

        }
    }
}
