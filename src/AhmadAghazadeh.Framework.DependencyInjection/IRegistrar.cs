using Castle.Windsor;

namespace AhmadAghazadeh.Framework.DependencyInjection
{
    public interface IRegistrar
    {
        void Register(WindsorContainer container);
    }
}