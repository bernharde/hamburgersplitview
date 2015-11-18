using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NavPaneSample.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<NavigationItem> TopItems { get; } = new ObservableCollection<NavigationItem>();
        public ObservableCollection<NavigationItem> BottomItems { get; } = new ObservableCollection<NavigationItem>();

        public Type CurrentPageType
        {
            get
            {
                return currentPageType;
            }

            set
            {
                currentPageType = value;
                UpdateSelections();
            }
        }

        Type currentPageType;

        public MainViewModel()
        {
            TopItems.Add(new NavigationItem() { Text = "Page 1", MdlText = "\uE71E", Action = command1Execute });
            TopItems.Add(new NavigationItem() { Text = "Page 2", MdlText = "\uE71F", Action = command2Execute });
            BottomItems.Add(new NavigationItem() { Text = "Options", MdlText = "\uE713", Action = optionsExecute });
        }

        private void command1Execute(NavigationItem naviItem)
        {
            if (!naviItem.IsSelected)
            {
                var frame = Window.Current.Content as Frame;
                var page = frame.Content as MainPage;
                page.ContentFrame.Navigated += ContentFrame_Navigated;
                page.ContentFrame.Navigate(typeof(BlankPage1)); // do it by service in mvvm
            }
        }

        void ContentFrame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            UpdateSelections();
        }

        private void UpdateSelections()
        {
            var isPage1 = currentPageType == typeof(BlankPage1);
            TopItems[0].IsSelected = isPage1;
            var isPage2 = currentPageType == typeof(BlankPage2);
            TopItems[1].IsSelected = isPage2;
        }

        private void command2Execute(NavigationItem naviItem)
        {
            if (!naviItem.IsSelected)
            {
                var frame = Window.Current.Content as Frame;
                var page = frame.Content as MainPage;
                page.ContentFrame.Navigate(typeof(BlankPage2)); // do it by service in mvvm
            }
        }

        public event EventHandler ShowOptions;

        private void optionsExecute(NavigationItem naviItem)
        {
            if (ShowOptions != null)
                ShowOptions(this, EventArgs.Empty);
            //var frame = Window.Current.Content as Frame;
            //var page = frame.Content as MainPage;
            //page.ContentFrame.Navigate(typeof(BlankPage2)); // do it by service in mvvm

        }
    }
}
