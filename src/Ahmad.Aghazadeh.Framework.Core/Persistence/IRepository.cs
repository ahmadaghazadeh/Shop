﻿using System;
using System.Text;
using AhmadAghazadeh.Framework.Core.Domain;

namespace AhmadAghazadeh.Framework.Core.Persistence
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot:IAggregateRoot<TAggregateRoot>
    {
    }
}