using Common.Logging;
using MyApp.Engine.NumGen;
using MyApp.WinForm.Core;

namespace MyApp.WinForm.NumGen.Presenter
{
    public class NumGenPresenter : IPresenter
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(NumGenPresenter));
        public INumGenView Form { get; set; }
        public NumGenEngine NumGenEngine { get; set; }

        public void Show(IView form)
        {
            logger.Info("Show Form");

            Form.Show(form);
        }

        public void Init()
        {
            Form.ChangeButtonClick += (o, e) => ChangeNumberRequest();
        }

        private void ChangeNumberRequest()
        {
            Form.ChangeNumber(NumGenEngine.GenerateNumber());
        }
    }
}
