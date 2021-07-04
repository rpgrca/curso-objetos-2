using System;

namespace ElevatorExercise.Logic
{
    public class Cabin
    {
        private CabinState _state;
        private readonly Door _door;
        private readonly ElevatorController _elevatorController;
        private int _cabinFloorNumber;

        public Cabin(ElevatorController elevatorController)
        {
            _elevatorController = elevatorController;
            _door = new Door(this);
            _cabinFloorNumber = 0;
            Stop();
        }

        internal bool IsStopped() => _state.IsStopped();

        internal bool IsMoving() => _state.IsMoving();

        public void Stop() => _state = new StoppedCabin(this);

        public void Move() => _state = new MovingCabin(this);

        public bool IsDoorOpened() => _door.IsOpened();

        public bool IsDoorOpening() => _door.IsOpening();

        public bool IsDoorClosed() => _door.IsClosed();

        public bool IsDoorClosing() => _door.IsClosing();

        public void CloseDoor() => _state.CloseDoor();

        public void OpenDoor() => _state.OpenDoor();

        public void OnClosedDoor() => _door.OnClosed();

        public void DoorOpened() => _door.OnOpened();

        public void OnArrivingAt(int aFloorNumber)
        {
            if (_cabinFloorNumber + 1 != aFloorNumber)
            {
                throw new ElevatorEmergency("Sensor de cabina desincronizado");
            }

            _cabinFloorNumber = aFloorNumber;
            if (_elevatorController.MustStopOnFloor(aFloorNumber))
            {
                _elevatorController.ReachedFloor(aFloorNumber);
                Stop();
                OpenDoor();
            }
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
            // Cannot open the door while the cabin is moving, do nothing
        }

        internal void OpenDoorWhileCabinIsStopped() => _door.Open();

        internal void CloseDoorWhileCabinIsMoving()
        {
            //Cannot close the door while cabin is moving, should already be closed
        }

        internal void CloseDoorWhileCabinIsStopped() => _door.Close();

        public int FloorNumber() => _cabinFloorNumber;
    }
}