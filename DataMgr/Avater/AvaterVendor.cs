//using System.Collections.Generic;

//namespace Assets.Scripts.Data
//{
//    public static class AvaterVendor
//    {
//        public static IAvater Create(DataEntityType type, Entity entity)
//        {
//            switch (type)
//            {
//                case DataEntityType.ITEM:
//                    return (ItemEntity)entity;

//                case DataEntityType.GOLD:
//                    return (GoldEntity)entity;

//                case DataEntityType.BAG:
//                    return (BagEntity)entity;
//            }

//            IItemAvater a = (ItemEntity)entity;
//            a.Model();
//            return null;
//        }
//    }
//}
