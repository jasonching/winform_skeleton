using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MyApp.Core.Windsor.Facility;
using MyApp.WinForm.Launcher;
using MyApp.WinForm.Launcher.Presenter;
using MyApp.WinForm.NumGen;
using MyApp.WinForm.NumGen.Presenter;
using MyApp.Core.Windsor;

namespace MyApp.WinForm.Windsor.Bootstrapper
{
    public class MainContainerBootstrapper : IWindsorContainerBootstrapper
    {
        public void Register(IWindsorContainer container)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.AddFacility<ViewPresenterReleaseFacility>();
            container.AddFacility<LifeCycleTracerFacility>();
            
            // TODO: How to do it for all presenters with OnCreate?
            // http://docs.castleproject.org/Windsor.Registering-components-by-conventions.ashx
            //container.Register(Classes.FromThisAssembly()
            //    .BasedOn<IPresenter>()
            //    .WithService.Base());

            // NumGen
            container.Register(Component.For<NumGenPresenter>()
                .OnCreate(p => p.Init())
                .LifeStyle.Transient);
            
            // Launcher
            container.Register(Component.For<LauncherPresenter>()
                .OnCreate(p => p.Init())
                .LifeStyle.Transient);
        }
    }
}
