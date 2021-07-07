using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinMovingState: CabinState
    {
        private readonly ElevatorController _elevatorController;

        public CabinMovingState(ElevatorController elevatorController) {
            _elevatorController = elevatorController;
        }

        public void cabinDoorClosedWhenWorking() {
            _elevatorController.cabinDoorClosedWhenWorkingAndCabinMoving();
        }

        public bool isMoving() {
            return true;
        }

        public bool isStopped() {
            return false;
        }

        public void cabinDoorOpenedWhenWorking() {
            throw new Exception();
        }

        public void openCabinDoorWhenWorking() {
            _elevatorController.openCabinDoorWhenWorkingAndCabinMoving();
        }

        public bool isWaitingForPeople() {
            return false;
        }

        public void closeCabinDoorWhenWorking() {
            _elevatorController.closeCabinDoorWhenWorkingAndCabinMoving();
        }

        public void waitForPeopleTimedOutWhenWorking() {
            throw new Exception();
        }

        public void accept(CabinStateVisitor visitor) {
            visitor.visitCabinMoving(this);
        }
    }
}