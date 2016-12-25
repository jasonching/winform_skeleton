using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MyApp.WinForm.Launcher;
using MyApp.WinForm.NumGen;

namespace MyApp.WinForm.Windsor.Bootstrapper
{
    public class ViewBootstrapper : IWindsorContainerBootstrapper
    {
        public void Register(IWindsorContainer container)
        {
            container.Register(Component.For<INumGenView, NumGenForm>()
               .LifestyleTransient());

            container.Register(Component.For<ILauncherView, LauncherForm>()
               .LifestyleTransient());
        }
    }
}
