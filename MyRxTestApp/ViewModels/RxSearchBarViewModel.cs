using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace MyRxTestApp.ViewModels
{
    public class RxSearchBarViewModel : BaseViewModel
    {

        private string _searchItem;
        public string SearchItem
        {
            get { return _searchItem; }
            set
            {
                if (_searchItem != value)
                {
                    _searchItem = value;
                    OnPropertyChanged("SearchItem");
                }
            }
        }

        private ObservableCollection<string> _resultList;
        public ObservableCollection<string> ResultList
        {
            get { return _resultList; }
            set
            {
                if (_resultList != value)
                {
                    _resultList = value;
                    OnPropertyChanged("ResultList");
                }
            }
        }

        public RxSearchBarViewModel()
        {
            Observable.FromEventPattern<PropertyChangedEventArgs>(this, nameof(PropertyChanged))
                .Where(x => x.EventArgs.PropertyName == nameof(SearchItem))
                .Throttle(TimeSpan.FromMilliseconds(700))
                .Select(_
                => Observable.FromAsync( async (System.Threading.CancellationToken arg) => 
                {
                    var myList = await GetSuggetionList(SearchItem).ConfigureAwait(false);
                    if(arg.IsCancellationRequested)
                    {
                        return new ObservableCollection<string>();
                    }
                    return myList;
                }))
                .Switch()
                .Subscribe(mydata => ResultList = mydata);
        }

        private async Task<ObservableCollection<string>> GetSuggetionList(string data)
        {
            Debug.WriteLine("SearchItem = " + data);
            ObservableCollection<string> vs = new ObservableCollection<string>();
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(10);
                vs.Add("Item_" + i);
            }
            return vs;
        }
    }
}
