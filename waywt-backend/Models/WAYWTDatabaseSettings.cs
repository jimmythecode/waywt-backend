namespace waywt_backend.Models
{
    public class WAYWTDatabaseSettings : IWaywtDatabaseSettings // Added this 7th March following tutorial
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string VisitorsUserAgentLogCollectionName { get; set; } = null!;
        public string SessionsCollectionName { get; set; } = null!;
        public string UserActionLogCollectionName { get; set; } = null!;
    }
}
