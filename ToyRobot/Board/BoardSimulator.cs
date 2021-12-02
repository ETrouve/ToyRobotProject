using ToyRobot.Robot.Interface;
using ToyRobot.Board.Interface;
using ToyRobot.Robot;

namespace ToyRobot.Board
{
    public class BoardSimulator:IBoardSimulator{

        private int size;

        public BoardSimulator(int size) => this.size = size;

        public bool ValidateCoordinate(Coordinate coordinate){
            return (coordinate.X < size && coordinate.X >= 0 && coordinate.Y < size && coordinate.Y >= 0);
        }
    }   
}