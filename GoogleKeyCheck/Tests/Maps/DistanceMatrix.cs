using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using System;

namespace GoogleKeyCheck.Tests.Maps
{
    sealed class DistanceMatrix : BaseTest
    {
        public DistanceMatrix()
        {
            this.Api = "Maps";
        }

        public override Status RunTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[] { new Location(40.7141289, -73.9614074) },
                Destinations = new[] { new Location("185 Broadway Ave, Manhattan, NY, USA") }
            };
            var response = GoogleMaps.DistanceMatrix.Query(request);

            return response.Status ?? throw new Exception("Status Is Null");
        }
    }
}
