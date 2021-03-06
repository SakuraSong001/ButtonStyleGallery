﻿using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace ButtonStyleGallery
{
    /// <summary>
    ///     可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnVisualStateSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ButtonsPanel == null)
                return;

            var listView = sender as ListView;
            var selectedItem = listView?.SelectedItem as ListViewItem;
            if (selectedItem == null || selectedItem.Content == null)
                return;

            foreach (var item in ButtonsPanel.GetVisualDescendants().OfType<Button>())
                VisualStateManager.GoToState(item, selectedItem.Content as string, true);
        }

        private async void OnChangeState(object sender, RoutedEventArgs e)
        {
            await Task.Delay(2000);
            VisualStateSelector.SelectedIndex = 1;
            await Task.Delay(2000);
            VisualStateSelector.SelectedIndex = 2;
            await Task.Delay(2000);
            VisualStateSelector.SelectedIndex = 1;
            await Task.Delay(2000);
            VisualStateSelector.SelectedIndex = 0;
        }
    }
}