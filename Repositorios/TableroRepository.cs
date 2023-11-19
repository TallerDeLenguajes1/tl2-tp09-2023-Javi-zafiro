using modelosParaKamba;
using System.Data.SQLite;

namespace repositorioParaKamba;

public class TableroRepository : ITableroRepository
{
    private string cadenaConexion="Data Source=DB/kamba.db;Cache=Shared";
    public void CrearTablero(tablero tab){
        var query = "INSERT INTO tablero (id_usuario_asignado, nombre, descripcion) VALUES (@idusu, @nombre, @descripcion);";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command= new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@idusu", tab.IdUsuariPropietario));
            command.Parameters.Add(new SQLiteParameter("@nombre", tab.Nombre));
            command.Parameters.Add(new SQLiteParameter("@descripcion", tab.Descripcion));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void ModificarTablero(int idTablero, tablero tab){
        var query = "UPDATE tablero SET id_usuario_asignado=@idusu, nombre = @nombre, descripcion = @descripcion WHERE id = @idtablero;";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command= new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id_usuario_asignado", tab.IdUsuariPropietario));
            command.Parameters.Add(new SQLiteParameter("@nombre", tab.Nombre));
            command.Parameters.Add(new SQLiteParameter("@descripcion", tab.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@idtablero", idTablero));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public tablero ObtenerTablero(int idTablero){
        var tab = new tablero();
        var query="SELECT * FROM tablero WHERE id= @idtablero;";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command= new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@idtablero", idTablero));
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while(reader.Read()){
                    tab.Id=Convert.ToInt32(reader["id"]);
                    tab.IdUsuariPropietario=Convert.ToInt32(reader["id_usuario_asignado"]);
                    tab.Nombre=reader["nombre"].ToString();
                    tab.Descripcion=reader["descripcion"].ToString();
                }
            }
            connection.Close();
        }
        return(tab);
    }
    public List<tablero> ListarTableros(){}
    public List<tablero> ListarTablerosDeUsuario(int idUsuario){}
    public void BorrarTablero(int idTablero){}
}