﻿using System.Collections;

namespace Assets.Scripts.Data
{
    public interface IPlayerAvater : IAvater, ICalPropsAvater
    {
        int Level();

        int LevelMax();

        int Exp();

        int ExpUp();

        string EquipmentPackName();
    }
}
