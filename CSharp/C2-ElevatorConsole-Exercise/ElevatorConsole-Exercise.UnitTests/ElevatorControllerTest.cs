using System;
using Xunit;
using ElevatorConsole_Exercise.Logic;

namespace ElevatorConsole_Exercise.UnitTests
{
    public class ElevatorControllerTest
    {
        [Fact]
        public void TestElevatorStartsIdleWithDoorOpenOnFloorZero()
        {
            var elevatorController = new ElevatorController();

            Assert.True(elevatorController.IsIdle());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorOpened());
            Assert.Equal(0, elevatorController.CabinFloorNumber());
        }

        [Fact]
        public void TestCabinDoorStartsClosingWhenElevatorGetsCalled()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);

            Assert.False(elevatorController.IsIdle());
            Assert.True(elevatorController.IsWorking());

            Assert.True(elevatorController.IsCabinStopped());
            Assert.False(elevatorController.IsCabinMoving());

            Assert.False(elevatorController.IsCabinDoorOpened());
            Assert.False(elevatorController.IsCabinDoorOpening());
            Assert.True(elevatorController.IsCabinDoorClosing());
            Assert.False(elevatorController.IsCabinDoorClosed());
        }

        [Fact]
        public void TestCabinStartsMovingWhenDoorGetsClosed()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();

            Assert.False(elevatorController.IsIdle());
            Assert.True(elevatorController.IsWorking());

            Assert.False(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinMoving());

            Assert.False(elevatorController.IsCabinDoorOpened());
            Assert.False(elevatorController.IsCabinDoorOpening());
            Assert.False(elevatorController.IsCabinDoorClosing());
            Assert.True(elevatorController.IsCabinDoorClosed());
        }

        [Fact]
        public void TestCabinStopsAndStartsOpeningDoorWhenGetsToDestination()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);

            Assert.False(elevatorController.IsIdle());
            Assert.True(elevatorController.IsWorking());

            Assert.True(elevatorController.IsCabinStopped());
            Assert.False(elevatorController.IsCabinMoving());

            Assert.False(elevatorController.IsCabinDoorOpened());
            Assert.True(elevatorController.IsCabinDoorOpening());
            Assert.False(elevatorController.IsCabinDoorClosing());
            Assert.False(elevatorController.IsCabinDoorClosed());

            Assert.Equal(1, elevatorController.CabinFloorNumber());
        }

        [Fact]
        public void TestElevatorGetsIdleWhenDoorGetOpened()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);
            elevatorController.CabinDoorOpened();

            Assert.True(elevatorController.IsIdle());
            Assert.False(elevatorController.IsWorking());

            Assert.True(elevatorController.IsCabinStopped());
            Assert.False(elevatorController.IsCabinMoving());

            Assert.True(elevatorController.IsCabinDoorOpened());
            Assert.False(elevatorController.IsCabinDoorOpening());
            Assert.False(elevatorController.IsCabinDoorClosing());
            Assert.False(elevatorController.IsCabinDoorClosed());

            Assert.Equal(1, elevatorController.CabinFloorNumber());
        }

        // STOP HERE!

        [Fact]
        public void TestDoorKeepsOpenedWhenOpeningIsRequested()
        {
            var elevatorController = new ElevatorController();

            Assert.True(elevatorController.IsCabinDoorOpened());

            elevatorController.OpenCabinDoor();

            Assert.True(elevatorController.IsCabinDoorOpened());
        }

        [Fact]
        public void TestDoorMustBeOpenedWhenCabinIsStoppedAndClosingDoors()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorClosing());

            elevatorController.OpenCabinDoor();
            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorOpening());
        }

        [Fact]
        public void TestCanNotOpenDoorWhenCabinIsMoving()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinMoving());
            Assert.True(elevatorController.IsCabinDoorClosed());

            elevatorController.OpenCabinDoor();
            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinMoving());
            Assert.True(elevatorController.IsCabinDoorClosed());
        }

        [Fact]
        public void TestDoorKeepsOpeningWhenItIsOpening()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorOpening());

            elevatorController.OpenCabinDoor();
            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorOpening());
        }

        // STOP HERE!!

        [Fact]
        public void TestRequestToGoUpAreEnqueueWhenRequestedWhenCabinIsMoving()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);
            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinDoorOpened();

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinWaitingForPeople());
            Assert.True(elevatorController.IsCabinDoorOpened());
        }

        [Fact]
        public void TestCabinDoorStartClosingAfterWaitingForPeople()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);
            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinDoorOpened();
            elevatorController.WaitForPeopleTimedOut();

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorClosing());
        }

        [Fact]
        public void TestStopsWaitingForPeopleIfCloseDoorIsPressed()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);
            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinDoorOpened();

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinWaitingForPeople());
            Assert.True(elevatorController.IsCabinDoorOpened());

            elevatorController.CloseCabinDoor();

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorClosing());
        }

        [Fact]
        public void TestCloseDoorDoesNothingIfIdle()
        {
            var elevatorController = new ElevatorController();

            elevatorController.CloseCabinDoor();

            Assert.True(elevatorController.IsIdle());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorOpened());
        }

        [Fact]
        public void TestCloseDoorDoesNothingWhenCabinIsMoving()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinMoving());
            Assert.True(elevatorController.IsCabinDoorClosed());

            elevatorController.CloseCabinDoor();

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinMoving());
            Assert.True(elevatorController.IsCabinDoorClosed());
        }

        [Fact]
        public void TestCloseDoorDoesNothingWhenOpeningTheDoorToWaitForPeople()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorOpening());

            elevatorController.CloseCabinDoor();

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorOpening());
        }

        // STOP HERE!!

        [Fact]
        public void TestElevatorHasToEnterEmergencyIfStoppedAndOtherFloorSensorTurnsOn()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);
            try
            {
                elevatorController.CabinOnFloor(0);
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de cabina desincronizado");
            }
        }

        [Fact]
        public void TestElevatorHasToEnterEmergencyIfFalling()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);
            try
            {
                elevatorController.CabinOnFloor(0);
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de cabina desincronizado");
            }
        }

        [Fact]
        public void TestElevatorHasToEnterEmergencyIfJumpsFloors()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(3);
            elevatorController.CabinDoorClosed();
            try
            {
                elevatorController.CabinOnFloor(3);
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de cabina desincronizado");
            }
        }

        [Fact]
        public void TestElevatorHasToEnterEmergencyIfDoorClosesAutomatically()
        {
            var elevatorController = new ElevatorController();

            try
            {
                elevatorController.CabinDoorClosed();
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de puerta desincronizado");
            }
        }

        [Fact]
        public void TestElevatorHasToEnterEmergencyIfDoorClosedSensorTurnsOnWhenClosed()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            try
            {
                elevatorController.CabinDoorClosed();
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de puerta desincronizado");
            }
        }

        [Fact]
        public void TestElevatorHasToEnterEmergencyIfDoorClosesWhenOpening()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(1);
            try
            {
                elevatorController.CabinDoorClosed();
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de puerta desincronizado");
            }
        }

        // STOP HERE!!
        // More tests here to verify bad sensor function

        [Fact]
        public void TestCabinHasToStopOnTheFloorsOnItsWay()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinOnFloor(1);

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorOpening());
        }

        [Fact]
        public void TestElevatorCompletesAllTheRequests()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinDoorClosed();
            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinOnFloor(1);
            elevatorController.CabinDoorOpened();
            elevatorController.WaitForPeopleTimedOut();
            elevatorController.CabinDoorClosed();
            elevatorController.CabinOnFloor(2);

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorOpening());
        }

        [Fact]
        public void TestCabinHasToStopOnFloorsOnItsWayNoMatterHowTheyWellCalled()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinDoorClosed();
            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinOnFloor(1);

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorOpening());
        }

        [Fact]
        public void TestCabinHasToStopAndWaitForPeopleOnFloorsOnItsWayNoMatterHowTheyWellCalled()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinDoorClosed();
            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinOnFloor(1);
            elevatorController.CabinDoorOpened();
            elevatorController.WaitForPeopleTimedOut();

            Assert.True(elevatorController.IsWorking());
            Assert.True(elevatorController.IsCabinStopped());
            Assert.True(elevatorController.IsCabinDoorClosing());
        }

        [Fact]
        public void TestCabinWaitingForPeople()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinDoorClosed();
            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinOnFloor(1);
            elevatorController.CabinDoorOpened();

            Assert.False(elevatorController.IsCabinMoving());
            Assert.True(elevatorController.IsCabinStopped());
        }

        [Fact]
        public void TestCabinHasToEnterEmergencyIfSensorClosesWhileWaitingForPeople()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinDoorClosed();
            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinOnFloor(1);
            elevatorController.CabinDoorOpened();

            var exception = Assert.Throws<Exception>(() => elevatorController.CabinDoorClosed());
        }

        [Fact]
        public void TestCabinHasToEnterEmergencyIfSensorOpensWhileWaitingForPeople()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinDoorClosed();
            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinOnFloor(1);
            elevatorController.CabinDoorOpened();

            var exception = Assert.Throws<Exception>(() => elevatorController.CabinDoorOpened());
        }

        [Fact]
        public void TestCabinHasToEnterEmergencyIfOpeningDoorWhileWaitingForPeople()
        {
            var elevatorController = new ElevatorController();

            elevatorController.GoUpPushedFromFloor(2);
            elevatorController.CabinDoorClosed();
            elevatorController.GoUpPushedFromFloor(1);
            elevatorController.CabinOnFloor(1);
            elevatorController.CabinDoorOpened();

            var exception = Assert.Throws<Exception>(() => elevatorController.OpenCabinDoor());
        }

        [Fact]
        public void TestCabinHasToEnterEmergencyIfCabinOnFloorIsTriggeredWhileIdle()
        {
            var elevatorController = new ElevatorController();

            var exception = Assert.Throws<Exception>(() => elevatorController.CabinOnFloor(1));
            Assert.Equal("Sensor de cabina desincronizado", exception.Message);
        }

        [Fact]
        public void TestCabinHasToEnterEmergencyIfOpenedDoorSensorIsTriggeredWhileIdle()
        {
            var elevatorController = new ElevatorController();

            var exception = Assert.Throws<Exception>(() => elevatorController.CabinDoorOpened());
        }

        [Fact]
        public void TestCabinHasToEnterEmergencyIfWaitTimedOutWhileIdle()
        {
            var elevatorController = new ElevatorController();

            var exception = Assert.Throws<Exception>(() => elevatorController.WaitForPeopleTimedOut());
        }
    }
}