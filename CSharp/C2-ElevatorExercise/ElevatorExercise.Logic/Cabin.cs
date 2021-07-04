using System;

namespace ElevatorExercise.Logic
{
    public class Cabin
    {
        private CabinState _cabinState;
        private readonly Door _door;

        public Cabin()
        {
            _door = new Door();
            Stop();
        }

        internal bool IsStopped() => _cabinState.IsStopped();

        internal bool IsMoving() => _cabinState.IsMoving();

        public void Stop()
        {
            _cabinState = new StoppedCabin();
        }

        public void Move() => _cabinState = new MovingCabin();

        public bool IsDoorOpened() => _door.IsOpened();

        public bool IsDoorOpening() => _door.IsOpening();

        public bool IsDoorClosed() => _door.IsClosed();

        public bool IsDoorClosing() => _door.IsClosing();

        public void CloseDoor() => _door.Close();

        public void OpenDoor() => _door.Open();

        public void DoorClosed() => _door.Closed();

        public void DoorOpened() => _door.Opened();
    }
}