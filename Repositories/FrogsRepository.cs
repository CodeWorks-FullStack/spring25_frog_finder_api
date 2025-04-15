namespace frog_finder_api.Repositories;
// NOTE 
public class FrogsRepository
{
  public FrogsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db; // dbContext

  public List<Frog> GetAllFrogs()
  {
    string sql = "SELECT * FROM frogs;";

    // NOTE dapper is our ORM for interacting with our sql database
    List<Frog> frogs = _db.Query<Frog>(sql).ToList();
    return frogs;
  }
}