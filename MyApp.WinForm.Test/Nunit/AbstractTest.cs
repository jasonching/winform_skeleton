using Castle.Windsor;
using MyApp.WinForm.Test.Windsor;
using MyApp.WinForm.Test.Windsor.Bootstrapper;
using MyApp.WinForm.Windsor;
using MyApp.WinForm.Windsor.Bootstrapper;
using NUnit.Framework;

namespace MyApp.WinForm.Test.Nunit
{
    public abstract class AbstractTest
    {
        public MockObjectsProvider MockObjectsProvider { get; private set; }
        public IWindsorContainer WindsorContainer { get; private set; }

        [SetUp]
        public void Init()
        {
            MockObjectsProvider = new MockObjectsProvider();
            WindsorContainer = GlobalContainerAccessor.Instance.Container;

            WindsorContainer.Register(
                   new MainBootstrapper(),
                   new TestContainerBootstrapper { MockObjectsProvider = MockObjectsProvider });
        }

        [TearDown]
        public void CleanUp()
        {
            GlobalContainerAccessor.Instance.Release();
            
            WindsorContainer = null;
            MockObjectsProvider = null;
        }
    }
}
