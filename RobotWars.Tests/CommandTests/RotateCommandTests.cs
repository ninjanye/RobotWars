using Moq;
using NUnit.Framework;
using RobotWars.Commands;

namespace RobotWars.Tests.CommandTests
{
    [TestFixture]
    public class RotateCommandTests : CommandTestsBase
    {
        private RotateCommand command;

        public override void Setup()
        {
            base.Setup();
            this.command = new RotateCommand();
        }

        [Test]
        public void Execute_EmptyArgumentSent_ReturnFalse()
        {
            //Arrange

            //Act
            bool result = this.command.Execute(' ', this.robot.Object);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Execute_RotateLeftArgumentSent_RobotToldToRotateAnticlockwise()
        {
            //Arrange

            //Act
            this.command.Execute('L', this.robot.Object);

            //Assert
            this.robot.Verify(r => r.Rotate(false), Times.Once());
        }

        [Test]
        public void Execute_RotateRightArgumentSent_RobotToldToRotateClockwise()
        {
            //Arrange

            //Act
            this.command.Execute('R', this.robot.Object);

            //Assert
            this.robot.Verify(r => r.Rotate(true), Times.Once());
        }

        [Test]
        public void Execute_UnrecognisedArgumentSent_ReturnFalse()
        {
            //Arrange

            //Act
            bool result = this.command.Execute('X', this.robot.Object);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Execute_LowercaseRecognisedLeftArgumentSent_RotateRobotAnticlockwise()
        {
            //Arrange

            //Act
            this.command.Execute('l', this.robot.Object);

            //Assert
            this.robot.Verify(r => r.Rotate(false), Times.Once());
        }

        [Test]
        public void Execute_LowercaseRecognisedRightArgumentSent_RotateRobotClockwise()
        {
            //Arrange

            //Act
            this.command.Execute('r', this.robot.Object);

            //Assert
            this.robot.Verify(r => r.Rotate(true), Times.Once());
        }
    }
}