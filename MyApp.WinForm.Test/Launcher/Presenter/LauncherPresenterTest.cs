using Moq;
using MyApp.WinForm.Launcher.Presenter;
using MyApp.WinForm.Test.Nunit;
using MyApp.WinForm.Windsor;
using NUnit.Framework;
using System;

namespace MyApp.WinForm.Test.Launcher.Presenter
{
    [TestFixture]
    public class LauncherPresenterTest : AbstractTest
    {
        [Test]
        public void LaunchNumGenFormTest()
        {
            // Given
            var presenter = WindsorContainer.Resolve<LauncherPresenter>();

            // When
            MockObjectsProvider.MockLauncherView.Raise(
                v => v.NumGenButtonClick += null, 
                EventArgs.Empty);

            // Then
            MockObjectsProvider.MockNumGenView.Verify(
                v => v.Show(MockObjectsProvider.MockLauncherView.Object), 
                Times.Once, 
                "Show signal is not sent to the NumGenView");
        }
    }
}
