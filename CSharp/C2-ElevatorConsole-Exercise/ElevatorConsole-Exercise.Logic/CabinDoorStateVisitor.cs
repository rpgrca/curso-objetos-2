namespace ElevatorConsole_Exercise.Logic
{
    public interface CabinDoorStateVisitor
    {
        void VisitCabinDoorClosing(CabinDoorClosingState cabindDoorClosingState);
        void VisitCabinDoorClosed(CabinDoorClosedState cabinDoorClosedState);
        void VisitCabinDoorOpened(CabinDoorOpenedState cabinDoorOpenedState);
        void VisitCabinDoorOpening(CabinDoorOpeningState cabinDoorOpeningState);
    }
}