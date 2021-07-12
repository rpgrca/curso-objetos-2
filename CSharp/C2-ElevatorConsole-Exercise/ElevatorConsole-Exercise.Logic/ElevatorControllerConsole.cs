using System.Collections.Generic;

namespace ElevatorConsole_Exercise.Logic
{
    public class ElevatorControllerConsole : CabinStateVisitor, CabinDoorStateVisitor,
        Observer<CabinDoorState>, Observer<CabinState>
    {
        private readonly List<string> _console;

        public ElevatorControllerConsole(ElevatorController elevatorController)
        {
            _console = new List<string>();
            elevatorController.AddCabinObserver(this);
            elevatorController.AddCabinDoorObserver(this);
        }

        public IEnumerable<string> ConsoleReader() => new List<string>(_console);

        public void VisitCabinMoving(CabinMovingState cabinMovingState) =>
            _console.Add("Cabina Moviendose");

        public void VisitCabinStopped(CabinStoppedState cabinStoppedState) =>
            _console.Add("Cabina Detenida");

        public void VisitCabinWaitingPeople(CabinWaitingForPeopleState cabinWaitingForPeopleState) =>
            _console.Add("Cabina Esperando Gente");

        public void VisitCabinDoorClosing(CabinDoorClosingState cabinDoorClosingState) =>
            _console.Add("Puerta Cerrandose");

        public void VisitCabinDoorClosed(CabinDoorClosedState cabinDoorClosedState) =>
            _console.Add("Puerta Cerrada");

        public void VisitCabinDoorOpened(CabinDoorOpenedState cabinDoorOpenedState) =>
            _console.Add("Puerta Abierta");

        public void VisitCabinDoorOpening(CabinDoorOpeningState cabinDoorOpeningState) =>
            _console.Add("Puerta Abriendose");

        public void Changed(CabinDoorState visitor) => visitor.Accept(this);

        public void Changed(CabinState visitor) => visitor.Accept(this);
    }
}