using ToyRobot.Robot;

namespace  ToyRobot.Command.Interface
{
    public interface IParser{
        Command ParseCommand(string[] cmd);
        
        Position ParsePostion(string[] cmd);
    }
}