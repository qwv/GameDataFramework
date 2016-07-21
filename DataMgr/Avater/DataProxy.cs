using Assets.Scripts.Data.Internal;

namespace Assets.Scripts.Data
{
    public delegate void Notification();

    public enum EntityType
    {
        CELL,
        PACK,
        DROPPACK,
        GOLD,
        ITEM,
        EQUIPMENT,
        PLAYER,
        ENEMY,
        SKILL,
        CLONE,
    }

    public enum CmdName
    {
        // Entity
        CREATE_ENTITY,
        // Pack and cell
        PUT_INTO_PACK,
        FIND_IN_PACK,
        SWAP_CELL,
        MERGE_CELL,
        SPLIT_CELL,
        // Player
        ADD_PLAYER_EXP,
        // Equipment
        SET_EQUIPMENT_PACK,
        ENFORCE_EQUIPMENT,
        // Damage
        ATTACK,
        SKILL,
    }

    public static class DataProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Update()
        {
            CommandManager.Instance.RunCommandQueue();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object RunCommand(CmdName cmdName, params object[] args)
        {
            return CommandManager.Instance.RunCommand(cmdName, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public static IAvater GetEntity(int entityId)
        {
            return (IAvater)EntityManager.Instance.GetEntity(entityId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IAvater GetEntity(string key)
        {
            return (IAvater)ArchiveManager.Instance.GetEntity(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="avater"></param>
        /// <returns></returns>
        public static bool StoreEntity(string key, IAvater avater)
        {
            return ArchiveManager.Instance.StoreEntity(key, avater);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool HaveArchive(string name)
        {
            return ArchiveManager.Instance.HaveArchive(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ReadArchive(string name)
        {
            return ArchiveManager.Instance.ReadArchive(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool WriteArchive(string name)
        {
            return ArchiveManager.Instance.WriteArchive(name);
        }
    }
}
