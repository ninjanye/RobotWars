using Moq;
using NUnit.Framework;
using RobotWars.Builders;
using RobotWars.CommandReaders;

namespace RobotWars.Tests.CommandReadersTests.CreateArenaCommandReaderTests
{
    [TestFixture]
    public class ProcessTests
    {
        private Mock<IContext> context;
        private Mock<IArenaBuilder> arenaBuilder;
        private CreateArenaCommandReader createArenaCommandReader;

        const int latitude = 5;
        const int longitude = 10;

        [SetUp]
        public void Setup()
        {
            this.context = new Mock<IContext>();
            this.arenaBuilder = new Mock<IArenaBuilder>();
            this.context.SetupGet(c => c.ArenaBuilder).Returns(this.arenaBuilder.Object);


            this.context.SetupProperty(c => c.Arena);
            this.createArenaCommandReader = new CreateArenaCommandReader(this.context.Object);
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoSingleDigitNumbersSeperatedBySpaceSupplied_CreateArena()
        {
            //Arrange

            //Act
            this.createArenaCommandReader.Process(string.Format("{0} {1}", latitude, longitude));

            //Assert
            this.arenaBuilder.Verify(ab => ab.Create(It.IsAny<uint>(), It.IsAny<uint>()), Times.Once());
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoSingleDigitNumbersSeperatedBySpaceSupplied_SetArena()
        {
            //Arrange
            var arena = new Arena(latitude, longitude);
            this.arenaBuilder.Setup(ab => ab.Create(It.IsAny<uint>(), It.IsAny<uint>())).Returns(arena);

            //Act
            this.createArenaCommandReader.Process(string.Format("{0} {1}", latitude, longitude));

            //Assert
            Assert.AreSame(arena, this.context.Object.Arena);
        }

        [Test]
        public void ProcessSetupArenaCommand_EmptyCommandSupplied_ArenaNotCreated()
        {
            //Arrange

            //Act
            this.createArenaCommandReader.Process(string.Empty);

            //Assert
            this.arenaBuilder.Verify(ab => ab.Create(It.IsAny<uint>(), It.IsAny<uint>()), Times.Never());
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoNumbersSeperatedBySpaceSupplied_CreateArenaWithCorrectLatitude()
        {
            //Arrange

            //Act
            this.createArenaCommandReader.Process(string.Format("{0} {1}", latitude, longitude));

            //Assert
            this.arenaBuilder.Verify(ab => ab.Create(latitude, It.IsAny<uint>()), Times.Once());
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoLargeNumbersSeperatedBySpaceSupplied_CreateArenaWithCorrectLatitude()
        {
            //Arrange
            const int largeLatitude = 100;

            //Act
            this.createArenaCommandReader.Process(string.Format("{0} {1}", largeLatitude, longitude));

            //Assert
            this.arenaBuilder.Verify(ab => ab.Create(largeLatitude, It.IsAny<uint>()), Times.Once());
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoNumbersSeperatedBySpaceSupplied_CreateArenaWithCorrectLongitude()
        {
            //Arrange

            //Act
            this.createArenaCommandReader.Process(string.Format("{0} {1}", latitude, longitude));

            //Assert
            this.arenaBuilder.Verify(ab => ab.Create(It.IsAny<uint>(), longitude), Times.Once());
        }

        [Test]
        public void ProcessSetupArenaCommand_LargeLongitudeNumberSupplied_CreateArenaWithCorrectLongitude()
        {
            //Arrange
            const int largeLongitude = 100;

            //Act
            this.createArenaCommandReader.Process(string.Format("{0} {1}", latitude, largeLongitude));

            //Assert
            this.arenaBuilder.Verify(ab => ab.Create(It.IsAny<uint>(), largeLongitude), Times.Once());
        }

        [Test]
        public void ProcessSetupArenaCommand_InvalidSingleArgumentCommandSent_ArenaIsNotCreated()
        {
            //Arrange

            //Act
            this.createArenaCommandReader.Process("5");

            //Assert
            this.arenaBuilder.Verify(ab => ab.Create(It.IsAny<uint>(), It.IsAny<uint>()), Times.Never());
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoLettersSeparatedBySpace_ArenaIsNotCreated()
        {
            //Arrange

            //Act
            this.createArenaCommandReader.Process("A B");

            //Assert
            this.arenaBuilder.Verify(ab => ab.Create(It.IsAny<uint>(), It.IsAny<uint>()), Times.Never());
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoNumbersAndALetter_ArenaIsNotCreated()
        {
            //Arrange

            //Act
            this.createArenaCommandReader.Process("1 2 N");

            //Assert
            this.arenaBuilder.Verify(ab => ab.Create(It.IsAny<uint>(), It.IsAny<uint>()), Times.Never());
        }
    }
}
