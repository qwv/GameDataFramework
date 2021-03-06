﻿
namespace Assets.Scripts.Data
{
    public interface IPackAvater : IAvater
    {
        int Capacity();

        int Count();

        bool Full();

        bool Empty();

        ICellAvater Cell(int index);
    }
}
