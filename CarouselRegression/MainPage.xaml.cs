using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarouselRegression
{
    public partial class MainPage : ContentPage
    {
        private MainPageModel _vm;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _vm = new MainPageModel();
        }
    }
}
