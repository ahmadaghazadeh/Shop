
namespace AhmadAghazadeh.Framework.Core.Security
{
    public interface IHashProvider
    {
        public string Hash(string textPlan, string saltedValue);
    }
}
