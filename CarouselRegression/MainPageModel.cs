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
        private ObservableCollection<View> _itemCollection = new ObservableCollection<View>();
        private View _currentItem;

        private int _indicatorHeight;
        private bool _carouselActive;
        private bool _indicatorActive;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageModel()
        {
            _indicatorHeight = 30;
            _indicatorActive = true;
            _carouselActive = true;
        }

        public ObservableCollection<View> ItemCollection
        {
            get => _itemCollection;
            set => SetProperty(ref _itemCollection, value);
        }

        public View CurrentItem
        {
            get => _currentItem;
            set
            {
                if (value != _currentItem)
                {
                    SetProperty(ref _currentItem, value);
                    //ChangeCurrentItem();
                }
            }
        }

        public bool CarouselActive
        {
            get => _carouselActive;
            set => SetProperty(ref _carouselActive, value);
        }

        public bool IndicatorActive
        {
            get => _indicatorActive;
            set => SetProperty(ref _indicatorActive, value);
        }

        public int IndicatorHeight
        {
            get => _indicatorHeight;
            set => SetProperty(ref _indicatorHeight, value);
        }

        public void LoadCarouselItems()
        {
            var itemCollection = new ObservableCollection<View>();

            _itemCollection.Clear();

            //Add two content views
            itemCollection.Add(new ContentView1());
            itemCollection.Add(new ContentView2());

            //We set the carousel to active now, it will determine from the item collection whether to show indicators etc
            CarouselActive = true;

            //Set the collection
            ItemCollection = itemCollection;

            //Check at least one token type is selected, move the carousel.
            if (itemCollection.Count > 0) CurrentItem = itemCollection[0];
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
