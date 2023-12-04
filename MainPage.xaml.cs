using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MultiSourceFileCopy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public static List<string> sourceFiles;
        public static List<string> destinationFolders;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Start_Copy(object sender, RoutedEventArgs e)
        {
            // start the copy operation
            // Call the CopyFiles method with the source file paths and destination folder
            FileCopier.CopyFiles(sourceFiles.ToArray(), destinationFolders.ToString());
        }

        private void Add_Source_1(object sender, RoutedEventArgs e)
        {
            List<string> filesSource1 = new List<string>();
            filesSource1 = AddFilesToSources().Result;
        }

        private void Add_Source_2(object sender, RoutedEventArgs e)
        {
            List<string> filesSource2 = new List<string>();
            filesSource2 = AddFilesToSources().Result;
        }

        private void Add_Source_3(object sender, RoutedEventArgs e)
        {
            List<string> filesSource3 = new List<string>();
            filesSource3 = AddFilesToSources().Result;
        }

        private void Add_Source_4(object sender, RoutedEventArgs e)
        {
            List<string> filesSource4 = new List<string>();
            filesSource4 = AddFilesToSources().Result;
        }

        private void Add_Source_5(object sender, RoutedEventArgs e)
        {
            List<string> filesSource5 = new List<string>();
            filesSource5 = AddFilesToSources().Result;
        }

        private void Add_Source_6(object sender, RoutedEventArgs e)
        {
            List<string> filesSource6 = new List<string>();
            filesSource6 = AddFilesToSources().Result;
        }

        private void Add_Source_7(object sender, RoutedEventArgs e)
        {
            List<string> filesSource7 = new List<string>();
            filesSource7 = AddFilesToSources().Result;
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        private void Remove_Files(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Files(object sender, RoutedEventArgs e)
        {

        }

        private async Task<List<string>> AddFilesToSources()
        {
            List<string> notCopiedSources = new List<string>();
            List<string> copiedSources = new List<string>();

            try
            {
                var filePicker = new FileOpenPicker
                {
                    ViewMode = PickerViewMode.List,
                    SuggestedStartLocation = PickerLocationId.Desktop
                };

                filePicker.FileTypeFilter.Add("*");

                var selectedFiles = await filePicker.PickMultipleFilesAsync();
                if (selectedFiles != null)
                {

                    int i = 0;
                    try
                    {
                        for (; i < selectedFiles.Count; i++)
                        {
                            copiedSources.Add(selectedFiles[i].Path);
                        }
                    }
                    catch (AccessViolationException e)
                    {
                        notCopiedSources.Add(selectedFiles[i].Path);
                        i++;
                    }

                    return copiedSources;
                }
            }
            catch (Exception e)
            {
                MessageDialog errorMessageDialog = new MessageDialog(e.Message);
                errorMessageDialog.Title = e.Source.ToString();
                throw;
            }
            MessageDialog messageDialog = new MessageDialog(notCopiedSources.ToString());
            messageDialog.Title = "List of paths not copied.";

            return null;
        }
    }
}
