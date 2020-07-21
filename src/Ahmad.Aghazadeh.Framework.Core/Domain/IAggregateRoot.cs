﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AhmadAghazadeh.Framework.Core.Domain
{
    public interface IAggregateRoot<TAggregateRoot>
    {
        IEnumerable<Expression<Func<TAggregateRoot, object>>> GetAggregateExpressions();
    }
}