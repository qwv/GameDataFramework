﻿using System;

namespace Assets.Scripts.Data.Internal
{
    public class CmdAttack: Command
    {
        private CalPropsEntity attacker;
        private CalPropsEntity target;

        public CmdAttack()
        {
            argsType = new Type[] { typeof(CalPropsEntity), typeof(CalPropsEntity) };
        }

        public override void Init(params object[] args)
        {
            attacker = (CalPropsEntity)args[0];
            target = (CalPropsEntity)args[1];
        }

        public override object Execute()
        {
            return CalculateManager.Instance.Attack(attacker, target);
        }

        public override RunType GetRunType()
        {
            return RunType.INTERVAL;
        }

        public override Priority GetPriority()
        {
            return Priority.NORMAL;
        }
    }
}
