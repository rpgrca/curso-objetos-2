namespace ElevatorExercise.Logic
{
    public class WorkingElevator : ElevatorState
    {
        private readonly ElevatorController _elevator;

        public WorkingElevator(ElevatorController elevator) => _elevator = elevator;

        public bool IsIdle() => false;

        public bool IsWorking() => true;

        public void goUpPushedFromFloor(int aFloorNumber) => _elevator.goUpPushedFromFloorWhileWorking(aFloorNumber);

        public void DoorOpened() => _elevator.OpenedDoorWhenWorking();

        public void CloseDoor() => _elevator.CloseDoorWhenWorking();
    }
}