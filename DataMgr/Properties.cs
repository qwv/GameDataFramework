using System.Collections.Generic;

namespace Assets.Scripts.Data
{
    public class Properties
    {
        Dictionary<string, string> dict;

        public Properties(Dictionary<string, string> dict)
        {
            this.dict = dict;
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
