namespace frog_finder_api.Services;
// NOTE service is now responsible for business logic and talking to our repository layer
public class FrogsService
{
  public FrogsService(FrogsRepository repository)
  {
    _repository = repository;
  }
  private readonly FrogsRepository _repository;


  public List<Frog> GetAllFrogs()
  {
    List<Frog> frogs = _repository.GetAllFrogs();
    return frogs;
  }
}

