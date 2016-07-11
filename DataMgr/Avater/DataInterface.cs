using UnityEngine;
using Assets.Scripts.Data.Internal;

namespace Assets.Scripts.Data
{
    public enum EntityType
    {
        ITEM,
        GOLD,
        PACK,
        DROPPACK,
        ENEMY,
        CLONE,
    }

    public enum CmdName
    {
        CREATE_ENTITY,
    }

    public static class DataInterface
    {
        public static void Init()
        {
            Debug.Log("Data interface init.");
            // Create data manager instance
            DataManager.Instance.ToString();
        }

        public static IAvater RunCommand(CmdName cmdName, params object[] args)
        {
            return (IAvater)DataManager.Instance.RunCommand(cmdName, args);
        }

        public static void Update()
        {
            DataManager.Instance.RunCommandQueue();
        }

        public static IAvater GetEntity(int entityId)
        {
            return (IAvater)DataManager.Instance.GetEntity(entityId);
        }

        public static IAvater GetEntity(string key)
        {
            return (IAvater)DataManager.Instance.GetEntity(key);
        }

        public static bool StoreEntity(string key, IAvater avater)
        {
            return DataManager.Instance.StoreEntity(key, avater);
        }

        public static void CreateArchive()
        {
            DataManager.Instance.CreateArchive();
        }

        public static bool HaveArchive(string name)
        {
            return DataManager.Instance.HaveArchive(name);
        }

        public static bool ReadArchive(string name)
        {
            return DataManager.Instance.ReadArchive(name);
        }

        public static bool WriteArchive(string name)
        {
            return DataManager.Instance.WriteArchive(name);
        }
    }
}
