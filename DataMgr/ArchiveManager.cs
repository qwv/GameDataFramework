using System.Collections.Generic;
using System.Xml;
using System;
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
                return DataManager.Instance.GetEntity(entityStore[key]);
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

                foreach (KeyValuePair<string, string> kv in dict[name + "__vr__archive__"])
                {
                    EntityType type = (EntityType)Enum.Parse(typeof(EntityType), kv.Value);
                    Entity entity = (Entity)DataManager.Instance.CreateEntity(type);
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
                Entity entity = DataManager.Instance.GetEntity(kv.Value);
                if (entity != null)
                {
                    dict.Add(kv.Key, entity.Serialize());
                    serializeStore.Add(kv.Key, entity.type.ToString());
                }
            }

            dict.Add(name + "__vr__archive__", serializeStore);
            DataSave.SetValue(name, dict);
            DataSave.ForceWrite();
            return true;
        }
    }
}
