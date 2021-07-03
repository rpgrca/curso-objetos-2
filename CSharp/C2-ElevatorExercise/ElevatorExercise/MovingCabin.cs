namespace ElevatorExercise
{
    public class MovingCabin : CabinState
    {
        public bool IsStopped() => false;
        public bool IsMoving() => true;
    }
}
