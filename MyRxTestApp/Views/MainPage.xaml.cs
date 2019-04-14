using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRxTestApp.ViewModels;
using Xamarin.Forms;

namespace MyRxTestApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainPageViewModel mainPageViewModel = new MainPageViewModel(Navigation);
            this.BindingContext = mainPageViewModel;

            
        }
    }
}
