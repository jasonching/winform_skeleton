using Moq;
using MyApp.WinForm.NumGen.Presenter;
using MyApp.WinForm.Test.Nunit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.WinForm.Test.NumGen.Presenter
{
    [TestFixture]
    public class NumGenPresenterTest : AbstractTest
    {
        [Test]
        public void ChangeNumberTest()
        {
            // Given
            var numGenPresenter = WindsorContainer.Resolve<NumGenPresenter>();

            // When
            MockObjectsProvider.MockNumGenView.Raise(
                v => v.ChangeButtonClick += null,
                EventArgs.Empty);

            // Then
            MockObjectsProvider.MockNumGenView.Verify(
                v => v.ChangeNumber(It.IsAny<int>()),
                Times.Once);
        }
    }
}
