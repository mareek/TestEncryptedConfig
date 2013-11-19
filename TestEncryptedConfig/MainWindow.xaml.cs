using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestEncryptedConfig
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RemoteConfigButton_Click(object sender, RoutedEventArgs e)
        {
            var remoteConfig = ConfigurationManager.OpenExeConfiguration(@"D:\Src\WATER-MCN-EverBlu\System\Main\Software\Server\Itron.EverBlu.Server\Itron.EverBlu.Server.Service\bin\Debug\Itron.EverBlu.Server.Service.exe");

            EncryptConfig(remoteConfig);
        }

        private void LocalConfigButton_Click(object sender, RoutedEventArgs e)
        {
            var localConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            EncryptConfig(localConfig);
        }

        private void EncryptConfig(Configuration config)
        {
            var databaseSection = config.GetSection("database");
            databaseSection.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
            databaseSection.SectionInformation.ForceSave = true;

            config.Save(ConfigurationSaveMode.Minimal);
        }
    }
}
