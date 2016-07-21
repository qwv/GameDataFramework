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
            commandCreators.Add(CmdName.FIND_IN_PACK, new CommandCreator<CmdFindInPack>());
            commandCreators.Add(CmdName.SWAP_CELL, new CommandCreator<CmdSwapCell>());
            commandCreators.Add(CmdName.MERGE_CELL, new CommandCreator<CmdMergeCell>());
            commandCreators.Add(CmdName.SPLIT_CELL, new CommandCreator<CmdSplitCell>());
            commandCreators.Add(CmdName.ADD_PLAYER_EXP, new CommandCreator<CmdAddPlayerExp>());
            commandCreators.Add(CmdName.SET_EQUIPMENT_PACK, new CommandCreator<CmdSetEquipmentPack>());
            commandCreators.Add(CmdName.ENFORCE_EQUIPMENT, new CommandCreator<CmdEnforceEquipment>());
            commandCreators.Add(CmdName.ATTACK, new CommandCreator<CmdAttack>());
            commandCreators.Add(CmdName.SKILL, new CommandCreator<CmdSkill>());

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
