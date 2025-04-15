// NOTE namespace should be name of your application `.` folder your file is in
namespace frog_finder_api.Models;

// NOTE make sure your model supports all necessary columns from your sql table 
public class Frog
{
  public int Id { get; set; }
  public string Name { get; set; }
  // NOTE use upper pascal casing for your C# models
  public bool IsSingle { get; set; }
  public string ImgUrl { get; set; }
  public int Age { get; set; }
}