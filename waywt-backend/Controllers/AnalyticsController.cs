using Microsoft.AspNetCore.Mvc;
using System.Net;
using waywt_backend.Models;
using waywt_backend.Services;

namespace waywt_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly IUserActionLogService _userActionLogService;

        public AnalyticsController(ISessionService sessionService, IUserActionLogService userActionLogService)
        {
            _sessionService = sessionService;
            _userActionLogService = userActionLogService;
        }

        [HttpGet]
        public async Task<List<Session>> Get() =>
            await _sessionService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Session>> Get(string id)
        {
            var visitorsUserAgentLog = await _sessionService.GetAsync(id);

            if (visitorsUserAgentLog is null)
            {
                return NotFound();
            }

            return visitorsUserAgentLog;
        }

        // Create a new Session document.
        [HttpPost("initial")]
        public async Task<IActionResult> PostInitial(Session newSession)
        {
            if (newSession == null)
            {
                return BadRequest();
            }

            await _sessionService.CreateAsync(newSession); // Fires the database call in SessionService.cs to create a new Session document/record.

            return CreatedAtAction(nameof(Get), new { id = newSession.Id }, newSession); // this uses the Get() method we defined above to retrieve the added document/record from the database. The second argument is the id search param, the third argument is the object to retrieve the id search param from.
        }

        //Create a new UserActionLog document.
        [HttpPost("intervalsingle")]
        public async Task<IActionResult> PostSingleUserActionLog(UserActionLog newUserActionLog)
        {
            if (newUserActionLog == null)
            {
                return BadRequest();
            }

            await _userActionLogService.CreateAsync(newUserActionLog); // Fires the database call in SessionService.cs to create a new Session document/record.

            return CreatedAtAction(nameof(Get), new { id = newUserActionLog.Id }, newUserActionLog); // this uses the Get() method we defined above to retrieve the added document/record from the database. The second argument is the id search param, the third argument is the object to retrieve the id search param from.
        }

        // Create several UserActionLog documents.
        [HttpPost("interval")]
        public async Task<IActionResult> PostInterval(IEnumerable<UserActionLog> listOfLogs)
        {
            if (listOfLogs == null)
            {
                return BadRequest();
            }

            await _userActionLogService.CreateManyAsync(listOfLogs); // Fires the database call in SessionService.cs to create a new Session document/record.

            return CreatedAtAction(nameof(Get), new { }, listOfLogs); // this uses the Get() method we defined above to retrieve the added document/record from the database. The second argument is the id search param, the third argument is the object to retrieve the id search param from.
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Session updatedSession)
        {
            var visitorsUserAgentLog = await _sessionService.GetAsync(id);

            if (visitorsUserAgentLog is null)
            {
                return NotFound();
            }

            updatedSession.Id = visitorsUserAgentLog.Id;

            await _sessionService.UpdateAsync(id, updatedSession);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var sessionLog = await _sessionService.GetAsync(id);

            if (sessionLog is null)
            {
                return NotFound();
            }

            await _sessionService.RemoveAsync(sessionLog.Id);

            return NoContent();
        }
    }
}
