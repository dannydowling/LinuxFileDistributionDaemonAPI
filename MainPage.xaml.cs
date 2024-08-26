using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Core;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using System.Linq;
using System.IO;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MultiSourceFileCopy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ObservableCollection<string> leftListViewItemSource = new ObservableCollection<string>();
        private ObservableCollection<string> SelectedFilesCollection = new ObservableCollection<string>();
        private ObservableCollection<string> DestinationCollection = new ObservableCollection<string>();
        private ObservableCollection<string>[] validatedSources = new ObservableCollection<string>[0];
        private ObservableCollection<string>[] invalidatedSources = new ObservableCollection<string>[0];
        public MainPage()
        {
            this.InitializeComponent();
            leftFileBrowser.ItemsSource = leftListViewItemSource;
            loadLeftFileBrowser();
        }

        private async void loadLeftFileBrowser()
        {
            var di = new DirectoryInfo(@"../../../../../../../../");

            var folders = di.EnumerateDirectories().Select(folderinfo => folderinfo.FullName).ToList();

            leftListViewItemSource.Clear();
            foreach (var folder in folders)
            {
                leftListViewItemSource.Add(folder);

                foreach (var file in di.EnumerateFiles())
                {
                    leftListViewItemSource.Add(file.FullName);
                }
            }
        }

        private void Add_Files_ButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItems = leftFileBrowser.SelectedItems;
            foreach (var item in selectedItems)
            {
                if (!SelectedFilesCollection.Contains(item.ToString()))
                {
                    SelectedFilesCollection.Add(item.ToString());
                }
            }
        }

        private void Remove_Files_ButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItems = leftFileBrowser.SelectedItems;
            var itemsToRemove = new ObservableCollection<string>();
            foreach (var item in selectedItems)
            {
                itemsToRemove.Add(item.ToString());
            }

            foreach (var item in itemsToRemove)
            {
                SelectedFilesCollection.Remove(item);
            }
        }
        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        private void AddSource(int SourceNumber)
        {

            if (SelectedFilesCollection != null)
            {

                int i = 0;
                try
                {
                    for (; i < SelectedFilesCollection.Count; i++)
                    {
                        validatedSources[SourceNumber].Add(SelectedFilesCollection[i]);
                    }
                }
                catch (AccessViolationException)
                {
                    invalidatedSources[SourceNumber].Add(SelectedFilesCollection[i]);
                    i++;
                }
            }
        }

        private void Start_Copy(object sender, RoutedEventArgs e)
        {
            // start the copy operation
            // Call the CopyFiles method with the source file paths and destination folder
            FileCopier.CopyFiles(SelectedFilesCollection.ToArray(), DestinationCollection.ToArray());
        }

        private void Add_Source_1(object sender, RoutedEventArgs e)
        {
            // Change the source box color to green
            Source_1.Background = new SolidColorBrush(Windows.UI.Colors.Green);
            AddSource(1);
        }

        private void Add_Source_2(object sender, RoutedEventArgs e)
        {
            // Change the source box color to green
            Source_2.Background = new SolidColorBrush(Windows.UI.Colors.Green);
            AddSource(2);
        }

        private void Add_Source_3(object sender, RoutedEventArgs e)
        {
            // Change the source box color to green
            Source_3.Background = new SolidColorBrush(Windows.UI.Colors.Green);
            AddSource(3);
        }

        private void Add_Source_4(object sender, RoutedEventArgs e)
        {
            // Change the source box color to green
            Source_4.Background = new SolidColorBrush(Windows.UI.Colors.Green);
            AddSource(4);
        }

        private void Add_Source_5(object sender, RoutedEventArgs e)
        {
            // Change the source box color to green
            Source_5.Background = new SolidColorBrush(Windows.UI.Colors.Green);
            AddSource(5);
        }

        private void Add_Source_6(object sender, RoutedEventArgs e)
        {
            // Change the source box color to green
            Source_6.Background = new SolidColorBrush(Windows.UI.Colors.Green);
            AddSource(6);
        }

        private void Add_Source_7(object sender, RoutedEventArgs e)
        {
            // Change the source box color to green
            Source_7.Background = new SolidColorBrush(Windows.UI.Colors.Green);
            AddSource(7);
        }
    }
}
