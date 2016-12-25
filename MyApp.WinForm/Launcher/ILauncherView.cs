using MyApp.WinForm.Core;
using System;

namespace MyApp.WinForm.Launcher
{
    public interface ILauncherView : IView
    {
        event EventHandler NumGenButtonClick;
    }
}
