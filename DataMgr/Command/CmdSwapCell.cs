﻿using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdSwapCell : Command
    {
        CellEntity cell1;
        CellEntity cell2;

        public CmdSwapCell() 
        {
            argsType = new Type[] { typeof(CellEntity), typeof(CellEntity) };
        }

        public override void Init(params object[] args)
        {
            cell1 = (CellEntity)args[0];
            cell2 = (CellEntity)args[1];
        }

        public override object Execute()
        {
            return CellEntity.SwapCell(cell1, cell2);
        }
    }
}
