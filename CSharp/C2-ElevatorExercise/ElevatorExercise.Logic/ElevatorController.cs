﻿using System.Linq;
using System.Collections.Generic;
using System;

namespace ElevatorExercise.Logic
{
    public class ElevatorController
    {
        private int _cabinFloorNumber;
        private readonly Cabin _cabin;
        private readonly List<int> _floorQueue;
        private bool _waitingForPeople;

        public ElevatorController()
        {
            _cabin = new Cabin(this);
            _floorQueue = new List<int>();
            _waitingForPeople = true;
        }

        //Elevator state
        public bool isIdle() => _floorQueue.Count == 0 && _cabin.IsIdle();

        public bool isWorking() => ! isIdle();

        //Door state
        public bool isCabinDoorOpened() => _cabin.IsDoorOpened();

        public bool isCabinDoorOpening() => _cabin.IsDoorOpening();

        public bool isCabinDoorClosed() => _cabin.IsDoorClosed();

        public bool isCabinDoorClosing() => _cabin.IsDoorClosing();

        //Cabin state
        public int cabinFloorNumber() => _cabinFloorNumber;

        public bool isCabinStopped() => _cabin.IsStopped();

        public bool isCabinMoving() => _cabin.IsMoving();

        public bool isCabinWaitingForPeople() => _waitingForPeople;

        //Events
        public void goUpPushedFromFloor(int aFloorNumber)
        {
            if (_floorQueue.Count > 0)
            {
                _floorQueue.AddRange(Enumerable.Range(_floorQueue.Last() + 1, aFloorNumber));
            }
            else
            {
                _floorQueue.AddRange(Enumerable.Range(1, aFloorNumber));
            }

            _cabin.CloseDoor();
        }

        public void cabinOnFloor(int aFloorNumber)
        {
            if (_floorQueue.Count > 0 && aFloorNumber == _floorQueue[0])
            {
                _cabinFloorNumber = aFloorNumber;
            }
            else
            {
                throw new ElevatorEmergency("Sensor de cabina desincronizado");
            }

            _cabin.OnArriving();
        }

        public void cabinDoorClosed()
        {
            _cabin.OnDoorClosed();
        }

        public void openCabinDoor() => _cabin.OpenDoor();

        public void cabinDoorOpened() => _cabin.DoorOpened();

        public void waitForPeopleTimedOut()
        {
            _waitingForPeople = false;
            _cabin.CloseDoor();
        }

        public void closeCabinDoor()
        {
            if (! isIdle() && !isCabinMoving() && !isCabinDoorOpening())
            {
                _cabin.CloseDoor();
            }
        }

        internal void OnDoorClosed()
        {
            if (_floorQueue.Count == 0)
            {
                throw new ElevatorEmergency("Sensor de puerta desincronizado");
            }
        }

        internal void ReachedFloorCorrectly() => _floorQueue.RemoveAt(0);
    }
}