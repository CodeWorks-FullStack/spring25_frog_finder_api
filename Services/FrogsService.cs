
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

  public Frog GetFrogById(int frogId)
  {
    Frog frog = _repository.GetFrogById(frogId);

    if (frog == null)
    {
      throw new Exception($"Invalid frog id: {frogId}");
    }

    return frog;
  }

  public void DeleteFrog(int frogId)
  {
    _repository.DeleteFrog(frogId);
  }

  public Frog CreateFrog(Frog frogData)
  {
    Frog frog = _repository.CreateFrog(frogData);
    return frog;
  }
}

