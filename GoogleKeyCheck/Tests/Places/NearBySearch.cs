using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using System;

namespace GoogleKeyCheck.Tests.Places
{
    class NearBySearch : BaseTest
    {
        public NearBySearch()
        {
            this.Api = "Places/Search";
        }

        public override Status RunTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 1000,
                Type = SearchPlaceType.School
            };

            var response = GooglePlaces.NearBySearch.Query(request);
            return response.Status ?? throw new Exception("Status Is Null");
        }
    }
}
