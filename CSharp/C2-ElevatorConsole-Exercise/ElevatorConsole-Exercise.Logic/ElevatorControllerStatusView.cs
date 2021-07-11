namespace ElevatorConsole_Exercise.Logic
{
    public class ElevatorControllerStatusView: CabinStateVisitor, CabinDoorStateVisitor,
        Observer<CabinState>, Observer<CabinDoorState>
    {
        private string _cabinFieldModel;
        private string _cabinDoorFieldModel;

        public ElevatorControllerStatusView(ElevatorController elevatorController)
        {
            elevatorController.AddCabinObserver(this);
            elevatorController.AddCabinDoorObserver(this);
        }

        public void VisitCabinDoorClosing(CabinDoorClosingState cabinDoorClosingState) =>
            _cabinDoorFieldModel = "Closing";

        public void VisitCabinDoorClosed(CabinDoorClosedState cabinDoorClosedState) =>
            _cabinDoorFieldModel = "Closed";

        public void VisitCabinDoorOpened(CabinDoorOpenedState cabinDoorOpenedState) =>
            _cabinDoorFieldModel = "Open";

        public void VisitCabinDoorOpening(CabinDoorOpeningState cabinDoorOpeningState) =>
            _cabinDoorFieldModel = "Opening";

        public void VisitCabinMoving(CabinMovingState cabinMovingState) =>
            _cabinFieldModel = "Moving";

        public void VisitCabinStopped(CabinStoppedState cabinStoppedState) =>
            _cabinFieldModel = "Stopped";

        public void VisitCabinWaitingPeople(CabinWaitingForPeopleState cabinWaitingForPeopleState) =>
            _cabinFieldModel = "Waiting People";

        public string CabinFieldModel() => _cabinFieldModel;

        public string CabinDoorFieldModel() => _cabinDoorFieldModel;

        public void Changed(CabinState visitor) => visitor.Accept(this);

        public void Changed(CabinDoorState visitor) => visitor.Accept(this);
    }
}