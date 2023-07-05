using Microsoft.AspNetCore.Mvc;

namespace HelloRest.Controllers;

[ApiController]
[Route("[controller]")]
public class GlassesController : ControllerBase
{
  private readonly Services.IGlassesService GlassesService;

  public GlassesController(Services.IGlassesService glassesService)
  {
    this.GlassesService = glassesService;
  }

  [HttpGet(Name = "GetGlasses")]
  public IActionResult GetAll()
  {
    return Ok(GlassesService.GetAll());
  }

  [HttpGet("{id}")]
  public IActionResult Get(int id)
  {
    Models.Glasses? glasses = GlassesService.Get(id);
    if (glasses == null) return NotFound();
    return Ok(glasses);
  }

  [HttpPost]
  public IActionResult Add(Models.NewGlasses glasses)
  {
    var (id, newGlasses) = GlassesService.Add(glasses);
    return CreatedAtAction(nameof(Get), new { id = id }, newGlasses);
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, Models.UpdateGlasses glasses)
  {
    bool updated = GlassesService.Update(id, glasses);
    if (!updated) return NotFound();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    bool deleted = GlassesService.Delete(id);
    if (!deleted) return NotFound();
    return NoContent();
  }
}
