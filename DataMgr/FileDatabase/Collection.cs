using System.Collections.Generic;
using System;

namespace Assets.Scripts.Data.Internal
{
    public class Collection
    {
        private Dictionary<int, Properties> collection;

        public string primaryKey;

        public Collection()
        {
            collection = new Dictionary<int, Properties>();
        }

        public void Insert(int key, Properties prop)
        {
            collection.Add(key, prop);
        }

        public Properties Find(string fieldName, string condition)
        {
            Logger.Assert(primaryKey != fieldName, "DB Error: Invaild field name.");
            int key = Convert.ToInt32(condition);
            Logger.Assert(!collection.ContainsKey(key), "DB Error: Invaild key.");
            return collection[key];
        }

        public int Count()
        {
            return collection.Count;
        }
    }
}
