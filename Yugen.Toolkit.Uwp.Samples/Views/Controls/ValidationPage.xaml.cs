﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Yugen.Toolkit.Uwp.Helpers;
using Yugen.Toolkit.Uwp.Samples.ViewModels.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Yugen.Toolkit.Uwp.Samples.Views.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ValidationPage : Page
    {
        public ValidationViewModel ViewModel { get; set; } = new ValidationViewModel();

        public ValidationPage()
        {
            this.InitializeComponent();
        }

        private void Error_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            UsernameControl.CustomValidationMessage = "Username Already Exist";
            UsernameControl.IsCustomValid = false;
        }

        private async void Success_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await MessageDialogHelper.Alert("Success");
        }
    }
}
