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

    public static class DataProxy
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
            return (IAvater)ArchiveManager.Instance.GetEntity(key);
        }

        public static bool StoreEntity(string key, IAvater avater)
        {
            return ArchiveManager.Instance.StoreEntity(key, avater);
        }

        public static void CreateArchive()
        {
            ArchiveManager.Instance.CreateArchive();
        }

        public static bool HaveArchive(string name)
        {
            return ArchiveManager.Instance.HaveArchive(name);
        }

        public static bool ReadArchive(string name)
        {
            return ArchiveManager.Instance.ReadArchive(name);
        }

        public static bool WriteArchive(string name)
        {
            return ArchiveManager.Instance.WriteArchive(name);
        }
    }
}
