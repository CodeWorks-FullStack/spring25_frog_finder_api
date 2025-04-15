
namespace frog_finder_api.Repositories;
// NOTE repository layer is solely responsible for interacting with our database 
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
    // NOTE Query is a method used to select rows out of our tables. The type argument passed to Query (Query<T>) is what dapper will map each row of data into
    // NOTE Query will use our sql statement (1st argument) to query our database
    // NOTE dapper returns an IEnumerable by default, but we can convert that into a List by calling .ToList() 
    List<Frog> frogs = _db.Query<Frog>(sql).ToList();
    return frogs;
  }

  public Frog GetFrogById(int frogId)
  {
    // 🛑 DO NOT INTERPOLATE VALUES INTO YOUR SQL STRINGS
    // 💉opens us up for sql injection attacks
    // string sql = $"SELECT * FROM frogs WHERE id = {frogId};"; 

    // NOTE dapper will safely insert sanitized values into our sql statement for us 
    string sql = "SELECT * FROM frogs WHERE id = @frogId;";
    // NOTE dapper will see that we used an '@' sign in our sql statement, and look through the object that we pass it (2nd argument) for that key:value pair 
    // NOTE SingleOrDefault will convert the row into the single type we passed to Query as the type argument. If no rows are present after the query is run, it will return null. If there is more than one row present, it will throw an error
    //                                   { frogId: 2 }
    Frog frog = _db.Query<Frog>(sql, new { frogId = frogId }).SingleOrDefault();
    return frog;
  }

  public void DeleteFrog(int frogId)
  {
    string sql = "DELETE FROM frogs WHERE id = @frogId;";
    // NOTE execute runs our sql statement against our database and returns how many rows were affected by it
    //                                      { frogId: 2 }
    int rowsAffected = _db.Execute(sql, new { frogId });

    if (rowsAffected == 1)
    {
      return;
    }

    if (rowsAffected == 0)
    {
      throw new Exception("0 frogs have been deleted, and that is bad");
    }

    if (rowsAffected > 1)
    {
      throw new Exception($"{rowsAffected} frogs have been deleted, and that is really bad");
    }
  }

  public Frog CreateFrog(Frog frogData)
  {
    // NOTE @ allows us to make a multi line string
    // NOTE for this sql statement, we create a frog and then immediately select out the new frog
    // NOTE these are two separate sql statements in this string (INSERT and SELECT)
    string sql = @"
    INSERT INTO 
    frogs (name, is_single, img_url, age)
    VALUES(@Name, @IsSingle, @ImgUrl, @Age);
    
    SELECT * FROM frogs WHERE id = LAST_INSERT_ID();";

    Frog frog = _db.Query<Frog>(sql, frogData).SingleOrDefault();
    return frog;
  }
}