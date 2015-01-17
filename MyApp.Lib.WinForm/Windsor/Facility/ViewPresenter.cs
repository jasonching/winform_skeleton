using MyApp.WinForm.Lib;
using System.ComponentModel;

namespace MyApp.WinForm.Lib.Windsor.Facility
{
    internal class ViewPresenter
    {
        public IComponent View { get; set; }
        public IPresenter Presenter { get; set; }
    }
}
