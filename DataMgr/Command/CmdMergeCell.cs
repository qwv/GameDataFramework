using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdMergeCell : Command
    {
        CellEntity cell1;
        CellEntity cell2;

        public CmdMergeCell()
        {
            message = base.GetType().Name;
            argsType = new Type[] { typeof(CellEntity), typeof(CellEntity) };
        }

        public override void Init(params object[] args)
        {
            cell1 = (CellEntity)args[0];
            cell2 = (CellEntity)args[1];

            message += " " + cell1.DebugTag();
            message += " " + cell2.DebugTag();
        }

        public override object Execute()
        {
            return CellEntity.MergeCell(cell1, cell2);
        }
    }
}
