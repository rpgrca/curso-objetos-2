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

            reader.MoveNext();
            Assert.Equal("Puerta Cerrandose", reader.Current);
            Assert.False(reader.MoveNext());
        }

        [Fact]
        public void Test02ElevatorControllerConsoleTracksCabinState()
        {
            var elevatorController = new ElevatorController();
            var elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();

            var reader = elevatorControllerConsole.ConsoleReader();

            reader.MoveNext();
            Assert.Equal("Puerta Cerrandose", reader.Current);
            reader.MoveNext();
            Assert.Equal("Puerta Cerrada", reader.Current);
            reader.MoveNext();
            Assert.Equal("Cabina Moviendose", reader.Current);
            Assert.False(reader.MoveNext());
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
        public void Test04ElevatorControllerCanHaveMoreThanOneView()
        {
            var elevatorController = new ElevatorController();
            var elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);
            var elevatorControllerStatusView = new ElevatorControllerStatusView(elevatorController);

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);

            var reader = elevatorControllerConsole.ConsoleReader();

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

            Assert.Equal("Stopped", elevatorControllerStatusView.CabinFieldModel());
            Assert.Equal("Opening", elevatorControllerStatusView.CabinDoorFieldModel());
        }
    }
}