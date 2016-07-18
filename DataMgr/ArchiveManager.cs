using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data.Internal
{
    public class ArchiveManager
    {
        private Dictionary<string, int> entityStore;

        private static ArchiveManager instance;

        public static ArchiveManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ArchiveManager();
                }
                return instance;
            }
        }

        private ArchiveManager()
        {
            // Entity store
            entityStore = new Dictionary<string, int>();
        }

        public Entity GetEntity(string key)
        {
            if (entityStore.ContainsKey(key))
            {
                return EntityManager.Instance.GetEntity(entityStore[key]);
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

                Dictionary<string, object> serializeStore = new Dictionary<string, object>();
                serializeStore = DataSave.GetValue<Dictionary<string, object>>(name);

                foreach (KeyValuePair<string, object> kv in serializeStore)
                {
                    Entity entity = EntityManager.Instance.CreateEntity(EntityType.CLONE, kv.Value);
                    entityStore.Add(kv.Key, entity.entityId);
                }
                Debug.Log("Archive " + name + "read success.");
                return true;
            }
            Debug.Log("Archive " + name + "is not exist.");
            return false;
        }

        public bool WriteArchive(string name)
        {
            Dictionary<string, object> serializeStore = new Dictionary<string, object>(); 

            foreach (KeyValuePair<string, int> kv in entityStore)
            {
                Entity entity = EntityManager.Instance.GetEntity(kv.Value);
                if (entity != null)
                {
                    serializeStore.Add(kv.Key, entity);
                }
            }

            DataSave.SetValue(name, serializeStore);
            DataSave.ForceWrite();
            Debug.Log("Archive " + name + "write success.");
            return true;
        }
    }
}
