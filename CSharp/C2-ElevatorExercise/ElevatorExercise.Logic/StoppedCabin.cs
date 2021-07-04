namespace ElevatorExercise.Logic
{
    public class StoppedCabin : CabinState
    {
        public bool IsStopped() => true;
        public bool IsMoving() => false;
    }
}