﻿using SushiBarContracts.StoragesContracts;

namespace SushiBarContracts.BuisnessLogicContracts
{
    public interface IWorkProcess
    {
        void DoWork(IImplementerLogic implementerLogic, IOrderLogic orderLogic);
    }
}
