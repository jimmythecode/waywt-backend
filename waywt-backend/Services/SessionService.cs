using waywt_backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace waywt_backend.Services;

public class SessionService: ISessionService
{
    private readonly IMongoCollection<Session> _sessionCollection;
    public SessionService(IWaywtDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _sessionCollection = database.GetCollection<Session>(settings.SessionsCollectionName);
    }

    public async Task<List<Session>> GetAsync() =>
        await _sessionCollection.Find(_ => true).ToListAsync(); // Select all documents (aka records/rows)

    public async Task<Session?> GetAsync(string id) =>
        await _sessionCollection.Find(x => x.Id == id).FirstOrDefaultAsync(); // Select with this ID

    public async Task CreateAsync(Session newSession) =>
       await _sessionCollection.InsertOneAsync(newSession); // Insert a new document/record/row

    public async Task UpdateAsync(string id, Session updatedSession) =>
        await _sessionCollection.ReplaceOneAsync(x => x.Id == id, updatedSession); // Update with this ID

    public async Task RemoveAsync(string id) =>
        await _sessionCollection.DeleteOneAsync(x => x.Id == id); // Delete with this ID.

    internal Task CreateAsync(Session.Incoming sessionObjects)
    {
        throw new NotImplementedException();
    }
}