// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using ToyRobot.Board.Interface;
using ToyRobot.Board;
using ToyRobot.Command;
using ToyRobot.Robot.Interface;
using ToyRobot.Robot;
using ToyRobot.Command.Interface;

namespace ToyRobot
{
    public class Program{

        public static void Main(string[] args){

            const string introduction =
@"   Toy Robot Simulator
  1  Place the robot on a 5 X 5 grid,
     by using the following command:
     PLACE X,Y,F (Where X and Y are integers and F 
     must be either NORTH, SOUTH, EAST or WEST).
     If robot is not placed his position is 0 0 NORTH.

  2  After the robot is placed, 
     move it with the command below:           
     REPORT -- Shows the current position of the robot. 
     LEFT   -- turns the robot to the left (90 degrees).
     RIGHT  -- turns the robot to the right (90 degrees).
     MOVE   -- Moves the robot one square in the facing direction.
     PLACE  -- Change Robot Position.
     EXIT   -- Closes the Toy Robot app.
";
            var stopApp = false;
            IParser parser = new Parser();
            IRobotSimulator robot = new RobotSimulator();
            IBoardSimulator? board = new BoardSimulator(5);
            IRemoteControl? remoteControl = new RemoteControl(robot, board);

            Console.WriteLine(introduction);

            do{
                var cmd = Console.ReadLine();

                if (cmd == null) 
                    continue;
                
                if (cmd.Equals("EXIT"))
                    stopApp = true;
                else 
                {
                    try
                    {
                        var splittedCommand = cmd.Split(' ');
                        var parsedCmd = parser.ParseCommand(splittedCommand);
                        Position? position = null;

                        if (parsedCmd == Command.Command.PLACE){
                            position = parser.ParsePostion(splittedCommand);
                        }
                        
                        remoteControl.ExecuteCommand(parsedCmd, position);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            } while (!stopApp);

        }
    }
}