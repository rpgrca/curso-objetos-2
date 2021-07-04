namespace ElevatorExercise.Logic
{
    public class MovingCabin : CabinState
    {
        private readonly Cabin _cabin;

        public MovingCabin(Cabin cabin) => _cabin = cabin;

        public bool IsStopped() => false;
        public bool IsMoving() => true;

        public void OpenDoor() => _cabin.OpenDoorWhenCabinIsMoving();
    }
}