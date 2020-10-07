using AhmadAghazadeh.Framework.Core.Security;

namespace AhmadAghazadeh.Framework.Security
{
    public class HashProvider:IHashProvider
    {
        public string Hash(string textPlan, string saltedValue)
        {
            return textPlan;
        }
    }
}
