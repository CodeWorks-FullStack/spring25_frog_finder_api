

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

  public Frog GetFrogById(int frogId)
  {
    // string sql = $"SELECT * FROM frogs WHERE id = {frogId};"; 💉opens us up for sql injection attacks

    string sql = "SELECT * FROM frogs WHERE id = @frogId;";
    //                                   { frogId: 2 }
    Frog frog = _db.Query<Frog>(sql, new { frogId = frogId }).SingleOrDefault();
    return frog;
  }

  internal void DeleteFrog(int frogId)
  {
    string sql = "DELETE FROM frogs WHERE id = @frogId;";
    //                                      { frogId: 2 }
    int rowsAffected = _db.Execute(sql, new { frogId });

    if (rowsAffected == 1)
    {
      return;
    }

    if (rowsAffected == 0)
    {
      throw new Exception($"Invalid id: {frogId}");
    }

    if (rowsAffected > 1)
    {
      throw new Exception($"{rowsAffected} frogs have been deleted, and that is bad");
    }
  }
}