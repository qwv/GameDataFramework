using System.Collections.Generic;
using System.Xml;
using System;
using UnityEngine;

namespace Assets.Scripts.Data.Internal
{
    public class DataManager
    {
        private Dictionary<EntityType, Factory> entityFactories;

        private Dictionary<int, Entity> entities;

        private int entityIdCursor;

        private Dictionary<CmdName, Creator> commandCreators;

        private List<Queue<Command>> commandQueues;

        private static DataManager instance;

        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }
                return instance;
            }
        }

        private DataManager()
        {
            // Entity
            entityFactories = new Dictionary<EntityType, Factory>();
            entityFactories.Add(EntityType.ITEM, new StandardFactory<ItemEntity>(ItemBuilder.Instance));
            entityFactories.Add(EntityType.GOLD, new StandardFactory<GoldEntity>());
            entityFactories.Add(EntityType.PACK, new StandardFactory<PackEntity>());
            entityFactories.Add(EntityType.DROPPACK, new StandardFactory<DroppackEntity>(DroppackBuilder.Instance));
            entityFactories.Add(EntityType.ENEMY, new StandardFactory<EnemyEntity>(EnemyBuilder.Instance));
            entityFactories.Add(EntityType.CLONE, CloneFactory.Instance);

            entities = new Dictionary<int, Entity>(); 
            entityIdCursor = 10000;
            
            // Command
            commandCreators = new Dictionary<CmdName, Creator>();
            commandCreators.Add(CmdName.CREATE_ENTITY, new CommandCreator<CmdCreateEntity>());
            commandQueues = new List<Queue<Command>>();
            for (int i = 0; i < (int)Command.Priority.COUNT; i++)
            {
                commandQueues.Add(new Queue<Command>()); 
            }
        }

        private int GenerateEntityId()
        {
            return entityIdCursor++;
        }

        public Entity CreateEntity(EntityType type, params object[] args)
        {
            int entityId = GenerateEntityId();
            Entity entity = entityFactories[type].Create(entityId, args);
            entities.Add(entityId, entity);
            return entity;
        }

        public Entity GetEntity(int entityId)
        {
            if (entities.ContainsKey(entityId))
            {
                return entities[entityId];
            }
            Debug.Log("Get entity: invalid entity id.");
            return null;
        }

        public object RunCommand(CmdName cmdName, params object[] args)
        {
            Command cmd = commandCreators[cmdName].Create(args);
            switch (cmd.GetRunType())
            {
                case Command.RunType.INSTANT:
                    return cmd.Execute();
                case Command.RunType.INTERVAL:
                    commandQueues[(int)cmd.GetPriority()].Enqueue(cmd);
                    break;
            }
            Debug.Log("Run command: invalid command name.");
            return null;
        }

        public void RunCommandQueue()
        {
            foreach (Queue<Command> queue in commandQueues)
            {
                while (queue.Count != 0)
                {
                    Command cmd = queue.Dequeue();
                    cmd.Execute();
                }
            }
        }
    }
}
