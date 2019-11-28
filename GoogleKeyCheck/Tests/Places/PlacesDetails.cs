using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Details.Request;
using System;
using System.Linq;

namespace GoogleKeyCheck.Tests.Places
{
    sealed class PlacesDetails : BaseTest
    {
        public PlacesDetails()
        {
            this.Api = "Places";
        }

        public override Status RunTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "jagtvej 2200 Kшbenhavn"
            };

            var response = GooglePlaces.AutoComplete.Query(request);
            var request2 = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault()
            };

            var response2 = GooglePlaces.Details.Query(request2);
            return response2.Status ?? throw new Exception("Status Is Null");
        }
    }
}
