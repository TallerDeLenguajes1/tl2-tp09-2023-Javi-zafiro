using modelosParaKamba;
namespace repositorioParaKamba;

public interface ITableroRepository
{
    public tablero CrearTablero();
    public void ModificarTablero(int idTablero, tablero tab);
    public tablero ObtenerTablero(int idTablero);
    public List<tablero> ListarTableros();
    public List<tablero> ListarTablerosDeUsuario(int idUsuario);
    public void BorrarTablero(int idTablero);
}