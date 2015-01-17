using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MyApp.Core.Windsor;
using MyApp.WinForm.Launcher;
using MyApp.WinForm.NumGen;

namespace MyApp.WinForm.Windsor.Bootstrapper
{
    internal class ViewContainerBootstrapper : IWindsorContainerBootstrapper
    {
        public void Register(IWindsorContainer container)
        {
            container.Register(Component.For<INumGenView, NumGenForm>()
                .LifeStyle.Transient);

            container.Register(Component.For<ILauncherView, LauncherForm>()
                .LifeStyle.Transient);
        }
    }
}
