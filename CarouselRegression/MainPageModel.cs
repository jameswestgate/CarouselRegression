using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace CarouselRegression
{
    public class MainPageModel: INotifyPropertyChanged
    {
        private ObservableCollection<View> _itemCollection;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageModel()
        {
            LoadCarouselItems();
        }

        public ObservableCollection<View> ItemCollection
        {
            get => _itemCollection;
            set => SetProperty(ref _itemCollection, value);
        }

        public void LoadCarouselItems()
        {
            var itemCollection = new ObservableCollection<View>();

            //Add two content views
            itemCollection.Add(new ContentView1());
            itemCollection.Add(new ContentView2());

            //Set the collection
            ItemCollection = itemCollection;
        }

        //Implement INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null) return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
