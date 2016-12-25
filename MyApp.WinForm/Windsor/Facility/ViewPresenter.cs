using MyApp.WinForm.Core;
using System.ComponentModel;

namespace MyApp.WinForm.Windsor.Facility
{
    internal class ViewPresenter
    {
        public IComponent View { get; set; }
        public IPresenter Presenter { get; set; }
    }
}
