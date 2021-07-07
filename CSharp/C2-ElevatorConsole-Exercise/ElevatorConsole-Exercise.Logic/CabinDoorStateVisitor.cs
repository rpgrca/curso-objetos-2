namespace ElevatorConsole_Exercise.Logic
{
    public interface CabinDoorStateVisitor
    {
        void visitCabinDoorClosing(CabinDoorClosingState cabindDoorClosingState);
        void visitCabinDoorClosed(CabinDoorClosedState cabinDoorClosedState);
        void visitCabinDoorOpened(CabinDoorOpenedState cabinDoorOpenedState);
        void visitCabinDoorOpening(CabinDoorOpeningState cabinDoorOpeningState);
    }
}
