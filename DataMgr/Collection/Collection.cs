using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Assets.Scripts.Data.Internal
{
    public class Collection
    {
        private Dictionary<int, Properties> collection;

        public Collection()
        {
            collection = new Dictionary<int, Properties>();
        }

        public void Load(string sourcePath)
        {
            TextAsset xmlText = Resources.Load(sourcePath) as TextAsset;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlText.text);
            XmlNode content = xmlDoc.SelectSingleNode("/content");

            foreach (XmlNode node in content)
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                int id = XmlConvert.ToInt32(node.Attributes["id"].Value);
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    string name = attribute.Name;
                    string value = attribute.Value;
                    data.Add(name, value);
                }
                collection.Add(id, new Properties(data));
            }
            xmlDoc = null;
        }

        public Properties Get(int id)
        {
            Debug.Assert(collection.ContainsKey(id), "Collection Invaild id.");
            return collection[id];
        }
    }
}
