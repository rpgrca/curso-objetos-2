namespace ElevatorExercise.Logic
{
    public class IdleElevator : ElevatorState
    {
        private readonly ElevatorController _elevator;

        public IdleElevator(ElevatorController elevator) => _elevator = elevator;

        public bool IsIdle() => true;

        public bool IsWorking() => false;

        public void goUpPushedFromFloor(int aFloorNumber) => _elevator.goUpPushedFromFloorWhileIdle(aFloorNumber);

        public void DoorOpened() => _elevator.OpenedDoorWhenIdle();

        public void CloseDoor() => _elevator.CloseDoorWhenIdle();
    }
}