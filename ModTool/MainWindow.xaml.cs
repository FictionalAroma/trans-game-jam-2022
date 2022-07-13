using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ModTool.Data;

namespace ModTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ModToolDataLibrary DataLib
        {
            get => _libary;
            set
            {
                _libary = value;
                OnPropertyChanged(new DependencyPropertyChangedEventArgs());
            }
        }

        private ModToolDataLibrary _libary;

        private SettingsManager _settings;

        public MainWindow()
        {
            _settings = new SettingsManager();
            _settings.InitialLoadup();

            _libary = DataLibaryManager.Instance.Current;
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DataLibaryManager.Instance.SaveDataset(_libary);
            _settings.SaveSettings();
            base.OnClosing(e);

        }
    }
}
