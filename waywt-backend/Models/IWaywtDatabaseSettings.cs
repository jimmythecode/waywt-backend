namespace waywt_backend.Models
{
    public interface IWaywtDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string VisitorsUserAgentLogCollectionName { get; set; }
        string SessionsCollectionName { get; set; }
        string UserActionLogCollectionName { get; set; }
    }
}
