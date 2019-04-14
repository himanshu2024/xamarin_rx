using System.Windows.Input;
using MyRxTestApp.Views;
using Xamarin.Forms;

namespace MyRxTestApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {


        public ICommand SearchRxCommand { get; set; }
        public ICommand FormsRxCommand { get; set; }
        public ICommand TimerRxCommand { get; set; }

        public MainPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            SearchRxCommand = new Command(SearchClick);
            FormsRxCommand = new Command(FormsClick);
            TimerRxCommand = new Command(TimerClick);

        }


        private void SearchClick()
        {
            _navigation.PushAsync(new RxSearchBar());

        }

        private void FormsClick()
        {
            _navigation.PushAsync(new FormsRxPage());

        }

        private void TimerClick()
        {
            _navigation.PushAsync(new TimerRxPage());

        }

    }
}
