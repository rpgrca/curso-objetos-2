using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevatorConsole_Exercise.Logic
{
    public class ElevatorController
    {
        private ElevatorControllerState state;
        private CabinState cabinState;
        private CabinDoorState cabinDoorState;
        private int currentCabinFloorNumber;
        private readonly List<CabinStateVisitor> _cabinStateObservers = new();
        private readonly List<CabinDoorStateVisitor> _cabinDoorStateObservers = new();
        private readonly SortedSet<int> floorsToGo = new();

        public ElevatorController()
        {
            controllerIsIdle();
            cabinIsStopped();
            cabinDoorIsOpened();
            currentCabinFloorNumber = 0;
        }

        //Elevator state
        private void controllerIsIdle() =>
            state = new ElevatorControllerIdleState(this);

        private void controllerIsWorking() =>
            state = new ElevatorControllerIsWorkingState(this);

        public bool isIdle() => state.isIdle();

        public bool isWorking() => state.isWorking();

        //Door state
        private void cabinDoorIsClosed()
        {
            cabinDoorState = new CabinDoorClosedState(this);
            _cabinDoorStateObservers.ForEach(p => cabinDoorState.accept(p));
        }

        private void cabinDoorIsOpened() =>
            cabinDoorState = new CabinDoorOpenedState(this);

        private void cabinDoorIsClosing()
        {
            cabinDoorState = new CabinDoorClosingState(this);
            _cabinDoorStateObservers.ForEach(p => cabinDoorState.accept(p));
        }

        private void cabinDoorIsOpening()
        {
            cabinDoorState = new CabinDoorOpeningState(this);
            _cabinDoorStateObservers.ForEach(p => cabinDoorState.accept(p));
        }

        public bool isCabinDoorOpened() => cabinDoorState.isOpened();

        public bool isCabinDoorOpening() => cabinDoorState.isOpening();

        public bool isCabinDoorClosed() => cabinDoorState.isClosed();

        public bool isCabinDoorClosing() => cabinDoorState.isClosing();

        //Cabin state
        private void cabinIsStopped()
        {
            cabinState = new CabinStoppedState(this);
            _cabinStateObservers.ForEach(p => cabinState.accept(p));
        }

        private void cabinMoving()
        {
            cabinState = new CabinMovingState(this);
            _cabinStateObservers.ForEach(p => cabinState.accept(p));
        }

        private void cabinIsWaitingForPeople() =>
            cabinState = new CabinWaitingForPeopleState(this);

        public int cabinFloorNumber() => currentCabinFloorNumber;

        public bool isCabinStopped() => cabinState.isStopped();

        public bool isCabinMoving() => cabinState.isMoving();

        public bool isCabinWaitingForPeople() => cabinState.isWaitingForPeople();

        //Events
        public void goUpPushedFromFloor(int aFloorNumber) =>
            state.goUpPushedFromFloor(aFloorNumber);

        public void cabinOnFloor(int aFloorNumber) =>
            state.cabinOnFloor(aFloorNumber);

        public void cabinDoorClosed() => state.cabindDoorClosed();

        public void openCabinDoor() => state.openCabinDoor();

        public void cabinDoorOpened() => state.cabinDoorOpened();

        public void waitForPeopleTimedOut() => state.waitForPeopleTimedOut();

        public void closeCabinDoor() => state.closeCabinDoor();

        public void goUpPushedFromFloorWhenIdle(int aFloorNumber)
        {
            floorsToGo.Add(aFloorNumber);
            controllerIsWorking();
            cabinDoorIsClosing();
        }

        public void cabinDoorClosedWhenWorking() =>
            cabinState.cabinDoorClosedWhenWorking();

        public void cabinDoorClosedWhenWorkingAndCabinStopped() =>
            cabinDoorState.cabinDoorClosedWhenWorkingAndCabinStopped();

        public void cabinDoorClosedWhenWorkingAndCabinStoppedAndClosing()
        {
            cabinDoorIsClosed();
            cabinMoving();
        }

        public void cabinOnFloorWhenWorking(int aFloorNumber)
        {
            if (aFloorNumber < currentCabinFloorNumber) throw new Exception("Sensor de cabina desincronizado");
            if (currentCabinFloorNumber + 1 != aFloorNumber) throw new Exception("Sensor de cabina desincronizado");

            currentCabinFloorNumber = aFloorNumber;
            if (floorsToGo.ElementAt(0) == aFloorNumber)
            {
                floorsToGo.Remove(floorsToGo.ElementAt(0));
                cabinIsStopped();
                cabinDoorIsOpening();
            }
        }

        public void cabinOnFloorWhenIdle(int aFloorNumber) =>
            throw new Exception("Sensor de cabina desincronizado");

        public void cabinDoorOpenendWhenWorking() =>
            cabinState.cabinDoorOpenedWhenWorking();

        public void cabinDoorOpenedWhenWorkingAndCabinStopped()
        {
            cabinDoorIsOpened();
            if (hasFloorToGo())
                cabinIsWaitingForPeople();
            else
                controllerStateIsIdle();
        }

        private void controllerStateIsIdle() =>
            state = new ElevatorControllerIdleState(this);

        private bool hasFloorToGo() => floorsToGo.Count > 0;

        public void openCabinDoorWhenIdle()
        {
            //No hago nada porque me pidieron abrir la puerta cuando no estoy haciendo nada
            //y en ese caso ya está abierta
        }

        public void openCabinDoorWhenWorking() =>
            cabinState.openCabinDoorWhenWorking();

        public void openCabinDoorWhenWorkingAndCabinStopped() =>
            cabinDoorState.openCabinDoorWhenWorkingAndCabinStopped();

        public void openCabinDoorWhenWorkingAndCabinStoppedAndDoorClosing() =>
            cabinDoorIsOpening();

        public void openCabinDoorWhenWorkingAndCabinMoving()
        {
            //No puedo abrir la puerta porque la cabina se está moviendo!
        }

        public void openCabinDoorWhenWorkingAndCabinStoppedAndCabinDoorOpening()
        {
            //Ya se está abriendo!! no tengo que hacer nada
        }

        public void goUpPushedFromFloorWhenWorking(int aFloorNumber) =>
            floorsToGo.Add(aFloorNumber);

        public void waitForPeopleTimedOutWhenWorking() =>
            cabinState.waitForPeopleTimedOutWhenWorking();

        public void waitForPeopleTimedOutWhenWorkingAndCabinWaitingForPeople()
        {
            cabinIsStopped();
            cabinDoorIsClosing();
        }

        public void closeCabinDoorWhenWorking() =>
            cabinState.closeCabinDoorWhenWorking();

        public void closeCabinDoorWhenWorkingAndCabinWaitingForPeople() =>
            waitForPeopleTimedOutWhenWorkingAndCabinWaitingForPeople();

        public void closeCabinDoorWhenIdle()
        {
            //No estoy haciendo nada y me piden cerrar la puerta, por lo tanto no la 
            //cierro porque no tengo que mover la cabina puesto que estoy idle
        }

        public void closeCabinDoorWhenWorkingAndCabinMoving()
        {
            //Si la cabina se está moviendo, la puerta ya está cerrada, por lo tanto
            //no tengo que volver a cerrarla
        }

        public void closeCabinDoorWhenWorkingAndCabinStopped() =>
            cabinDoorState.closeCabinDoorWhenWorkingAndCabinStopped();

        public void closeCabinDoorWhenWorkingAndCabinStoppedAndCabinDoorOpening()
        {
            //Estoy abriendo la puerta para que suba gente y me piden cerrarla. 
            //No la cierro hasta no abrir completamente la puerta
        }

        public void cabinDoorClosedWhenIdle() =>
            throw new Exception("Sensor de puerta desincronizado");

        public void cabinDoorClosedWhenWorkingAndCabinMoving() =>
            throw new Exception("Sensor de puerta desincronizado");

        public void cabinDoorClosedWhenWorkingAndCabinStoppedAndCabinDoorOpening() =>
            throw new Exception("Sensor de puerta desincronizado");

        public void addCabinObserver(CabinStateVisitor cabinStateVisitor) =>
            _cabinStateObservers.Add(cabinStateVisitor);

        public void addCabinDoorObserver(CabinDoorStateVisitor cabinDoorStateVisitor) =>
            _cabinDoorStateObservers.Add(cabinDoorStateVisitor);
    }
}