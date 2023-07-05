namespace HelloRest.Services;

public class InMemoryGlassesService : IGlassesService
{
  private readonly Dictionary<int, Models.Glasses> Glasses = new Dictionary<int, Models.Glasses>();
  private Utils.IDGenerator IDGenerator = new Utils.IDGenerator();

  private int NextID
  {
    get
    {
      var (id, newGeneartor) = IDGenerator.Next();
      IDGenerator = newGeneartor;
      return id;
    }
  }

  public InMemoryGlassesService() { }

  public InMemoryGlassesService(List<Models.Glasses> glasses)
  {
    this.Glasses = glasses.Select(glasses => glasses).ToDictionary(_ => NextID);
  }

  public IEnumerable<Models.Glasses> GetAll() => Glasses.Values.ToList();

  public Models.Glasses? Get(int id)
  {
    Glasses.TryGetValue(id, out Models.Glasses? glasses);
    return glasses;
  }

  public (int, Models.Glasses) Add(Models.NewGlasses glasses)
  {
    int id = NextID;
    Models.Glasses newGlasses = new Models.Glasses(ID: id, Name: glasses.Name, Color: glasses.Color, Shape: glasses.Shape);
    Glasses[id] = newGlasses;
    return (id, newGlasses);
  }

  public bool Update(int id, Models.UpdateGlasses glasses)
  {
    Glasses.TryGetValue(id, out Models.Glasses? current);
    if (current == null) return false;

    Glasses[id] = current with { Name = current.Name, Color = current.Color, Shape = current.Shape };
    return true;
  }

  public bool Delete(int id) => Glasses.Remove(id);
}
