namespace HelloRest.Utils;

public class IDGenerator
{
  private readonly int ID;

  public IDGenerator()
  {
    ID = 1;
  }

  private IDGenerator(int id)
  {
    this.ID = id;
  }

  public (int, IDGenerator) Next() => (ID, new IDGenerator(ID + 1));
}
