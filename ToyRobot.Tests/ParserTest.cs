using Xunit;
using ToyRobot.Command.Interface;
using ToyRobot.Command;
using ToyRobot.Robot;
using System;

namespace ToyRobot.Tests
{
    public class ParserTest
    {
        private IParser parser = new Parser();

        [Fact]
        public void test()
        {
            string[] cmdFor = new string[] { "PLACE", "6,4,NORTH-EAST" };

            try
            {
                parser.ParsePostion(cmdFor);
            }
            catch (Exception exc)
            {
                Assert.IsType<ArgumentException>(exc);
            }
        }

        [Fact]
        public void ParseUsualTest()
        {
            string[] cmd = new string[] { "Place", "6,4,NORTH" };
            
            Assert.Equal(Command.Command.PLACE, parser.ParseCommand(cmd));

            var parsedPosition = parser.ParsePostion(cmd);
            Assert.Equal(Direction.NORTH, parsedPosition.Direction);
            Assert.Equal(6,parsedPosition.Coordinate.X);
            Assert.Equal(4,parsedPosition.Coordinate.Y);

            string[] cmdMove = new string[] {"MOVE"};
            Assert.Equal(Command.Command.MOVE, parser.ParseCommand(cmdMove));

            string[] cmdLeft = new string[] {"LEFT"};
            Assert.Equal(Command.Command.LEFT, parser.ParseCommand(cmdLeft));

            string[] cmdRight = new string[] {"RIGHT"};
            Assert.Equal(Command.Command.RIGHT, parser.ParseCommand(cmdRight));
        }

        [Fact]
        public void ParseCommandErrorTest()
        {
            //Two empty value
            string[] cmdEmpty = new string[] { "", "" };

            try
            {
                parser.ParseCommand(cmdEmpty);
            }
            catch (Exception exc)
            {
                Assert.IsType<ArgumentException>(exc);
            }

            try
            {
                parser.ParsePostion(cmdEmpty);
            }
            catch (Exception exc)
            {
                Assert.IsType<ArgumentException>(exc);
            }

            //Three empty value
            string[] AnotherCmdEmpty = new string[] { "", "", "" };

            try
            {
                parser.ParsePostion(AnotherCmdEmpty);
            }
            catch (Exception exc)
            {
                Assert.IsType<ArgumentException>(exc);
            }

            //Bad command value + bad position value
            string[] BadCmd = new string[] { "BAD-CMD", "BadPosition" };

            try
            {
                parser.ParseCommand(BadCmd);
            }
            catch (Exception exc)
            {
                Assert.IsType<ArgumentException>(exc);
            }

            try
            {
                parser.ParsePostion(BadCmd);
            }
            catch (Exception exc)
            {
                Assert.IsType<ArgumentException>(exc);
            }

            //Bad direction value
            string[] BadPositionOnlyCmd = new string[] { "PLACE", "0,4,NORTH-EAST" };

            try
            {
                parser.ParseCommand(BadPositionOnlyCmd);
            }
            catch (Exception exc)
            {
                Assert.IsType<ArgumentException>(exc);
            }

            try
            {
                parser.ParsePostion(BadPositionOnlyCmd);
            }
            catch (Exception exc)
            {
                Assert.IsType<ArgumentException>(exc);
            }

            //Uncompleted position
            string[] IncompletePlaceCmd = new string[] { "PLACE", "0,4" };

            try
            {
                parser.ParsePostion(IncompletePlaceCmd);
            }
            catch (Exception exc)
            {
                Assert.IsType<ArgumentException>(exc);
            }

            string[] badCoordinateCmd = new string[] { "PLACE", "z,z,NORTH" };

            try
            {
                parser.ParsePostion(badCoordinateCmd);
            }
            catch (Exception exc)
            {
                Assert.IsType<ArgumentException>(exc);
            }
        }
    }
}