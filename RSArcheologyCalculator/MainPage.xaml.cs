using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RSArcheologyCalculator.Database.DAL;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RSArcheologyCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string DEFAULT_PATH = @"%APPDATA%\RSArchDB";
        private CSVDatabase Database;

        public MainPage()
        {
            this.InitializeComponent();
            Database = new CSVDatabase(DEFAULT_PATH);

        }

        private void RefreshArtefacts()
        {
            var Artefacts = Database.GetAllArtefacts();
            foreach (var artefact in Artefacts)
            {
                //Display on Table
            }
        }

    }
}
