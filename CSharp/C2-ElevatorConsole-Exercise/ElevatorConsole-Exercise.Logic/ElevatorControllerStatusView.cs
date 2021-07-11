namespace ElevatorConsole_Exercise.Logic
{
    public class ElevatorControllerStatusView: CabinStateVisitor, CabinDoorStateVisitor,
        Observer<CabinState>, Observer<CabinDoorState>
    {
        private string _cabinFieldModel;
        private string _cabinDoorFieldModel;

        public ElevatorControllerStatusView(ElevatorController elevatorController)
        {
            elevatorController.addCabinObserver(this);
            elevatorController.addCabinDoorObserver(this);
        }

        public void visitCabinDoorClosing(CabinDoorClosingState cabinDoorClosingState) =>
            _cabinDoorFieldModel = "Closing";

        public void visitCabinDoorClosed(CabinDoorClosedState cabinDoorClosedState) =>
            _cabinDoorFieldModel = "Closed";

        public void visitCabinDoorOpened(CabinDoorOpenedState cabinDoorOpenedState) =>
            _cabinDoorFieldModel = "Open";

        public void visitCabinDoorOpening(CabinDoorOpeningState cabinDoorOpeningState) =>
            _cabinDoorFieldModel = "Opening";

        public void visitCabinMoving(CabinMovingState cabinMovingState) =>
            _cabinFieldModel = "Moving";

        public void visitCabinStopped(CabinStoppedState cabinStoppedState) =>
            _cabinFieldModel = "Stopped";

        public void visitCabinWaitingPeople(CabinWaitingForPeopleState cabinWaitingForPeopleState) =>
            _cabinFieldModel = "Waiting People";

        public string cabinFieldModel() => _cabinFieldModel;

        public string cabinDoorFieldModel() => _cabinDoorFieldModel;

        public void Changed(CabinState visitor) => visitor.accept(this);

        public void Changed(CabinDoorState visitor) => visitor.accept(this);
    }
}