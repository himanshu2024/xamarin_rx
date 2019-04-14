using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyRxTestApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected INavigation _navigation;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
