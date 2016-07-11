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
            return DataManager.Instance.RunCommand(cmdName, args);
        }

        public static void Update()
        {
            DataManager.Instance.RunCommandQueue();
        }
    }
}
