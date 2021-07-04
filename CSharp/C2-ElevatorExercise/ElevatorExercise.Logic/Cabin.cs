namespace ElevatorExercise.Logic
{
    public class Cabin
    {
        private CabinState _state;
        private readonly Door _door;
        private readonly ElevatorController _elevatorController;

        public Cabin(ElevatorController elevatorController)
        {
            _elevatorController = elevatorController;
            _door = new Door(this);
            Stop();
        }

        internal bool IsStopped() => _state.IsStopped();

        internal bool IsMoving() => _state.IsMoving();

        public void Stop() => _state = new StoppedCabin(this);

        public void Move() => _state = new MovingCabin(this);

        public bool IsDoorOpened() => _door.IsOpened();

        public bool IsIdle() => _door.IsOpened();

        public bool IsDoorOpening() => _door.IsOpening();

        public bool IsDoorClosed() => _door.IsClosed();

        public bool IsDoorClosing() => _door.IsClosing();

        public void CloseDoor() => _door.Close();

        public void OpenDoor() => _state.OpenDoor();

        public void OnClosedDoor()
        {
            if (_door.IsClosed())
            {
                throw new ElevatorEmergency("Sensor de puerta desincronizado");
            }

            _door.OnClosed();
        }

        public void DoorOpened() => _door.OnOpened();

        public void OnArriving()
        {
            _elevatorController.ReachedFloorCorrectly();
            Stop();
            OpenDoor();
        }

        public void OnDeparting()
        {
            OnClosedDoor();
            Move();
        }

        public void OnDoorClosed()
        {
            _elevatorController.OnDoorClosed();
            OnDeparting();
        }

        internal void OpenDoorWhenCabinIsMoving()
        {
            // Cannot open the door while the cabin is moving
        }

        internal void OpenDoorWhileCabinIsStopped() => _door.Open();
    }
}