using System.Collections.Generic;

namespace Assets.Scripts.Data.Internal
{
    public class PropertiesWrapper : Properties
    {
        public string tableName;
        public string fieldName;
        public string condition;

        public PropertiesWrapper() { }

        public PropertiesWrapper(Properties properties, string tableName, string fieldName, string condition) 
            : base(properties)
        {
            this.tableName = tableName;
            this.fieldName = fieldName;
            this.condition = condition;
        }

        public void Redirect()
        {
            this.dict = FileDataBase.Instance.Find(tableName, fieldName, condition).dict;
        }

        public int TableCount()
        {
            return FileDataBase.Instance.Count(tableName);
        }
    }

    public class Properties
    {
        protected Dictionary<string, string> dict;

        public Properties()
        {
            dict = new Dictionary<string, string>();
        }

        protected Properties(Properties prop)
        {
            this.dict = prop.dict;
        }

        public void Add(string key, string value)
        {
            dict.Add(key, value);
        }

        public int GetIntValue(string key)
        {
            if (dict.ContainsKey(key)) 
            {
                return int.Parse(dict[key]);
            }
            return 0;
        }

        public float GetFloatValue(string key)
        {
            if (dict.ContainsKey(key)) 
            {
                return float.Parse(dict[key]);
            }
            return 0;
        }

        public string GetStringValue(string key)
        {
            if (dict.ContainsKey(key)) 
            {
                return dict[key];
            }
            return "";
        }
    }
}
