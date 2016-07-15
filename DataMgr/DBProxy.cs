#define __USE_FILE_DATABASE__

namespace Assets.Scripts.Data.Internal
{
    public static class DBProxy
    {
        public static Properties Find(string tableName, string fieldName, string condition)
        {
#if __USE_FILE_DATABASE__
            return FileDataBase.Instance.Find(tableName, fieldName, condition);
#endif
        }
    }
}
