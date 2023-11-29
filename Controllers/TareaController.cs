using Microsoft.AspNetCore.Mvc;
using modelosParaKamba;
using repositorioParaKamba;

namespace controllersParaKamba;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    private readonly TareaRepository tareaRepository;
    public TareaController()
    {
        tareaRepository = new TareaRepository();
    }

    [HttpPost("tarea")]
    public ActionResult<tablero> CrearTarea(int idTab, tarea tar)
    {
        if (tar==null)
        {
            return BadRequest("el objeto usuario es nulo");
        }
        tareaRepository.CrearTarea(idTab, tar);
        return Ok(tar);
    }

    [HttpGet("tarea/usuario/{id}")]
    public ActionResult<List<tablero>> ListarTareasPorUsuario(int id)
    {
        var lista = new List<tarea>();
        lista= tareaRepository.ListarTareasPorUsuario(id);
        return Ok(lista);
    }
    [HttpGet("tarea/tablero/{id}")]
    public ActionResult<List<tablero>> ListarTareasPorTablero(int id)
    {
        var lista = new List<tarea>();
        lista= tareaRepository.ListarTareasPorTablero(id);
        return Ok(lista);
    }

    [HttpGet("tarea/{Estado}")]
    public ActionResult<int> CantidadTareasXEstado(EstadoTarea Estado)
    {
        int cantidad=0;
        var lista = new List<tarea>();
        lista=tareaRepository.ListarTodasTareas();
        foreach (var item in lista)
        {
            if (item.Estado== Estado)
            {
                cantidad++;
            }
        }
        return Ok(cantidad);
    }

    [HttpPut("tarea/{id}/nombre/{nombre}")]
    public ActionResult<tarea> CambiarNombre(string nombre, int id)
    {
        var tar = new tarea();
        tar = tareaRepository.ObtenerTarea(id);
        tar.Nombre=nombre;
        tareaRepository.ModificarTarea(id, tar);
        return Ok(tar);
    }

    [HttpPut("tarea/{id}/Estado/{Estado}")]
    public ActionResult<tarea> CambiarEstado(EstadoTarea Estado, int id)
    {
        var tar = new tarea();
        tar = tareaRepository.ObtenerTarea(id);
        tar.Estado=Estado;
        tareaRepository.ModificarTarea(id, tar);
        return Ok(tar);
    }

    [HttpDelete("tarea/{id}/Eliminar")]
    public ActionResult EliminarTarea(int id)
    {
        tareaRepository.BorrarTarea(id);
        return Ok("tarea eliminada");
    }
}
