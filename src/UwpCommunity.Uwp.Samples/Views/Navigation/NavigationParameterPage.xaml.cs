﻿using UwpCommunity.Uwp.Samples.ViewModels.Navigation;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpCommunity.Uwp.Samples.Views.Navigation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationParameterPage : Page
    {
        public NavigationParameterViewModel ViewModel { get; set; }

        public NavigationParameterPage()
        {
            this.InitializeComponent();

            DataContextChanged += (s, e) => { ViewModel = DataContext as NavigationParameterViewModel; };
        }
    }
}