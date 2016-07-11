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

        private Dictionary<string, int> entityStore;

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
            entityIdCursor = 0;
            
            // Entity store
            entityStore = new Dictionary<string, int>();

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

        public Entity GetEntity(int entityId)
        {
            if (entities.ContainsKey(entityId))
            {
                return entities[entityId];
            }
            Debug.Log("Get entity: invalid entity id.");
            return null;
        }

        public Entity GetEntity(string key)
        {
            if (entityStore.ContainsKey(key))
            {
                return GetEntity(entityStore[key]);
            }
            Debug.Log("Get entity: invalid entity key.");
            return null;
        }

        public bool StoreEntity(string key, IAvater avater)
        {
            if (entityStore.ContainsKey(key))
            {
                Debug.Log("Store key is already exist.");
                return false;
            }
            else
            {
                entityStore.Add(key, avater.EntityId());
                return true;
            }
        }

        public void CreateArchive()
        {
            entityStore.Clear();
        }

        public bool HaveArchive(string name)
        {
            return DataSave.HasKey(name);
        }

        public bool ReadArchive(string name)
        {
            if (HaveArchive(name))
            {
                entityStore.Clear();

                Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string,Dictionary<string,string>>();
                dict = DataSave.GetValue<Dictionary<string, Dictionary<string, string>>>(name);

                foreach (KeyValuePair<string, string> kv in dict[name + "__entity__store__"])
                {
                    EntityType type = (EntityType)Enum.Parse(typeof(EntityType), kv.Value);
                    Entity entity = (Entity)CreateEntity(type);
                    entity.Deserialize(dict[kv.Key]);
                    entityStore.Add(kv.Key, entity.entityId);
                }
                return true;
            }
            Debug.Log("Acchive " + name + "is not exist.");
            return false;
        }

        public bool WriteArchive(string name)
        {
            Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string,Dictionary<string,string>>();
            Dictionary<string, string> serializeStore = new Dictionary<string, string>(); 

            foreach (KeyValuePair<string, int> kv in entityStore)
            {
                Entity entity = GetEntity(kv.Value);
                if (entity != null)
                {
                    dict.Add(kv.Key, entity.Serialize());
                    serializeStore.Add(kv.Key, ((IAvater)entity).Type().ToString());
                }
            }

            dict.Add(name + "__entity__store__", serializeStore);
            DataSave.SetValue(name, dict);
            DataSave.ForceWrite();
            return true;
        }

    }
}
