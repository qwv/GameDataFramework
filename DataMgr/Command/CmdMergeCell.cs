
namespace Assets.Scripts.Data.Internal
{
    public class CmdMergeCell : Command
    {
        CellEntity cell1;
        CellEntity cell2;

        public CmdMergeCell() { }

        /// <summary>
        /// Command verify args
        /// </summary>
        /// <param name="args">args[0]:<see cref="EntityType"/></param>
        public override bool Verify(params object[] args)
        {
            return true;
        }

        public override void Init(params object[] args)
        {
            cell1 = (CellEntity)args[0];
            cell2 = (CellEntity)args[1];
        }

        public override object Execute()
        {
            return CellEntity.MergeCell(cell1, cell2);
        }
    }
}
