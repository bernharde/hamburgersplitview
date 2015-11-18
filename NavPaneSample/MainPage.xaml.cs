using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NavPaneSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ViewModels.MainViewModel mainViewModel;
        public MainPage()
        {
            this.InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

            this.DataContext = mainViewModel = new ViewModels.MainViewModel();
            
            this.ContentFrame.Navigated += ContentFrame_Navigated;
            this.ContentFrame.Navigate(typeof(BlankPage1));

            mainViewModel.ShowOptions += MainViewModel_ShowOptions;
        }

        private void MainViewModel_ShowOptions(object sender, EventArgs e)
        {
            optionsSplitView.IsPaneOpen = true;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.ContentFrame.CanGoBack)
            {
                e.Handled = true;
                this.ContentFrame.GoBack();
            }
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            // Each time a navigation event occurs, update the Back button's visibility
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                ((Frame)sender).CanGoBack ?
                AppViewBackButtonVisibility.Visible :
                AppViewBackButtonVisibility.Collapsed;

            mainViewModel.CurrentPageType = this.ContentFrame.Content.GetType();
            
        }

        public Frame ContentFrame
        {
            get
            {
                return frame;
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void NavigationItem_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var naviItem = (ViewModels.NavigationItem)button.Tag;
            if (naviItem != null && naviItem.Action != null)
                naviItem.Execute();
        }
    }
}
