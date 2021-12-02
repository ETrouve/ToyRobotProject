using ToyRobot.Robot;
using ToyRobot.Robot.Interface;

namespace  ToyRobot.Board.Interface
{
    public interface IBoardSimulator{
        bool ValidateCoordinate(Coordinate coordinate);
    }
}