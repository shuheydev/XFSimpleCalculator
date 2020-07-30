using Microsoft.Extensions.Logging;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFSimpleCalculator.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly ILogger<MainPageViewModel> _logger;

        public MainPageViewModel(ILogger<MainPageViewModel> logger)
        {
            this._logger = logger;
        }

        public ICommand NumberPressedCommand => new Command<string>((param)=> {
            this._logger?.LogInformation($"{param} pressed.");
        });
    }
}
