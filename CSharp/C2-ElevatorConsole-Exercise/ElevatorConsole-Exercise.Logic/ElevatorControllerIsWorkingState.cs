namespace ElevatorConsole_Exercise.Logic
{
    internal class ElevatorControllerIsWorkingState: ElevatorControllerState
    {
        private readonly ElevatorController _elevatorController;

        public ElevatorControllerIsWorkingState(ElevatorController elevatorController) =>
            _elevatorController = elevatorController;

        public void GoUpPushedFromFloor(int aFloorNumber) =>
            _elevatorController.GoUpPushedFromFloorWhenWorking(aFloorNumber);

        public bool IsIdle() => false;

        public bool IsWorking() => true;

        public void CabindDoorClosed() =>
            _elevatorController.CabinDoorClosedWhenWorking();

        public void CabinOnFloor(int aFloorNumber) =>
            _elevatorController.CabinOnFloorWhenWorking(aFloorNumber);

        public void CabinDoorOpened() =>
            _elevatorController.CabinDoorOpenendWhenWorking();

        public void OpenCabinDoor() =>
            _elevatorController.OpenCabinDoorWhenWorking();

        public void WaitForPeopleTimedOut() =>
            _elevatorController.WaitForPeopleTimedOutWhenWorking();

        public void CloseCabinDoor() =>
            _elevatorController.CloseCabinDoorWhenWorking();
    }
}