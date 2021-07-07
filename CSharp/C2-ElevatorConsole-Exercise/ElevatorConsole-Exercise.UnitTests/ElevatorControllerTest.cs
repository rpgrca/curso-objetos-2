using System;
using Xunit;
using ElevatorConsole_Exercise.Logic;

namespace ElevatorConsole_Exercise.UnitTests
{
    public class ElevatorControllerTest
    {
        [Fact]
        public void testElevatorStartsIdleWithDoorOpenOnFloorZero()
        {
            var elevatorController = new ElevatorController();

            Assert.True(elevatorController.isIdle());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpened());
            Assert.Equal(0, elevatorController.cabinFloorNumber());
        }

        [Fact]
        public void testCabinDoorStartsClosingWhenElevatorGetsCalled()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);

            Assert.False(elevatorController.isIdle());
            Assert.True(elevatorController.isWorking());

            Assert.True(elevatorController.isCabinStopped());
            Assert.False(elevatorController.isCabinMoving());

            Assert.False(elevatorController.isCabinDoorOpened());
            Assert.False(elevatorController.isCabinDoorOpening());
            Assert.True(elevatorController.isCabinDoorClosing());
            Assert.False(elevatorController.isCabinDoorClosed());
        }

        [Fact]
        public void testCabinStartsMovingWhenDoorGetsClosed()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();

            Assert.False(elevatorController.isIdle());
            Assert.True(elevatorController.isWorking());

            Assert.False(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinMoving());

            Assert.False(elevatorController.isCabinDoorOpened());
            Assert.False(elevatorController.isCabinDoorOpening());
            Assert.False(elevatorController.isCabinDoorClosing());
            Assert.True(elevatorController.isCabinDoorClosed());
        }

        [Fact]
        public void testCabinStopsAndStartsOpeningDoorWhenGetsToDestination()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);

            Assert.False(elevatorController.isIdle());
            Assert.True(elevatorController.isWorking());

            Assert.True(elevatorController.isCabinStopped());
            Assert.False(elevatorController.isCabinMoving());

            Assert.False(elevatorController.isCabinDoorOpened());
            Assert.True(elevatorController.isCabinDoorOpening());
            Assert.False(elevatorController.isCabinDoorClosing());
            Assert.False(elevatorController.isCabinDoorClosed());

            Assert.Equal(1, elevatorController.cabinFloorNumber());
        }

        [Fact]
        public void testElevatorGetsIdleWhenDoorGetOpened()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            elevatorController.cabinDoorOpened();

            Assert.True(elevatorController.isIdle());
            Assert.False(elevatorController.isWorking());

            Assert.True(elevatorController.isCabinStopped());
            Assert.False(elevatorController.isCabinMoving());

            Assert.True(elevatorController.isCabinDoorOpened());
            Assert.False(elevatorController.isCabinDoorOpening());
            Assert.False(elevatorController.isCabinDoorClosing());
            Assert.False(elevatorController.isCabinDoorClosed());

            Assert.Equal(1, elevatorController.cabinFloorNumber());
        }

        // STOP HERE!

        [Fact]
        public void testDoorKeepsOpenedWhenOpeningIsRequested()
        {
            var elevatorController = new ElevatorController();

            Assert.True(elevatorController.isCabinDoorOpened());

            elevatorController.openCabinDoor();

            Assert.True(elevatorController.isCabinDoorOpened());
        }

        [Fact]
        public void testDoorMustBeOpenedWhenCabinIsStoppedAndClosingDoors()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorClosing());

            elevatorController.openCabinDoor();
            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());
        }

        [Fact]
        public void testCanNotOpenDoorWhenCabinIsMoving()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinMoving());
            Assert.True(elevatorController.isCabinDoorClosed());

            elevatorController.openCabinDoor();
            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinMoving());
            Assert.True(elevatorController.isCabinDoorClosed());
        }

        [Fact]
        public void testDoorKeepsOpeneingWhenItIsOpeneing()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());

            elevatorController.openCabinDoor();
            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());
        }

        // STOP HERE!!

        [Fact]
        public void testRequestToGoUpAreEnqueueWhenRequestedWhenCabinIsMoving()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinDoorOpened();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinWaitingForPeople());
            Assert.True(elevatorController.isCabinDoorOpened());
        }

        [Fact]
        public void testCabinDoorStartClosingAfterWaitingForPeople()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinDoorOpened();
            elevatorController.waitForPeopleTimedOut();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorClosing());
        }

        [Fact]
        public void testStopsWaitingForPeopleIfCloseDoorIsPressed()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinDoorOpened();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinWaitingForPeople());
            Assert.True(elevatorController.isCabinDoorOpened());

            elevatorController.closeCabinDoor();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorClosing());
        }

        [Fact]
        public void testCloseDoorDoesNothingIfIdle()
        {
            var elevatorController = new ElevatorController();

            elevatorController.closeCabinDoor();

            Assert.True(elevatorController.isIdle());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpened());
        }

        [Fact]
        public void testCloseDoorDoesNothingWhenCabinIsMoving()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinMoving());
            Assert.True(elevatorController.isCabinDoorClosed());

            elevatorController.closeCabinDoor();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinMoving());
            Assert.True(elevatorController.isCabinDoorClosed());
        }

        [Fact]
        public void testCloseDoorDoesNothingWhenOpeningTheDoorToWaitForPeople()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());

            elevatorController.closeCabinDoor();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());
        }

        // STOP HERE!!

        [Fact]
        public void testElevatorHasToEnterEmergencyIfStoppedAndOtherFloorSensorTurnsOn()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            try
            {
                elevatorController.cabinOnFloor(0);
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de cabina desincronizado");
            }
        }

        [Fact]
        public void testElevatorHasToEnterEmergencyIfFalling()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            try
            {
                elevatorController.cabinOnFloor(0);
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de cabina desincronizado");
            }
        }

        [Fact]
        public void testElevatorHasToEnterEmergencyIfJumpsFloors()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(3);
            elevatorController.cabinDoorClosed();
            try
            {
                elevatorController.cabinOnFloor(3);
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de cabina desincronizado");
            }
        }

        [Fact]
        public void testElevatorHasToEnterEmergencyIfDoorClosesAutomatically()
        {
            var elevatorController = new ElevatorController();

            try
            {
                elevatorController.cabinDoorClosed();
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de puerta desincronizado");
            }
        }

        [Fact]
        public void testElevatorHasToEnterEmergencyIfDoorClosedSensorTurnsOnWhenClosed()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            try
            {
                elevatorController.cabinDoorClosed();
                Assert.True(false);
            }
            catch (Exception elevatorEmergency)
            {
                Assert.True(elevatorEmergency.Message == "Sensor de puerta desincronizado");
            }
        }

        [Fact]
        public void testElevatorHasToEnterEmergencyIfDoorClosesWhenOpening()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(1);
            try
            {
                elevatorController.cabinDoorClosed();
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
        public void testCabinHasToStopOnTheFloorsOnItsWay()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinOnFloor(1);

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());
        }

        [Fact]
        public void testElevatorCompletesAllTheRequests()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinDoorClosed();
            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinOnFloor(1);
            elevatorController.cabinDoorOpened();
            elevatorController.waitForPeopleTimedOut();
            elevatorController.cabinDoorClosed();
            elevatorController.cabinOnFloor(2);

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());
        }

        [Fact]
        public void testCabinHasToStopOnFloorsOnItsWayNoMatterHowTheyWellCalled()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinDoorClosed();
            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinOnFloor(1);

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorOpening());
        }

        [Fact]
        public void testCabinHasToStopAndWaitForPeopleOnFloorsOnItsWayNoMatterHowTheyWellCalled()
        {
            var elevatorController = new ElevatorController();

            elevatorController.goUpPushedFromFloor(2);
            elevatorController.cabinDoorClosed();
            elevatorController.goUpPushedFromFloor(1);
            elevatorController.cabinOnFloor(1);
            elevatorController.cabinDoorOpened();
            elevatorController.waitForPeopleTimedOut();

            Assert.True(elevatorController.isWorking());
            Assert.True(elevatorController.isCabinStopped());
            Assert.True(elevatorController.isCabinDoorClosing());
        }
    }
}