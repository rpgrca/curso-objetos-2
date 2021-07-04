using System.Linq;
using System.Collections.Generic;
using System;

namespace ElevatorExercise.Logic
{
    public interface ElevatorState
    {
        bool IsIdle();
        bool IsWorking();
        void goUpPushedFromFloor(int aFloorNumber);
        void DoorOpened();
        void CloseDoor();
    }

    public class WorkingElevator : ElevatorState
    {
        private readonly ElevatorController _elevator;

        public WorkingElevator(ElevatorController elevator) => _elevator = elevator;

        public bool IsIdle() => false;

        public bool IsWorking() => true;

        public void goUpPushedFromFloor(int aFloorNumber) => _elevator.goUpPushedFromFloorWhileWorking(aFloorNumber);

        public void DoorOpened() => _elevator.OpenedDoorWhenWorking();

        public void CloseDoor() => _elevator.CloseDoorWhenWorking();
    }

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
        public bool isIdle() => _state.IsIdle(); //_floorQueue.Count == 0 && _cabin.IsIdle();

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

        public void cabinOnFloor(int aFloorNumber)
        {
            _cabin.OnArrivingAt(aFloorNumber);
        }

        public void cabinDoorClosed() => _cabin.OnDoorClosed();

        public void openCabinDoor() => _cabin.OpenDoor();

        public void cabinDoorOpened() => _state.DoorOpened();

        public void waitForPeopleTimedOut()
        {
            _waitingForPeople = false;
            _cabin.CloseDoor();
        }

        public void closeCabinDoor() => _state.CloseDoor();

        internal void OnDoorClosed()
        {
            if (_floorQueue.Count == 0)
            {
                throw new ElevatorEmergency("Sensor de puerta desincronizado");
            }
        }

        internal void ReachedFloor(int aFloorNumber)
        {
            if (_floorQueue.Count == 0 || aFloorNumber > _floorQueue[0])
            {
                throw new ElevatorEmergency("Sensor de cabina desincronizado");
            }

            if (_floorQueue[0] == aFloorNumber)
            {
                _floorQueue.RemoveAt(0);
                _waitingForPeople = true;
            }
        }

        internal void goUpPushedFromFloorWhileWorking(int aFloorNumber) => QueueFloors(aFloorNumber);

        private void QueueFloors(int aFloorNumber)
        {
            _floorQueue.Add(aFloorNumber);
            _floorQueue.Sort();
        }

        internal void goUpPushedFromFloorWhileIdle(int aFloorNumber)
        {
            _state = new WorkingElevator(this);

            QueueFloors(aFloorNumber);
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

        internal void OpenedDoorWhenIdle() => _cabin.OpenDoor();

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