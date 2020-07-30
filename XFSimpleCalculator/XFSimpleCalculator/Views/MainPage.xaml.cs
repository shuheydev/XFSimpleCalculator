using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSimpleCalculator.ViewModels;

namespace XFSimpleCalculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this._viewModel = Startup.ServiceProvider.GetService<MainPageViewModel>();
        }
    }
}