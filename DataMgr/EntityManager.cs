using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data.Internal
{
    public class EntityManager
    {
        private Dictionary<EntityType, Factory> entityFactories;

        private Dictionary<int, Entity> entities;

        private int entityIdCursor;

        private static EntityManager instance;

        public static EntityManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EntityManager();
                }
                return instance;
            }
        }

        private EntityManager()
        {
            // Entity
            entityFactories = new Dictionary<EntityType, Factory>();
            entityFactories.Add(EntityType.CELL, new StandardFactory<CellEntity>());
            entityFactories.Add(EntityType.PACK, new StandardFactory<PackEntity>());
            entityFactories.Add(EntityType.DROPPACK, new StandardFactory<DroppackEntity>(DroppackBuilder.Instance));
            entityFactories.Add(EntityType.GOLD, new StandardFactory<GoldEntity>());
            entityFactories.Add(EntityType.ITEM, new StandardFactory<ItemEntity>(ItemBuilder.Instance));
            entityFactories.Add(EntityType.EQUIPMENT, new StandardFactory<EquipmentEntity>(EquipmentBuilder.Instance));
            entityFactories.Add(EntityType.PLAYER, new StandardFactory<PlayerEntity>(PlayerBuilder.Instance));
            entityFactories.Add(EntityType.ENEMY, new StandardFactory<EnemyEntity>(EnemyBuilder.Instance));
            entityFactories.Add(EntityType.SKILL, new StandardFactory<SkillEntity>(SkillBuilder.Instance));
            entityFactories.Add(EntityType.CLONE, CloneFactory.Instance);

            entities = new Dictionary<int, Entity>(); 
            entityIdCursor = 100000;
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
    }
}
