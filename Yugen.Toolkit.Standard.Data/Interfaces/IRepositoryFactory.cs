﻿using Yugen.Toolkit.Standard.Data.Models;

namespace Yugen.Toolkit.Standard.Data.Interfaces
{
    public interface IRepositoryFactory
    {
        IBaseRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}