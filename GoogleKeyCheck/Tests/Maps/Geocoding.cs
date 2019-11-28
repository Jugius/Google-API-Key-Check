using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using System;

namespace GoogleKeyCheck.Tests.Maps
{
    sealed class Geocoding : BaseTest
    {
        public Geocoding()
        {
            this.Api = "Maps";
            //this.ApiClass = "Geokoding";
        }
        public override Status RunTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new GoogleApi.Entities.Common.Location(40.7141289, -73.9614074)
            };
            var response = GoogleMaps.LocationGeocode.Query(request);
            return response.Status ?? throw new Exception("Status Is Null");

        }
    }
}
