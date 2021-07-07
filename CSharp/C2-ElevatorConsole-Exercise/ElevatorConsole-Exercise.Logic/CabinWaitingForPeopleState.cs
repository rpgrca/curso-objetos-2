using System;

namespace ElevatorConsole_Exercise.Logic
{
    public class CabinWaitingForPeopleState: CabinState
    {
        private readonly ElevatorController _elevatorController;

        public CabinWaitingForPeopleState(ElevatorController elevatorController) =>
            _elevatorController = elevatorController;

        public void cabinDoorClosedWhenWorking() => throw new Exception();

        public void cabinDoorOpenedWhenWorking() => throw new Exception();

        public bool isMoving() => throw new Exception();

        public bool isStopped() => false;

        public void openCabinDoorWhenWorking() => throw new Exception();

        public bool isWaitingForPeople() => true;

        public void waitForPeopleTimedOutWhenWorking() =>
            _elevatorController.waitForPeopleTimedOutWhenWorkingAndCabinWaitingForPeople();

        public void closeCabinDoorWhenWorking() =>
            _elevatorController.closeCabinDoorWhenWorkingAndCabinWaitingForPeople();

        public void accept(CabinStateVisitor visitor) => visitor.visitCabinWaitingPeople(this);
    }
}