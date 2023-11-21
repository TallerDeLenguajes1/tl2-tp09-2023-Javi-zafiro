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

    [HttpGet("usuarioGet")]
    public ActionResult<usuario> ObtenerUsuario(int idUsuario)
    {
        var user = new usuario();
        user = usuarioRepository.ObtenerUsuario(idUsuario);
        return Ok(user);
    }

    [HttpPost("usuarioPost/nombre")]
    public ActionResult<usuario> CambiarNombre(int idUsuario, usuario usu)
    {
        if (usu==null)
        {
            return BadRequest("el objeto usuario es nulo");
        }
        usuarioRepository.ModificarUsuario(idUsuario, usu);
        var user = new usuario();
        user = usuarioRepository.ObtenerUsuario(idUsuario);
        return Ok(user);
    }
}
