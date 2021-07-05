namespace ElevatorExercise.Logic
{
    public class StoppedCabin : CabinState
    {
        private readonly Cabin _cabin;

        public StoppedCabin(Cabin cabin) => _cabin = cabin;

        public bool IsStopped() => true;
        public bool IsMoving() => false;

        public void CloseDoor() => _cabin.CloseDoorWhileCabinIsStopped();

        public void OpenDoor() => _cabin.OpenDoorWhileCabinIsStopped();
    }
}