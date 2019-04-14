using System;
using System.Collections.Generic;
using MyRxTestApp.ViewModels;
using Xamarin.Forms;

namespace MyRxTestApp.Views
{
    public partial class TimerRxPage : ContentPage
    {
        public TimerRxPage()
        {
            InitializeComponent();
            TimerRxPageViewModel pageViewModel = new TimerRxPageViewModel();
            BindingContext = pageViewModel;
        }
    }
}
