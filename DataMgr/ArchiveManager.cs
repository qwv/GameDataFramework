using System.Collections.Generic;
using System;
using UnityEngine;
using Newtonsoft.Json;

namespace Assets.Scripts.Data.Internal
{
    public class SerializeEntity
    {
        public string classType;
        public string jsonDict;

        public SerializeEntity() { }

        public SerializeEntity(Entity entity)
        {
            classType = entity.GetType().ToString();

            if (classType == typeof(PackEntity).ToString() || classType == typeof(DroppackEntity).ToString())
            {
                jsonDict = SerializePackEntity((PackEntity)entity);
            }
            else if (classType == typeof(CellEntity).ToString())
            {
                jsonDict = SerializeCellEntity((CellEntity)entity);
            }
            else
            {
                jsonDict = JsonConvert.SerializeObject(entity);
            }
        }

        public Entity DeSerializeEntity()
        {
            Entity entity;

            if (classType == typeof(PackEntity).ToString() || classType == typeof(DroppackEntity).ToString())
            {
                entity = DeSerializePackEntity();
            }
            else if (classType == typeof(CellEntity).ToString())
            {
                entity = DeSerializeCellEntity();
            }
            else
            {
                entity = (Entity)JsonConvert.DeserializeObject(jsonDict, Type.GetType(classType));
            }

            RedirectProperties(entity);

            return entity;
        }

        public string SerializePackEntity(PackEntity entity)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("capacity", entity.capacity.ToString());

            for (int i = 0; i < entity.capacity; i++)
            {
                dict.Add("cell" + i, JsonConvert.SerializeObject(new SerializeEntity(entity.cells[i])));
            }
            return JsonConvert.SerializeObject(dict);
        }

        private Entity DeSerializePackEntity()
        {
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonDict);

            PackEntity entity = new PackEntity();
            entity.capacity = Convert.ToInt32(dict["capacity"]);
            entity.cells = new List<CellEntity>(entity.capacity);

            for (int i = 0; i < entity.capacity; i++)
            {
                entity.cells.Add((CellEntity)JsonConvert.DeserializeObject<SerializeEntity>(dict["cell" + i]).DeSerializeEntity());
            }
            return entity;
        }

        public string SerializeCellEntity(CellEntity entity)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("stack", entity.stack.ToString());
            if (entity.stack > 0)
            {
                dict.Add("goods", JsonConvert.SerializeObject(new SerializeEntity(entity.goods)));
            }
            return JsonConvert.SerializeObject(dict);
        }

        private Entity DeSerializeCellEntity()
        {
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonDict);

            CellEntity entity = new CellEntity();
            entity.stack = Convert.ToInt32(dict["stack"]);
            if (entity.stack > 0)
            {
                entity.goods = (Entity)JsonConvert.DeserializeObject<SerializeEntity>(dict["goods"]).DeSerializeEntity();
            }
            return entity;
        }

        private void RedirectProperties(Entity entity)
        {
            if (entity.properties != null)
            {
                entity.properties.Redirect();
            }
        }
    }

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
            Logger.LogError("Get entity: invalid entity key.");
            return null;
        }

        public bool StoreEntity(string key, IAvater avater)
        {
            if (entityStore.ContainsKey(key))
            {
                Logger.LogError("Store key is already exist.");
                return false;
            }
            else
            {
                entityStore.Add(key, avater.EntityId());
                return true;
            }
        }

        public void Reset()
        {
            entityStore.Clear();
        }

        public bool HaveArchive(string name)
        {
            return PlayerPrefs.HasKey(name);
        }

        public bool ReadArchive(string name)
        {
            if (HaveArchive(name))
            {
                Reset();

                Dictionary<string, SerializeEntity> serializeStore = new Dictionary<string, SerializeEntity>();
                serializeStore = JsonConvert.DeserializeObject<Dictionary<string, SerializeEntity>>(PlayerPrefs.GetString(name));

                foreach (KeyValuePair<string, SerializeEntity> kv in serializeStore)
                {
                    Entity entity = EntityManager.Instance.CreateEntity(EntityType.CLONE, kv.Value.DeSerializeEntity());
                    entityStore.Add(kv.Key, entity.entityId);
                }
                Logger.Log("Read Archive " + name + " success.");
                return true;
            }
            Logger.LogError("Read Archive " + name + " is not exist.");
            return false;
        }

        public bool WriteArchive(string name)
        {
            Dictionary<string, SerializeEntity> serializeStore = new Dictionary<string, SerializeEntity>(); 

            foreach (KeyValuePair<string, int> kv in entityStore)
            {
                Entity entity = EntityManager.Instance.GetEntity(kv.Value);
                if (entity != null)
                {
                    serializeStore.Add(kv.Key, new SerializeEntity(entity));
                }
            }

            PlayerPrefs.SetString(name, JsonConvert.SerializeObject(serializeStore));
            PlayerPrefs.Save();
            Logger.Log("Write Archive " + name + " success.");
            return true;
        }
    }
}
