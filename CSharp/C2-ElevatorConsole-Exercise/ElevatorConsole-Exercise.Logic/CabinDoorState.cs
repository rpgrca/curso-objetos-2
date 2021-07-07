namespace ElevatorConsole_Exercise.Logic
{
    public interface CabinDoorState
    {
        bool isOpened();
        bool isOpening();
        bool isClosing();
        bool isClosed();
        void cabinDoorClosedWhenWorkingAndCabinStopped();
        void openCabinDoorWhenWorkingAndCabinStopped();
        void closeCabinDoorWhenWorkingAndCabinStopped();
        void accept(CabinDoorStateVisitor visitor);
    }
}
