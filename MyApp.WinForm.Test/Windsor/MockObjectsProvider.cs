using Moq;
using MyApp.WinForm.Launcher;
using MyApp.WinForm.NumGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.WinForm.Test.Windsor
{
    public class MockObjectsProvider
    {
        public Mock<INumGenView> MockNumGenView { get; private set; }
        public Mock<ILauncherView> MockLauncherView { get; private set; }

        public MockObjectsProvider()
        {
            MockNumGenView = new Mock<INumGenView>();
            MockLauncherView = new Mock<ILauncherView>();
        }
    }
}
