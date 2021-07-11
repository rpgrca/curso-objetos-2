namespace ElevatorConsole_Exercise.Logic
{
    public interface CabinDoorState : Visitor<CabinDoorStateVisitor>
    {
        bool isOpened();
        bool isOpening();
        bool isClosing();
        bool isClosed();
        void cabinDoorClosedWhenWorkingAndCabinStopped();
        void openCabinDoorWhenWorkingAndCabinStopped();
        void closeCabinDoorWhenWorkingAndCabinStopped();
    }
}