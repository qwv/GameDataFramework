using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Assets.Scripts.Data.Internal
{
    public class Table
    {
        public const string ITEM = "item_list";
        public const string EQUIPMENT = "equipment_list";
        public const string DROP = "drop_list";
        public const string ENEMY = "enemy_list";
        public const string SKILL = "skill_list";
        public const string PLAYER = "player_";
    }

    public class FileDataBase
    {
        public const string LOCAL_DB_SOURCE_PATH = "Config/DataBase/";

        private Dictionary<string, Collection> db;

        private static FileDataBase instance;

        public static FileDataBase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileDataBase();
                }
                return instance;
            }
        }

        private FileDataBase()
        {
            db = new Dictionary<string, Collection>();
        }

        public void Load(string tableName)
        {
            string sourcePath = LOCAL_DB_SOURCE_PATH + tableName;
            TextAsset xmlText = Resources.Load(sourcePath) as TextAsset;
            Debug.Assert(xmlText == null, "DB error: " + sourcePath + " not found!");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlText.text);
            XmlNode content = xmlDoc.SelectSingleNode("/content");

            Collection collection = new Collection();
            foreach (XmlNode node in content)
            {
                Properties prop = new Properties();
                string primaryKey = node.LocalName;
                int key = XmlConvert.ToInt32(node.Attributes[primaryKey].Value);
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    string name = attribute.Name;
                    string value = attribute.Value;
                    prop.Add(name, value);
                }
                collection.primaryKey = primaryKey;
                collection.Insert(key, prop);
            }
            db.Add(tableName, collection);

            xmlDoc = null;
        }

        public bool Exist(string tableName)
        {
            return db.ContainsKey(tableName);
        }

        public Properties Find(string tableName, string fieldName, string condition)
        {
            if (!Exist(tableName))
            {
                Load(tableName);
            }

            return db[tableName].Find(fieldName, condition);
        }
    }
}
