using UserBase.Entities;

namespace UserBase.ViewModels
{
    public class BaseViewModel : ObservableClass
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
    }
}
