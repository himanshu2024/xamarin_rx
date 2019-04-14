using System;
using System.Collections.Generic;
using MyRxTestApp.ViewModels;
using Xamarin.Forms;

namespace MyRxTestApp.Views
{
    public partial class RxSearchBar : ContentPage
    {
        public RxSearchBar()
        {
            InitializeComponent();
            RxSearchBarViewModel rxSearchBarViewModel = new RxSearchBarViewModel();
            BindingContext = rxSearchBarViewModel;
        }
    }
}
