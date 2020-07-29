﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSimpleCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = Startup.ServiceProvider.GetService<Shell>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
