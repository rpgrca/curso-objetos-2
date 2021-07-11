namespace ElevatorConsole_Exercise.Logic
{
    public interface Observer<T>
    {
        void Changed(T visitor);
    }
}