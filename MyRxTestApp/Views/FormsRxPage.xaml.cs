using System;
using System.Collections.Generic;
using MyRxTestApp.ViewModels;
using Xamarin.Forms;

namespace MyRxTestApp.Views
{
    public partial class FormsRxPage : ContentPage
    {
        public FormsRxPage()
        {
            InitializeComponent();
            FormsRxPageViewModel pageViewModel = new FormsRxPageViewModel();
            BindingContext = pageViewModel;
        }
    }
}
