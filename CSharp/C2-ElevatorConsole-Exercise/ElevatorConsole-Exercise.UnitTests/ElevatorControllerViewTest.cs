using Xunit;
using ElevatorConsole_Exercise.Logic;

namespace ElevatorConsole_Exercise.UnitTests
{
    public class ElevatorControllerViewTest
    {
        [Fact]
        public void test01ElevatorControllerConsoleTracksDoorClosingState()
        {
            var elevatorController = new ElevatorController();
            var elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);

            elevatorController.goUpPushedFromFloor(1);

            var reader = elevatorControllerConsole.consoleReader();

            reader.MoveNext();
            Assert.Equal("Puerta Cerrandose", reader.Current);
            Assert.False(reader.MoveNext());

        }

        [Fact]
        public void test02ElevatorControllerConsoleTracksCabinState()
        {
            var elevatorController = new ElevatorController();
            var elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();

            var reader = elevatorControllerConsole.consoleReader();

            reader.MoveNext();
            Assert.Equal("Puerta Cerrandose", reader.Current);
            reader.MoveNext();
            Assert.Equal("Puerta Cerrada", reader.Current);
            reader.MoveNext();
            Assert.Equal("Cabina Moviendose", reader.Current);
            Assert.False(reader.MoveNext());

        }

        [Fact]
        public void test03ElevatorControllerConsoleTracksCabinAndDoorStateChanges()
        {
            var elevatorController = new ElevatorController();
            var elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);

            var reader = elevatorControllerConsole.consoleReader();

            reader.MoveNext();
            Assert.Equal("Puerta Cerrandose", reader.Current);
            reader.MoveNext();
            Assert.Equal("Puerta Cerrada", reader.Current);
            reader.MoveNext();
            Assert.Equal("Cabina Moviendose", reader.Current);
            reader.MoveNext();
            Assert.Equal("Cabina Detenida", reader.Current);
            reader.MoveNext();
            Assert.Equal("Puerta Abriendose", reader.Current);
            Assert.False(reader.MoveNext());
        }

        [Fact]
        public void test04ElevatorControllerCanHaveMoreThanOneView()
        {
            var elevatorController = new ElevatorController();
            var elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);
            var elevatorControllerStatusView = new ElevatorControllerStatusView(elevatorController);

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);

            var reader = elevatorControllerConsole.consoleReader();

            reader.MoveNext();
            Assert.Equal("Puerta Cerrandose", reader.Current);
            reader.MoveNext();
            Assert.Equal("Puerta Cerrada", reader.Current);
            reader.MoveNext();
            Assert.Equal("Cabina Moviendose", reader.Current);
            reader.MoveNext();
            Assert.Equal("Cabina Detenida", reader.Current);
            reader.MoveNext();
            Assert.Equal("Puerta Abriendose", reader.Current);
            Assert.False(reader.MoveNext());

            Assert.Equal("Stopped", elevatorControllerStatusView.cabinFieldModel());
            Assert.Equal("Opening", elevatorControllerStatusView.cabinDoorFieldModel());
        }
    }
}
