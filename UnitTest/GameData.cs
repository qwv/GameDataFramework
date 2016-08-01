using System.Collections.Generic;
using Assets.Scripts.Data;

namespace Assets.Scripts.Game
{
    public class DataAlias
    {
        // Store avater alias
        public const string PLAYER = "player";
        public const string EQUIPPACK = "equippack";
        public const string BACKPACK = "backpack";
        public const string GOLD = "gold";

        // Player
        public const int PLAYER_ID = 101;

        // Enemy list
        public const int ELEPHANT_ID = 101;
        public const int LONGXIA_ID = 201;
        
        // Skill list player
        public const int SKILL_DA_YING_RUO_CHONG = 101;
        public const int SKILL_GUI_YUAN = 102;
        public const int SKILL_TIAN_JIAN = 103;
        public const int SKILL_LEI_GANG_JIE_JIE = 104;
        public const int SKILL_LONG = 105;
        public const int SKILL_XIAO_SHI_TOU_FAN_JI = 909;
        public const int SKILL_ZHONG_SHI_TOU_FAN_JI = 910;
        // Skill list elephant
        public const int SKILL_HENG_KAN= 901;
        public const int SKILL_SHU_KAN = 902;
        public const int SKILL_TIAO_KAN = 903;
        public const int SKILL_TIAO_YUE_ZHONG_KAN = 904;
        public const int SKILL_CHONG_CI = 905;
        public const int SKILL_XIAO_SHI_TOU = 906;
        public const int SKILL_ZHONG_SHI_TOU = 907;
        public const int SKILL_DA_SHI_TOU = 908;

        // Equipment list
        public const int EQUIP_FRESH_HAND_SWORD = 200001;

        // Item list
        public const int ITEM_IRON_ORE = 100001;
        public const int ITEM_COPPER_ORE = 100002;
        public const int ITEM_SILVER_ORE = 100003;
        public const int ITEM_GOLD_ORE = 100004;

        // Drop pack list
        public const int DROPPACK_CHESTS_1 = 900001;
        public const int DROPPACK_CHESTS_2 = 900002;
    }

    public class GameData
    {
        public const string ARCHIVE_1 = "__vr__archive__1__";

        public string currentArchive;

        private Dictionary<int, ISkillAvater> skillBuffer;

        private static GameData instance;

        public static GameData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameData();
                }
                return instance;
            }
        }

        private GameData()
        {
            // Init skill buffer 
            skillBuffer = new Dictionary<int, ISkillAvater>();
            // Player skill
            skillBuffer.Add(DataAlias.SKILL_DA_YING_RUO_CHONG, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_DA_YING_RUO_CHONG));
            skillBuffer.Add(DataAlias.SKILL_GUI_YUAN, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_GUI_YUAN));
            skillBuffer.Add(DataAlias.SKILL_TIAN_JIAN, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_TIAN_JIAN));
            skillBuffer.Add(DataAlias.SKILL_LEI_GANG_JIE_JIE, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_LEI_GANG_JIE_JIE));
            skillBuffer.Add(DataAlias.SKILL_LONG, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_LONG));
            skillBuffer.Add(DataAlias.SKILL_XIAO_SHI_TOU_FAN_JI, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_XIAO_SHI_TOU_FAN_JI));
            skillBuffer.Add(DataAlias.SKILL_ZHONG_SHI_TOU_FAN_JI, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_ZHONG_SHI_TOU_FAN_JI));
            // Elephant skill 
            skillBuffer.Add(DataAlias.SKILL_HENG_KAN, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_HENG_KAN));
            skillBuffer.Add(DataAlias.SKILL_SHU_KAN, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_SHU_KAN));
            skillBuffer.Add(DataAlias.SKILL_TIAO_KAN, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_TIAO_KAN));
            skillBuffer.Add(DataAlias.SKILL_TIAO_YUE_ZHONG_KAN, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_TIAO_YUE_ZHONG_KAN));
            skillBuffer.Add(DataAlias.SKILL_CHONG_CI, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_CHONG_CI));
            skillBuffer.Add(DataAlias.SKILL_XIAO_SHI_TOU, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_XIAO_SHI_TOU));
            skillBuffer.Add(DataAlias.SKILL_ZHONG_SHI_TOU, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_ZHONG_SHI_TOU));
            skillBuffer.Add(DataAlias.SKILL_DA_SHI_TOU, (ISkillAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.SKILL, DataAlias.SKILL_DA_SHI_TOU));
        }

        public void Load(string archive)
        {
            if (currentArchive != archive)
            {
                if (DataProxy.HaveArchive(archive))
                {
                    DataProxy.ReadArchive(archive);
                }
                else
                {
                    NewGame(archive);
                }

                RebuildReference();

                currentArchive = archive;
            }
        }

        public void Save()
        {
            if (currentArchive != null)
            {
                DataProxy.WriteArchive(currentArchive);
            }
        }

        public void NewGame(string archive)
        {
            IPlayerAvater player = (IPlayerAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.PLAYER, DataAlias.PLAYER_ID, 1);
            IPackAvater equippack = (IPackAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.PACK, 1);
            IPackAvater backpack = (IPackAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.PACK, 16);

            DataProxy.StoreEntity(DataAlias.PLAYER, player);
            DataProxy.StoreEntity(DataAlias.EQUIPPACK, equippack);
            DataProxy.StoreEntity(DataAlias.BACKPACK, backpack);

            IAvater weapon = (IAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.EQUIPMENT, DataAlias.EQUIP_FRESH_HAND_SWORD);
            DataProxy.RunCommand(CmdName.PUT_INTO_PACK, equippack, weapon);
            DataProxy.RunCommand(CmdName.SET_EQUIPMENT_PACK, player, DataAlias.EQUIPPACK);

            DataProxy.WriteArchive(archive);
        }

        public void RebuildReference()
        {
            DataProxy.RunCommand(CmdName.ENFORCE_EQUIPMENT, DataProxy.GetEntity(DataAlias.PLAYER));
        }

        public ISkillAvater SkillAvater(int alias)
        {
            if (skillBuffer.ContainsKey(alias))
            {
                return skillBuffer[alias];
            }
            return null;
        }

        public void SamplerDroppack()
        {
            IDroppackAvater droppack = (IDroppackAvater)DataProxy.RunCommand(CmdName.CREATE_ENTITY, EntityType.DROPPACK, DataAlias.DROPPACK_CHESTS_1);
            int dropNum = droppack.Count();
            for (int i = 0; i < dropNum; i++)
            {
                ICellAvater cell = droppack.Cell(i);
                switch (cell.Goods().Type())
                {
                    case EntityType.ITEM:
                        IItemAvater item = (IItemAvater)cell.Goods();
                        DataProxy.RunCommand(CmdName.PUT_INTO_PACK, DataProxy.GetEntity(DataAlias.BACKPACK), item);
                        break;
                    case EntityType.GOLD:
                        IGoldAvater gold = (IGoldAvater)cell.Goods();
                        break;
                }
            }
        }
    }
}
