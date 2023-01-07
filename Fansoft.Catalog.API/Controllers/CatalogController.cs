using Fansoft.Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fansoft.Catalog.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogController : ControllerBase
{

    private static List<CatalogItem> _items = new List<CatalogItem>{
                new CatalogItem {Id= 1, Name = "Camiseta Azul", Description = "Camisa confortável", Price = 80m},
                new CatalogItem{Id= 2, Name = "Caneta Azul",  Description = "Caneta baratinha", Price = 2.5m},
                new CatalogItem{Id= 3, Name = "Mouse Microsoft", Description = "Mouse confortavel", Price = 280m},
                new CatalogItem {Id= 4, Name = "Caneca Dev", Description = "Caneca de café para os devs", Price = 50m}
            };

    [HttpGet]
    public ActionResult<IEnumerable<CatalogItemVM>> GetItems()
    {
        // var result = new List<CatalogItemVM>();

        // foreach (var item in _items)
        // {
        //     result.Add(new CatalogItemVM{
        //         Id = item.Id,
        //         Name = item.Name,
        //         Description = item.Description,
        //         Price = item.Price
        //     });
        // }


        var result = _items.Select(item => new CatalogItem
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price
        });
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetItemById")]
    public ActionResult<CatalogItemVM> GetItemById(int id)
    {
        var result = _items.FirstOrDefault(x => x.Id == id);

        if (result is null) return NotFound();

        return Ok(new CatalogItemVM {
            Id = result.Id, Name= result.Name, Description = result.Description, Price = result.Price
        });
    }

    [HttpPost]
    public ActionResult<CatalogItem> AddItem([FromBody]CatalogItemForCreationVM model) {

        var id = _items.OrderBy(x=>x.Id).Last().Id + 1;

        var data = new CatalogItem {
            Id = id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price
        };

        _items.Add(data);

        return CreatedAtRoute("GetItemById", new {id = id}, data);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody]CatalogItemForUpdateVM model) {

        //if (!ModelState.IsValid) return BadRequest(ModelState);

        var item = _items.FirstOrDefault(x=>x.Id == id);

        if (item is null) {
            ModelState.AddModelError("id", "CatalogItem not found");
            return ValidationProblem();
        }

        item.Name = model.Name;
        item.Description = model.Description;
        item.Price = model.Price;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id) {
        var item = _items.FirstOrDefault(x=>x.Id == id);

         if (item is null) {
            ModelState.AddModelError("id", "CatalogItem not found");
            return ValidationProblem();
        }

        _items.Remove(item);

        return NoContent();

    }


}
