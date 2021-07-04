using System.Collections.Generic;

namespace ElevatorExercise.Logic
{
    public class ElevatorController
    {
        private ElevatorState _state;

        private readonly Cabin _cabin;
        private readonly List<int> _floorQueue;
        private bool _waitingForPeople;

        public ElevatorController()
        {
            _state = new IdleElevator(this);
            _cabin = new Cabin(this);
            _floorQueue = new List<int>();
            _waitingForPeople = true;
        }

        //Elevator state
        public bool isIdle() => _state.IsIdle();

        public bool isWorking() => _state.IsWorking();

        //Door state
        public bool isCabinDoorOpened() => _cabin.IsDoorOpened();

        public bool isCabinDoorOpening() => _cabin.IsDoorOpening();

        public bool isCabinDoorClosed() => _cabin.IsDoorClosed();

        public bool isCabinDoorClosing() => _cabin.IsDoorClosing();

        //Cabin state
        public int cabinFloorNumber() => _cabin.FloorNumber();

        public bool isCabinStopped() => _cabin.IsStopped();

        public bool isCabinMoving() => _cabin.IsMoving();

        public bool isCabinWaitingForPeople() => _waitingForPeople;

        //Events
        public void goUpPushedFromFloor(int aFloorNumber) => _state.goUpPushedFromFloor(aFloorNumber);

        public void cabinOnFloor(int aFloorNumber) => _cabin.OnArrivingAt(aFloorNumber);

        public void cabinDoorClosed() => _cabin.OnDoorClosed();

        public void openCabinDoor() => _cabin.OpenDoor();

        public void cabinDoorOpened() => _state.DoorOpened();

        public void waitForPeopleTimedOut()
        {
            _waitingForPeople = false;
            _cabin.CloseDoor();
        }

        public void closeCabinDoor() => _state.CloseDoor();

        internal void ReachedTargetFloor()
        {
            _floorQueue.RemoveAt(0);
            _waitingForPeople = true;
        }

        internal void goUpPushedFromFloorWhileWorking(int aFloorNumber) => QueueFloor(aFloorNumber);

        private void QueueFloor(int aFloorNumber)
        {
            _floorQueue.Add(aFloorNumber);
            _floorQueue.Sort();
        }

        internal void goUpPushedFromFloorWhileIdle(int aFloorNumber)
        {
            _state = new WorkingElevator(this);

            QueueFloor(aFloorNumber);
            _waitingForPeople = false;
            _cabin.CloseDoor();
        }

        internal void OpenedDoorWhenWorking()
        {
            if (_floorQueue.Count == 0)
            {
                _state = new IdleElevator(this);
            }

            _cabin.DoorOpened();
        }

        internal void CloseDoorWhenWorking()
        {
            if (_floorQueue.Count > 0)
            {
                _waitingForPeople = false;
                _cabin.CloseDoor();
            }
        }

        internal void CloseDoorWhenIdle()
        {
            // idle, no commands entered, do nothing
        }

        internal bool MustStopOnFloor(int aFloorNumber) => _floorQueue[0] == aFloorNumber;
    }
}