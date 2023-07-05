namespace HelloRest.Services;

public interface IGlassesService
{
  IEnumerable<Models.Glasses> GetAll();
  Models.Glasses? Get(int id);
  (int, Models.Glasses) Add(Models.NewGlasses glasses);
  bool Update(int id, Models.UpdateGlasses glasses);
  bool Delete(int id);
}
