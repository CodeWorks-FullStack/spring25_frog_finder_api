namespace frog_finder_api.Controllers;

[ApiController]
[Route("api/frogs")] // super('api/frogs')
public class FrogsController : ControllerBase // extends BaseController
{
  [HttpGet("test")] // .get('/test', this.Test)
  public string Test()
  {
    return "Controller is working!"; // response.send('Controller is working!')
  }
}