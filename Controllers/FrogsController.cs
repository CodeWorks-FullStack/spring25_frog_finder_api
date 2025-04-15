namespace frog_finder_api.Controllers;

// NOTE data annotations apply to the next definition
[ApiController]
[Route("api/frogs")] // super('api/frogs')
public class FrogsController : ControllerBase // extends BaseController
{
  // constructor
  // dependency injection 💉
  public FrogsController(FrogsService frogsService)
  {
    _frogsService = frogsService;
  }

  private readonly FrogsService _frogsService;

  [HttpGet("test")] // .get('/test', this.Test)
  public string Test()
  {
    return "Controller is working!"; // response.send('Controller is working!')
  }

  [HttpGet]
  // NOTE ActionResult denotes some kind of HttpResponse
  public ActionResult<List<Frog>> GetAllFrogs()
  {
    try
    {
      List<Frog> frogs = _frogsService.GetAllFrogs();
      return Ok(frogs);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}