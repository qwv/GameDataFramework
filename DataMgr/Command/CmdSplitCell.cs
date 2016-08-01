using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdSplitCell : Command
    {
        PackEntity pack;
        CellEntity cell;
        int num;

        public CmdSplitCell() 
        {
            message = base.GetType().Name;
            argsType = new Type[] { typeof(PackEntity), typeof(CellEntity), typeof(int) };
        }

        public override void Init(params object[] args)
        {
            pack = (PackEntity)args[0];
            cell = (CellEntity)args[1];
            num = (int)args[2];

            message += " " + pack.DebugTag();
            message += " " + cell.DebugTag();
            message += " " + num.ToString();
        }

        public override object Execute()
        {
            return CellEntity.SplitCell(pack, cell, num);
        }
    }
}
