namespace waywt_backend.Models
{
    public interface IUserActionLogService
    {
        List<UserActionLog> Get();
        UserActionLog Get(string id);
        UserActionLog Create(UserActionLog userActionLog);
        Task<UserActionLog> CreateAsync(UserActionLog userActionLog);
        Task<IEnumerable<UserActionLog>> CreateManyAsync(IEnumerable<UserActionLog> userActionLogs);
        void Update(string id, UserActionLog userActionLog);
        void Remove(string id);
    }
}
