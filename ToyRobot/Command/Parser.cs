using ToyRobot.Command.Interface;
using ToyRobot.Robot;
using System;

namespace ToyRobot.Command
{
    public class Parser : IParser
    {
        public Command ParseCommand(string[] cmd)
        {
            int numberOfArgs = cmd.Count();
            
            if(numberOfArgs == 0 || numberOfArgs > 2){
                throw new ArgumentException($"Bad input, it must be MOVE, LEFT, RIGHT, REPORT or PLACE X,Y,D where X and Y are integers and D must be either NORTH, SOUTH, EAST or WEST");
            }

            Command command;

            if(!Enum.TryParse(cmd[0].ToUpper(), out command)){
                throw new ArgumentException($"Bad command in input: \"{cmd[0]}\", command should be ether PLACE, MOVE, LEFT, RIGHT or REPORT");
            }
            
            return command;
        }

        public Position ParsePostion(string[] cmd)
        {   
            var positionParams = cmd[1].Split(',');
            int x;
            int y;

            if(positionParams.Count() != 3){
                throw new ArgumentException($"Bad position component input, it must be X,Y,D where Where X and Y are integers and D must be either NORTH, SOUTH, EAST or WEST");
            }

            if(!(int.TryParse(positionParams[0].ToUpper(), out x) && (int.TryParse(positionParams[1], out y)))){
                throw new ArgumentException($"Bad coordinates type in input must be int");
            }

            Direction direction;

            if(!Enum.TryParse(positionParams[2], out direction)){
                throw new ArgumentException($"Bad direction input: {positionParams[2]}, direction must be ether NORTH, EAST, SOUTH or WEST");
            }

            return new Position{
                Coordinate = new Coordinate(x, y),
                Direction = direction
            };
        }
    }
}