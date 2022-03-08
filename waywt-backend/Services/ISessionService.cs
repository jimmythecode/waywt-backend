using waywt_backend.Models;

namespace waywt_backend.Services
{
    public interface ISessionService
    {
        //List<Session> Get();
        //Session Get(string id);
        //Task<List<Session>> GetAll();
        //Session Create(Session session);
        //Task<Session> CreateAsync(Session session);
        //void Update(string id, Session session);
        //void Remove(string id);
        public Task<List<Session>> GetAsync();

        public Task<Session?> GetAsync(string id);

        public Task CreateAsync(Session newSession);

        public Task UpdateAsync(string id, Session updatedSession);

        public Task RemoveAsync(string id);

    }
}
