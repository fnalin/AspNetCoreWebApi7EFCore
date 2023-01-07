using Microsoft.AspNetCore.Mvc;

namespace Fansoft.Catalog.API.Controllers;

// public class TesteController {
// public class Teste : ControllerBase {
[ApiController]
[Route("[controller]")]
public class Teste {
    [HttpGet("ping")]
    public string Ping()=> "pong";

    [HttpGet("object")]
    public JsonResult TesteObject() {
        return new JsonResult(
            new List<object> {
                new { id = 1, name = "Fabiano Nalin"},
                new { id = 2, name = "Priscila Mitui"},
            }
        );
    }
}
