namespace Risk.Api.Adpaters
{
    public class MongoConfiguration
    {
        public string BaseUrl
        {
            get { return "mongodb://localhost"; }
        }

        public string Database
        {
            get { return "rajDev"; }
        }
    }
}