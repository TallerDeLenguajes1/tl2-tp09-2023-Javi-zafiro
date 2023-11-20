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
}
