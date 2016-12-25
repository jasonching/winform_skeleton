using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MyApp.WinForm.Launcher.Presenter;
using MyApp.WinForm.NumGen;
using MyApp.WinForm.Launcher;
using MyApp.WinForm.Windsor.Facility;
using MyApp.WinForm.NumGen.Presenter;
using MyApp.Engine.NumGen;

namespace MyApp.WinForm.Windsor.Bootstrapper
{
    public class MainBootstrapper : IWindsorContainerBootstrapper
    {
        public void Register(IWindsorContainer container)
        {
            container.AddFacility<ViewPresenterReleaseFacility>();
            container.AddFacility<LifeCycleTracerFacility>();

            RegisterNumGen(container);
            RegisterLauncher(container);
        }

        private void RegisterLauncher(IWindsorContainer container)
        {
            container.Register(Component.For<LauncherPresenter>()
                .LifestyleTransient()
                .OnCreate(p => p.Init()));
        }

        private void RegisterNumGen(IWindsorContainer container)
        {
            container.Register(Component.For<NumGenPresenter>()
                .LifestyleTransient()
                .OnCreate(p => p.Init()));

            container.Register(Component.For<NumGenEngine>());
        }
    }
}
