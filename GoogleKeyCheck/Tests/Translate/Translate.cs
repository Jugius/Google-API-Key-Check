using GoogleApi;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Translate.Request;
using System;

namespace GoogleKeyCheck.Tests.Translate
{
    sealed class Translate : BaseTest
    {
        public Translate()
        {
            this.Api = "Translate";
        }

        public override GoogleApi.Entities.Common.Enums.Status RunTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Source = Language.English,
                Target = Language.Danish,
                Qs = new[] { "Hello World" }
            };

            var result = GoogleTranslate.Translate.Query(request);
            return result.Status ?? throw new Exception("Status Is Null");
        }
    }
}
