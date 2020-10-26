using SharedClassLibary.Models;
using SharedClassLibary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Upg1Datalaging
{

    public sealed partial class MainPage : Page
    {
        public PersonViewModel personViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            CreateFileService.CreateFileAsync().GetAwaiter();

            personViewModel = new PersonViewModel();
        }

        private void ClearFields()
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbAddress.Text = "";
            tbEmail.Text = "";
            tbJobTitle.Text = "";
        }

        private void btnSaveJson_Click(object sender, RoutedEventArgs e)
        {
            WriteToFileService.WriteToFileJsonAsync(new Person(tbFirstName.Text, tbLastName.Text, tbAddress.Text, tbEmail.Text, tbJobTitle.Text)).GetAwaiter();
            ClearFields();
        }

        private void btnSaveXml_Click(object sender, RoutedEventArgs e)
        {
            WriteToFileService.WriteToFileXmlAsync(new Person(tbFirstName.Text, tbLastName.Text, tbAddress.Text, tbEmail.Text, tbJobTitle.Text)).GetAwaiter();
            ClearFields();
        }

        private void btnSaveCsv_Click(object sender, RoutedEventArgs e)
        {
            WriteToFileService.WriteToFileCsvAsync(new Person(tbFirstName.Text, tbLastName.Text, tbAddress.Text, tbEmail.Text, tbJobTitle.Text)).GetAwaiter();
            ClearFields();
        }

        private void btnSaveTxt_Click(object sender, RoutedEventArgs e)
        {
            WriteToFileService.WriteToFileTxtAsync(new Person(tbFirstName.Text, tbLastName.Text, tbAddress.Text, tbEmail.Text, tbJobTitle.Text)).GetAwaiter();
            ClearFields();
        }

        private async void btnLoadFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var people = await ReadFileService.FilePickerAsync();
                personViewModel.People.Clear();
                foreach (var person in people)
                {
                    personViewModel.People.Add(person);
                }
            }
            catch { }
            
        }
       
    }
}
