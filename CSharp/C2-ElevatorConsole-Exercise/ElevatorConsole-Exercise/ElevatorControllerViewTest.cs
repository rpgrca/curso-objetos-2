using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ElevatorConsole_Exercise
{
    public class ElevatorControllerViewTest
    {
        [Fact]
        public void test01ElevatorControllerConsoleTracksDoorClosingState()
        {
            ElevatorController elevatorController = new ElevatorController();
            ElevatorControllerConsole elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);

            elevatorController.goUpPushedFromFloor(1);

            IEnumerator<String> reader = elevatorControllerConsole.consoleReader();

            reader.MoveNext();
            Assert.Equal("Puerta Cerrandose", reader.Current);
            Assert.False(reader.MoveNext());

        }

        [Fact]
        public void test02ElevatorControllerConsoleTracksCabinState()
        {
            ElevatorController elevatorController = new ElevatorController();
            ElevatorControllerConsole elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();

            IEnumerator<String> reader = elevatorControllerConsole.consoleReader();

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
            ElevatorController elevatorController = new ElevatorController();
            ElevatorControllerConsole elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);

            IEnumerator<String> reader = elevatorControllerConsole.consoleReader();

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
            ElevatorController elevatorController = new ElevatorController();
            ElevatorControllerConsole elevatorControllerConsole = new ElevatorControllerConsole(elevatorController);
            ElevatorControllerStatusView elevatorControllerStatusView = new ElevatorControllerStatusView(elevatorController);

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);

            IEnumerator<String> reader = elevatorControllerConsole.consoleReader();

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
