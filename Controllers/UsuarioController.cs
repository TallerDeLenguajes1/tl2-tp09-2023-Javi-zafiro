using Microsoft.AspNetCore.Mvc;
using modelosParaKamba;
using repositorioParaKamba;

namespace controllersParaKamba;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioRepository usuarioRepository;
    public UsuarioController()
    {
        usuarioRepository = new UsuarioRepository();
    }

    [HttpPost("usuario")]
    public ActionResult<usuario> CrearUsuario(usuario usu)
    {
        if (usu==null)
        {
            return BadRequest("el objeto usuario es nulo");
        }
        usuarioRepository.CrearUsuario(usu);
        return Ok(usu);
    }

    [HttpGet("usuario")]
    public ActionResult<List<usuario>> ListarUsuarios()
    {
        var lista = new List<usuario>();
        lista= usuarioRepository.ListarUsuarios();
        return Ok(lista);
    }

    [HttpGet("usuario{id}")]
    public ActionResult<usuario> ObtenerUsuario(int id)
    {
        var user = new usuario();
        user = usuarioRepository.ObtenerUsuario(id);
        return Ok(user);
    }

    [HttpPut("usuario{id}/nombre")]
    public ActionResult<usuario> CambiarNombre(int id, usuario usu)
    {
        if (usu==null)
        {
            return BadRequest("el objeto usuario es nulo");
        }
        usuarioRepository.ModificarUsuario(id, usu);
        var user = new usuario();
        user = usuarioRepository.ObtenerUsuario(id);
        return Ok(user);
    }
}
