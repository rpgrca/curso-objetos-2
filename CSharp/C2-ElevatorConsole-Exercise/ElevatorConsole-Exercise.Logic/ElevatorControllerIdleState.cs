﻿using System;

namespace ElevatorConsole_Exercise.Logic
{
    class ElevatorControllerIdleState: ElevatorControllerState
    {
        private ElevatorController elevatorController;

        public ElevatorControllerIdleState(ElevatorController elevatorController) {
            this.elevatorController = elevatorController;
        }

        public bool isIdle() {
            return true;
        }

        public void goUpPushedFromFloor(int aFloorNumber) {
            elevatorController.goUpPushedFromFloorWhenIdle(aFloorNumber);
        }

        public bool isWorking() {
            return false;
        }

        public void cabindDoorClosed() {
            elevatorController.cabinDoorClosedWhenIdle();
        }

        public void cabinOnFloor(int aFloorNumber) {
            elevatorController.cabinOnFloorWhenIdle(aFloorNumber);
        }

        public void cabinDoorOpened() {
            throw new Exception();
        }

        public void openCabinDoor() {
            elevatorController.openCabinDoorWhenIdle();
        }

        public void closeCabinDoor() {
            elevatorController.closeCabinDoorWhenIdle();
        }

        public void waitForPeopleTimedOut() {
            throw new Exception();
        }
    }
}