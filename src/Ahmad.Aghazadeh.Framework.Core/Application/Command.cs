using System;

namespace AhmadAghazadeh.Framework.Core.Application
{
    public abstract class Command
    {
        protected Command()
        {
            TimeStamp=DateTime.Now;
        }
        public DateTime TimeStamp { get; set; }
    }
}
