using MyApp.WinForm.Core;
using System;

namespace MyApp.WinForm.NumGen
{
    public interface INumGenView : IView
    {
        event EventHandler ChangeButtonClick;
        
        void ChangeNumber(int text);

        void Show(IView ownerView);
    }
}
