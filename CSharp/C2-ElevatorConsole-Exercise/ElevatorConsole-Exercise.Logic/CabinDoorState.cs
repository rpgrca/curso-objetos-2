namespace ElevatorConsole_Exercise.Logic
{
    public interface CabinDoorState
    {
        bool IsOpened();
        bool IsOpening();
        bool IsClosing();
        bool IsClosed();
        void CabinDoorClosedWhenWorkingAndCabinStopped();
        void OpenCabinDoorWhenWorkingAndCabinStopped();
        void CloseCabinDoorWhenWorkingAndCabinStopped();
        void Accept(CabinDoorStateVisitor visitor);
    }
}