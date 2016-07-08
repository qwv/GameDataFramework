using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public interface IDataManager
    {
    }

    public class DataManager : IDataManager
    {
        private Dictionary<EntityType, EntityFactory> entityFactories;

        private Dictionary<int, Entity> entities;
        private int entityIdCursor;

        private List<Queue<Command>> commandQueues;

        private static DataManager instance;

        public static IDataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                    instance.Init();
                }
                return instance;
            }
        }

        private void Init()
        {
            entityFactories = new Dictionary<EntityType, EntityFactory>();
            entityFactories.Add(EntityType.ITEM, ItemEntityFactory.Instance);
            entityFactories.Add(EntityType.GOLD, GoldEntityFactory.Instance);
            entityFactories.Add(EntityType.BACKPACK, BackpackEntityFactory.Instance);
            entityFactories.Add(EntityType.DROPPACK, BackpackEntityFactory.Instance);
            entityFactories.Add(EntityType.ENEMY, EnemyEntityFactory.Instance);

            entities = new Dictionary<int, Entity>(); 
            entityIdCursor = 0;

            for (int i = 0; i < (int)Command.Priority.COUNT; i++)
            {
                commandQueues.Add(new Queue<Command>()); 
            }
        }

        private int GenerateEntityId()
        {
            return entityIdCursor++;
        }

        private EntityFactory FindFactory(EntityType type)
        {
            return entityFactories[type];
        }

        public IAvater CreateEntity(EntityType type, params object[] args)
        {
            int entityId = GenerateEntityId(); 
            Entity entity = FindFactory(type).Create(entityId, args);
            entities.Add(entityId, entity);
            return (IAvater)entity;
        }

        public void SaveEntities()
        {

        }
    }
}
