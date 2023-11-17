using modelosParaKamba;
namespace repositorioParaKamba;

public interface IUsuarioRepository
{
    public void CrearUsuario(usuario usu);
    public void ModificarUsuario(int id, usuario usu);
    public List<usuario> ListarUsuarios();
    public usuario ObtenerUsuario(int id);
    public void BorrarUsuario(int id);
}