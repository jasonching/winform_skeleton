using Castle.Windsor;

namespace MyApp.WinForm.Windsor
{
    public interface IWindsorContainerBootstrapper
    {
        void Register(IWindsorContainer container);
    }
}
