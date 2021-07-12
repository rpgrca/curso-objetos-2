using Xunit;
using ElevatorConsole_Exercise.Logic;

namespace ElevatorConsole_Exercise.UnitTests
{
    public class ElevatorControllerViewTest
    {
        [Fact]
        public void Test01ElevatorControllerConsoleTracksDoorClosingState()
        {
            var elevatorController = new ElevatorController();
            var elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);

            elevatorController.GoUpPushedFromFloor(1);

            var reader = elevatorControllerConsole.ConsoleReader();
            Assert.Single(reader, "Puerta Cerrandose");
        }

        [Fact]
        public void Test02ElevatorControllerConsoleTracksCabinState()
        {
            var elevatorController = new ElevatorController();
            var elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();

            var reader = elevatorControllerConsole.ConsoleReader();
            Assert.Collection(reader,
                p1 => Assert.Equal("Puerta Cerrandose", p1),
                p2 => Assert.Equal("Puerta Cerrada", p2),
                p3 => Assert.Equal("Cabina Moviendose", p3));
        }

        [Fact]
        public void Test03ElevatorControllerConsoleTracksCabinAndDoorStateChanges()
        {
            var elevatorController = new ElevatorController();
            var elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);

            var reader = elevatorControllerConsole.ConsoleReader();

            Assert.Collection(reader,
                p1 => Assert.Equal("Puerta Cerrandose", p1),
                p2 => Assert.Equal("Puerta Cerrada", p2),
                p3 => Assert.Equal("Cabina Moviendose", p3),
                p4 => Assert.Equal("Cabina Detenida", p4),
                p5 => Assert.Equal("Puerta Abriendose", p5));
        }

        [Fact]
        public void Test04ElevatorControllerCanHaveMoreThanOneView()
        {
            var elevatorController = new ElevatorController();
            var elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);
            var elevatorControllerStatusView = new ElevatorControllerStatusView(elevatorController);

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);
            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinDoorOpened();

            var reader = elevatorControllerConsole.ConsoleReader();
            Assert.Collection(reader,
                p1 => Assert.Equal("Puerta Cerrandose", p1),
                p2 => Assert.Equal("Puerta Cerrada", p2),
                p3 => Assert.Equal("Cabina Moviendose", p3),
                p4 => Assert.Equal("Cabina Detenida", p4),
                p5 => Assert.Equal("Puerta Abriendose", p5),
                p6 => Assert.Equal("Puerta Abierta", p6),
                p7 => Assert.Equal("Cabina Esperando Gente", p7));

            Assert.Equal("Waiting People", elevatorControllerStatusView.CabinFieldModel());
            Assert.Equal("Open", elevatorControllerStatusView.CabinDoorFieldModel());
        }

        [Fact]
        public void Test05TestFullLog()
        {
            var elevatorController = new ElevatorController();
            var elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);
            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinDoorOpened();
            elevatorController.WaitForPeopleTimedOut();

            var reader = elevatorControllerConsole.ConsoleReader();
            Assert.Collection(reader,
                p1 => Assert.Equal("Puerta Cerrandose", p1),
                p2 => Assert.Equal("Puerta Cerrada", p2),
                p3 => Assert.Equal("Cabina Moviendose", p3),
                p4 => Assert.Equal("Cabina Detenida", p4),
                p5 => Assert.Equal("Puerta Abriendose", p5),
                p6 => Assert.Equal("Puerta Abierta", p6),
                p7 => Assert.Equal("Cabina Esperando Gente", p7),
                p8 => Assert.Equal("Cabina Detenida", p8),
                p9 => Assert.Equal("Puerta Cerrandose", p9));
        }
    }
}