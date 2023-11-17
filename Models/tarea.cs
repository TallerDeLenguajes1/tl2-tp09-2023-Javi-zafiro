namespace modelosParaKamba;
 

 enum EstadoTarea
 {
    Ideas,
    ToDo,
    Doing,
    Review,
    Done
 }
public class tarea
{
    private int id;
    private string nombre;
    private string descripcion;
    private string color;
    private EstadoTarea estado;
}