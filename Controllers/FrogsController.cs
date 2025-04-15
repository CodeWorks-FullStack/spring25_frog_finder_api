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
      return Ok(frogs); // 200
    }
    catch (Exception error)
    {
      return BadRequest(error.Message); // 400
    }
  }

  [HttpGet("{frogId}")] // .get('/:frogId', this.GetFrogById)
  public ActionResult<Frog> GetFrogById(int frogId) // request.params.frogId
  {
    try
    {
      Frog frog = _frogsService.GetFrogById(frogId);
      return Ok(frog);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpDelete("{frogId}")]
  public ActionResult<string> DeleteFrog(int frogId)
  {
    try
    {
      _frogsService.DeleteFrog(frogId);
      return Ok("Frog was deleted!");
    }
    catch (Exception error)
    {
      return BadRequest(error.Message); // next(error)
    }
  }

  [HttpPost]
  public ActionResult<Frog> CreateFrog([FromBody] Frog frogData)
  {
    try
    {
      Frog frog = _frogsService.CreateFrog(frogData);
      return Ok(frog);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message); // next(error)
    }
  }
}