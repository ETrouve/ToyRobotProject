using Xunit;
using ToyRobot.Board;
using ToyRobot.Board.Interface;
using ToyRobot.Robot;

namespace ToyRobot.Tests{
    public class BoardSimulatorTest{
        private IBoardSimulator boardSimulator = new BoardSimulator(5);

        [Fact]
        public void ValidateGoodCoordinateTest(){
            Assert.True(boardSimulator.ValidateCoordinate(new Coordinate(0,1)));
            Assert.True(boardSimulator.ValidateCoordinate(new Coordinate(0,4)));
            Assert.True(boardSimulator.ValidateCoordinate(new Coordinate(4,0)));
        }

        [Fact]
        public void ValidateBadCoordinateTest(){
            Assert.False(boardSimulator.ValidateCoordinate(new Coordinate(0,6)));
            Assert.False(boardSimulator.ValidateCoordinate(new Coordinate(0,5)));
            Assert.False(boardSimulator.ValidateCoordinate(new Coordinate(5,0)));
            Assert.False(boardSimulator.ValidateCoordinate(new Coordinate(-1,0)));
            Assert.False(boardSimulator.ValidateCoordinate(new Coordinate(0,-1)));
        }
    }
}