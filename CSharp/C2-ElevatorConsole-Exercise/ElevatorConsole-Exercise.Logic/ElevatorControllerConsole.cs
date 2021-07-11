using System.Collections.Generic;

namespace ElevatorConsole_Exercise.Logic
{
    public class ElevatorControllerConsole : CabinStateVisitor, CabinDoorStateVisitor
    {
        private readonly List<string> _console;

        public ElevatorControllerConsole(ElevatorController elevatorController) {
            _console = new List<string>();
            elevatorController.addCabinObserver(this);
            elevatorController.addCabinDoorObserver(this);
        }

        public IEnumerator<string> consoleReader() => _console.GetEnumerator();

        public void visitCabinMoving(CabinMovingState cabinMovingState) =>
            _console.Add("Cabina Moviendose");

        public void visitCabinStopped(CabinStoppedState cabinStoppedState) =>
            _console.Add("Cabina Detenida");

        public void visitCabinWaitingPeople(CabinWaitingForPeopleState cabinWaitingForPeopleState) =>
            _console.Add("Cabina Esperando Gente");

        public void visitCabinDoorClosing(CabinDoorClosingState cabinDoorClosingState) =>
            _console.Add("Puerta Cerrandose");

        public void visitCabinDoorClosed(CabinDoorClosedState cabinDoorClosedState) =>
            _console.Add("Puerta Cerrada");

        public void visitCabinDoorOpened(CabinDoorOpenedState cabinDoorOpenedState) =>
            _console.Add("Puerta Abierta");

        public void visitCabinDoorOpening(CabinDoorOpeningState cabinDoorOpeningState) =>
            _console.Add("Puerta Abriendose");
    }
}