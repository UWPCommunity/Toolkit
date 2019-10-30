﻿using System;

namespace Yugen.Toolkit.Standard.Data.Interfaces
{
    public interface IBaseEntity
    {
        int Index { get; set; }

        bool IsDeleted { get; set; }
        DateTimeOffset Created { get; set; }
        DateTimeOffset LastUpdated { get; set; }

        DateTimeOffset ClientLastUpdated { get; set; }
    }
}