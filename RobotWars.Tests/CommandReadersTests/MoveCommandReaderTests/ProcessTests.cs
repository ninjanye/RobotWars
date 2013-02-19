using Moq;
using NUnit.Framework;
using RobotWars.CommandReaders;

namespace RobotWars.Tests.CommandReadersTests.MoveCommandReaderTests
{
    [TestFixture]
    public class ProcessTests
    {
        private Mock<IContext> context;
        private Mock<IRobot> robot;
        private MoveRobotCommandReader moveCommandReader; 

        [SetUp]
        public void Setup()
        {
            this.context = new Mock<IContext>();
            this.robot = new Mock<IRobot>();

            this.context.SetupGet(c => c.LatestRobot).Returns(this.robot.Object);

            this.moveCommandReader = new MoveRobotCommandReader(this.context.Object);
        }

        [Test]
        public void ProcessMoveRobotCommand_RobotAskedToMoveOnce_RobotMovesOnce()
        {
            //Arrange

            //Act
            this.moveCommandReader.Process("M");

            //Assert
            this.robot.Verify(r => r.Move(), Times.Once());
        }

        [Test]
        public void ProcessMoveRobotCommand_RobotAskedToMoveFiveTimes_RobotMovesFiveTimes()
        {
            //Arrange
            string command = "MMMMM";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.Move(), Times.Exactly(5));
        }

        [Test]
        public void ProcessMoveRobotCommand_InvalidCommand_RobotDoesNotMove()
        {
            //Arrange
            string command = "G";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.Move(), Times.Never());
        }

        [Test]
        public void ProcessMoveRobotCommand_RotateRobotCommand_RobotRotatesClockwiseOnce()
        {
            //Arrange
            string command = "R";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.Rotate(true), Times.Once());
        }

        [Test]
        public void ProcessMoveRobotCommand_RotateRobotFourTimes_RobotRotatesClockwiseFourTimes()
        {
            //Arrange
            string command = "RRRR";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.Rotate(true), Times.Exactly(4));
        }

        [Test]
        public void ProcessMoveRobotCommand_RotateRobotAnticlockwiseCommand_RobotRotatesAnticlockwiseOnce()
        {
            //Arrange
            string command = "L";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.Rotate(false), Times.Once());
        }

        [Test]
        public void ProcessMoveRobotCommand_RotateRobotAnticlockwiseFourTimes_RobotRotatesAnticlockwiseFourTimes()
        {
            //Arrange
            string command = "LLLL";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.Rotate(false), Times.Exactly(4));
        }

        [Test]
        public void ProcessMoveRobotCommand_MoveRobotThreeTimesRotateRightOnceMoveTwice_RobotMovesThreeTimesThenRotatesClockwiseThenMovesTwice()
        {
            //Arrange
            string command = "MMMRMM";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.Move(), Times.Exactly(5));
            this.robot.Verify(r => r.Rotate(true), Times.Once());
        }
    }
}
