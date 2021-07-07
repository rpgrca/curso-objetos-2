using System;

namespace ElevatorConsole_Exercise.Logic
{
    class ElevatorControllerIdleState: ElevatorControllerState
    {
        private readonly ElevatorController _elevatorController;

        public ElevatorControllerIdleState(ElevatorController elevatorController) {
            _elevatorController = elevatorController;
        }

        public bool isIdle() {
            return true;
        }

        public void goUpPushedFromFloor(int aFloorNumber) {
            _elevatorController.goUpPushedFromFloorWhenIdle(aFloorNumber);
        }

        public bool isWorking() {
            return false;
        }

        public void cabindDoorClosed() {
            _elevatorController.cabinDoorClosedWhenIdle();
        }

        public void cabinOnFloor(int aFloorNumber) {
            _elevatorController.cabinOnFloorWhenIdle(aFloorNumber);
        }

        public void cabinDoorOpened() {
            throw new Exception();
        }

        public void openCabinDoor() {
            _elevatorController.openCabinDoorWhenIdle();
        }

        public void closeCabinDoor() {
            _elevatorController.closeCabinDoorWhenIdle();
        }

        public void waitForPeopleTimedOut() {
            throw new Exception();
        }
    }
}