# WAYWT Aggregator (Back End API)

WAYWT ("What Are You Wearing Today") Aggregator is a tool to enable users to filter through previous posts on r/malefashionadvice's WAYWT threads. [Hosted Demo](https://waywt.netlify.app/)

<p align="center">
  <img src="https://i.imgur.com/4layLOg.gif"  />
    <img src="https://i.imgur.com/OHvNSDF.gif"  />
</p>
<figcaption align = "center"><b>The left gif demonstrates how the results can be viewed for simple information, such as the dress styles of the post. The username and location of the poster is viewable, and clicking the image will take the user to the original post on Reddit.  The right gif demonstrates the filter in action. Currently the user can filter by styles, username, measurements, and seasonal color.</b></figcaption>
<br/><br/>

## The Code
The back end is built with C#, using the ASP.NET framework with a MongoDB database. The back-end is basically the simplest possible API I could create with .NET, and I used this project as a means to familiarise myself with the C#/.NET environment. 

### Database
#### Collections (Tables)
There are two collections. One is the SessionsLog, which creates a sessionId when a user visits the site. This is then sent to the front-end, where it is stored and added to each interval update. Each interval update sends an "action" description, which describes the user's activity.

The below table shows the action log, which includes the "sessionId", and also the "action", and the "localTimestamp" (indicating when the action was executed).

![UserActionLog Collection](https://i.imgur.com/7gcMHiI.png)
### Controllers
The controller gains access to the two database collections (tables) "SessionsLog" and "UserActionLog" via the `_sessionService` and the `_userActionLogService`. It then fires async methods from the API's session classes.

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
    
    //[HttpGet("sessions")]
    
    public async Task<List<Session>> GetSessions() =>
    
    await _sessionService.GetAsync();
    ...
