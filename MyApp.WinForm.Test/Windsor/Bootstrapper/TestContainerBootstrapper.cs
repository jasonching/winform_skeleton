using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MyApp.Core.Windsor;
using MyApp.WinForm.Launcher;
using MyApp.WinForm.NumGen;

namespace MyApp.WinForm.Test.Windsor.Bootstrapper
{
    internal class TestContainerBootstrapper : IWindsorContainerBootstrapper
    {
        public MockObjectsProvider MockObjectsProvider { get; set; }

        public void Register(IWindsorContainer container)
        {
            container.Register(Component.For<INumGenView>()
                .Instance(MockObjectsProvider.MockNumGenView.Object)
                .LifeStyle.Transient);

            container.Register(Component.For<ILauncherView>()
                .Instance(MockObjectsProvider.MockLauncherView.Object)
                .LifeStyle.Transient);
        }
    }
}
