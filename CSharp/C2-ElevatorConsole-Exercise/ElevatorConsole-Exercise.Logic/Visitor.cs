namespace ElevatorConsole_Exercise.Logic
{
    public interface Visitor<T>
    {
        void Accept(T visitor);
    }
}