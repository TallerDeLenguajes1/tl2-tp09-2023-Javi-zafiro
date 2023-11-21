using Microsoft.AspNetCore.Mvc;
using modelosParaKamba;
using repositorioParaKamba;

namespace controllersParaKamba;

[ApiController]
[Route("api/[controller]")]
public class TableroController : ControllerBase
{
    private readonly TableroRepository tableroRepository;
    public TableroController()
    {
        tableroRepository = new TableroRepository();
    }

    [HttpPost("tablero")]
    public ActionResult<tablero> CrearTablero(tablero tab)
    {
        if (tab==null)
        {
            return BadRequest("el objeto usuario es nulo");
        }
        tableroRepository.CrearTablero(tab);
        return Ok(tab);
    }

    [HttpGet("tableros")]
    public ActionResult<List<tablero>> ListarTableros()
    {
        var lista = new List<tablero>();
        lista= tableroRepository.ListarTableros();
        return Ok(lista);
    }

}
