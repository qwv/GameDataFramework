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
        /// Data system update, call it in MonoBehaviour Update or LaterUpdate
        /// </summary>
        public static void Update()
        {
            CommandManager.Instance.RunCommandQueue();
        }

        /// <summary>
        /// Run command by command's name and arguments
        /// </summary>
        /// <param name="cmdName">Command Name <see cref="CmdName"/></param>
        /// <param name="args">
        /// CREATE_ENTITY need args: 
        /// 1. type <see cref="EntityType"/> 
        /// 2. id if read from config or gold num or pack capacity etc 
        /// 3. player level etc  
        /// PUT_INTO_PACK need args: 
        /// 1. pack
        /// 2. entity
        /// FIND_IN_PACK need args: 
        /// 1. pack
        /// 2. entity
        /// SWAP_CELL need args: 
        /// 1. cell 1
        /// 2. cell 2
        /// MERGE_CELL need args: 
        /// 1. cell 1
        /// 2. cell 2
        /// SPLIT_CELL need args: 
        /// 1. pack
        /// 2. cell
        /// 3. split num
        /// ADD_PLAYER_EXP need args: 
        /// 1. player
        /// 2. exp num
        /// 3. level up notification if needed
        /// SET_EQUIPMENT_PACK need args: 
        /// 1. player
        /// 2. pack name, the key to store entity
        /// ENFORCE_EQUIPMENT need args: 
        /// 1. player
        /// ATTACK need args:
        /// 1. attacker
        /// 2. target
        /// SKILL need args:
        /// 1. attacker
        /// 2. target
        /// 3. skill
        /// </param>
        /// <returns>Return command executing result</returns>
        public static object RunCommand(CmdName cmdName, params object[] args)
        {
            return CommandManager.Instance.RunCommand(cmdName, args);
        }

        /// <summary>
        /// Get entity avater by entity id
        /// </summary>
        /// <param name="entityId">Entity id</param>
        /// <returns>Avater <see cref="IAvater"/></returns>
        public static IAvater GetEntity(int entityId)
        {
            return (IAvater)EntityManager.Instance.GetEntity(entityId);
        }

        /// <summary>
        /// Get entity avater by entity key
        /// </summary>
        /// <param name="key">The key to store entity</param>
        /// <returns>Avater <see cref="IAvater"/></returns>
        public static IAvater GetEntity(string key)
        {
            return (IAvater)ArchiveManager.Instance.GetEntity(key);
        }

        /// <summary>
        /// Store the entity by key, which need write to archive
        /// </summary>
        /// <param name="key">The key to store entity</param>
        /// <param name="avater">Avater <see cref="IAvater"/></param>
        /// <returns>Return false if the key is already exist</returns>
        public static bool StoreEntity(string key, IAvater avater)
        {
            return ArchiveManager.Instance.StoreEntity(key, avater);
        }

        /// <summary>
        /// Have archive
        /// </summary>
        /// <param name="name">Archive name</param>
        /// <returns>Return true if the archive is exist</returns>
        public static bool HaveArchive(string name)
        {
            return ArchiveManager.Instance.HaveArchive(name);
        }

        /// <summary>
        /// Read archive by name
        /// </summary>
        /// <param name="name">Archive name</param>
        /// <returns>Return true if read success</returns>
        public static bool ReadArchive(string name)
        {
            return ArchiveManager.Instance.ReadArchive(name);
        }

        /// <summary>
        /// Write archive by name
        /// </summary>
        /// <param name="name">Archive name</param>
        /// <returns>Return true</returns>
        public static bool WriteArchive(string name)
        {
            return ArchiveManager.Instance.WriteArchive(name);
        }
    }
}
