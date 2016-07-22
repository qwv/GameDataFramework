
namespace Assets.Scripts.Data.Internal
{
    public class CmdSplitCell : Command
    {
        PackEntity pack;
        CellEntity cell;
        int num;

        public CmdSplitCell() { }

        /// <summary>
        /// Command verify args
        /// </summary>
        /// <param name="args">args[0]:<see cref="EntityType"/></param>
        public override bool Verify(params object[] args)
        {
            content = "SplitCell";
            return true;
        }

        public override void Init(params object[] args)
        {
            pack = (PackEntity)args[0];
            cell = (CellEntity)args[1];
            num = (int)args[2];
        }

        public override object Execute()
        {
            return CellEntity.SplitCell(pack, cell, num);
        }
    }
}
