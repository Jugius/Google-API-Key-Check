namespace GoogleKeyCheck.Tests
{
    abstract class BaseTest
    {
        public string Api { get; set; }
        public string ApiClass => this.GetType().Name;
        public string ApiKey { get; set; }
        public abstract GoogleApi.Entities.Common.Enums.Status RunTest();
    }
}
