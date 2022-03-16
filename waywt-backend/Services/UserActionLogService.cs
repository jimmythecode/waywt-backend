using waywt_backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace waywt_backend.Services;

public class UserActionLogService : IUserActionLogService
{
    private readonly IMongoCollection<UserActionLog> _userActionLogCollection;

    public UserActionLogService(IWaywtDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _userActionLogCollection = database.GetCollection<UserActionLog>(settings.UserActionLogCollectionName);
    }
    public UserActionLog Create(UserActionLog userActionLog)
    {
        _userActionLogCollection.InsertOne(userActionLog);
        return userActionLog;
    }

    public async Task<UserActionLog> CreateAsync(UserActionLog userActionLog)
    {
        await _userActionLogCollection.InsertOneAsync(userActionLog); // Insert a new document/record/row
        return userActionLog;
    }

    public async Task<IEnumerable<UserActionLog>> CreateManyAsync(IEnumerable<UserActionLog> userActionLogs)
    {
        await _userActionLogCollection.InsertManyAsync(userActionLogs); // Insert a new document/record/row
        return userActionLogs;
    }

    public List<UserActionLog> Get()
    {
        return _userActionLogCollection.Find(userActionLog => true).ToList();
    }

    public async Task<List<UserActionLog>> GetAsync() =>
        await _userActionLogCollection.Find(_ => true).ToListAsync(); // Select all documents (aka records/rows)

    public async Task<UserActionLog?> GetAsync(string id) =>
        await _userActionLogCollection.Find(x => x.Id == id).FirstOrDefaultAsync(); // Select with this ID

    public UserActionLog Get(string id)
    {
        return _userActionLogCollection.Find(userActionLog => userActionLog.Id == id).FirstOrDefault();
    }

    public void Remove(string id)
    {
        _userActionLogCollection.DeleteOne(userActionLog => userActionLog.Id == id);
    }

    public void Update(string id, UserActionLog userAgentLog)
    {
        _userActionLogCollection.ReplaceOne(userActionLog => userActionLog.Id == id, userAgentLog );
    }
}
