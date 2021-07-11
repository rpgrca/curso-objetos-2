using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinDoorClosingState: CabinDoorState
    {
        private readonly ElevatorController _elevatorController;

        public CabinDoorClosingState(ElevatorController elevatorController) =>
            _elevatorController = elevatorController;

        public bool IsOpened() => false;

        public bool IsOpening() => false;

        public bool IsClosing() => true;

        public bool IsClosed() => false;

        public void CabinDoorClosedWhenWorkingAndCabinStopped() =>
            _elevatorController.CabinDoorClosedWhenWorkingAndCabinStoppedAndClosing();

        public void OpenCabinDoorWhenWorkingAndCabinStopped() =>
            _elevatorController.OpenCabinDoorWhenWorkingAndCabinStoppedAndDoorClosing();

        public void CloseCabinDoorWhenWorkingAndCabinStopped() => throw new Exception();

        public void Accept(CabinDoorStateVisitor visitor) =>
            visitor.VisitCabinDoorClosing(this);
    }
}