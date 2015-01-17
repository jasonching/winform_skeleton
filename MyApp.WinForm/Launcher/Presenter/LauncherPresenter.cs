using MyApp.WinForm.Windsor;
using MyApp.Core;
using MyApp.WinForm.NumGen.Presenter;
using System;

namespace MyApp.WinForm.Launcher.Presenter
{
    public class LauncherPresenter : IPresenter
    {
        public ILauncherView Form { get; set; }

        public void Init()
        {
            Form.NumGenButtonClick += (o, e) => LaunchNumGenForm();
        }

        private void LaunchNumGenForm()
        {
            var numGenPresenter = GlobalContainerAccessor.Instance.Container.Resolve<NumGenPresenter>();
            numGenPresenter.Show(Form);
        }
    }
}
