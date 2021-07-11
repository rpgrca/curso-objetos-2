namespace ElevatorConsole_Exercise.Logic
{
    public class CabinDoorOpeningState: CabinDoorState
    {
        private readonly ElevatorController _elevatorController;

        public CabinDoorOpeningState(ElevatorController elevatorController) =>
            _elevatorController = elevatorController;

        public void CabinDoorClosedWhenWorkingAndCabinStopped() =>
            _elevatorController.CabinDoorClosedWhenWorkingAndCabinStoppedAndCabinDoorOpening();

        public bool IsClosed() => false;

        public bool IsClosing() => false;

        public bool IsOpened() => false;

        public bool IsOpening() => true;

        public void OpenCabinDoorWhenWorkingAndCabinStopped() =>
            _elevatorController.OpenCabinDoorWhenWorkingAndCabinStoppedAndCabinDoorOpening();

        public void CloseCabinDoorWhenWorkingAndCabinStopped() =>
            _elevatorController.CloseCabinDoorWhenWorkingAndCabinStoppedAndCabinDoorOpening();

        public void Accept(CabinDoorStateVisitor visitor) => visitor.VisitCabinDoorOpening(this);
    }
}