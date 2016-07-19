using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class CommandManager
    {
        private Dictionary<CmdName, Creator> commandCreators;

        private List<Queue<Command>> commandQueues;

        private static CommandManager instance;

        public static CommandManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommandManager();
                }
                return instance;
            }
        }

        private CommandManager()
        {            
            // Command
            commandCreators = new Dictionary<CmdName, Creator>();
            commandCreators.Add(CmdName.CREATE_ENTITY, new CommandCreator<CmdCreateEntity>());
            commandCreators.Add(CmdName.PUT_INTO_PACK, new CommandCreator<CmdPutIntoPack>());
            commandQueues = new List<Queue<Command>>();
            for (int i = 0; i < (int)Command.Priority.COUNT; i++)
            {
                commandQueues.Add(new Queue<Command>()); 
            }
        }

        public object RunCommand(CmdName cmdName, params object[] args)
        {
            Command cmd = commandCreators[cmdName].Create(args);
 
            if (cmd != null)
            {
                switch (cmd.GetRunType())
                {
                    case Command.RunType.INSTANT:
                        Logger.Log("Run command: " + cmd.content);
                        return cmd.Execute();
                    case Command.RunType.INTERVAL:
                        commandQueues[(int)cmd.GetPriority()].Enqueue(cmd);
                        break;
                }
            }
            return null;
        }

        public void RunCommandQueue()
        {
            foreach (Queue<Command> queue in commandQueues)
            {
                while (queue.Count != 0)
                {
                    Command cmd = queue.Dequeue();
                    Logger.Log("Run command: " + cmd.content);
                    cmd.Execute();
                }
            }
        }
    }
}
