namespace ElevatorExercise.Logic
{
    public class Cabin
    {
        private CabinState _cabinState;

        public Cabin() => _cabinState = new StoppedCabin();

        internal bool IsStopped() => _cabinState.IsStopped();

        internal bool IsMoving() => _cabinState.IsMoving();

        public void Stop() => _cabinState = new StoppedCabin();

        public void Move() => _cabinState = new MovingCabin();
    }
}