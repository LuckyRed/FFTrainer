using FFXIVTool.Utility;
using FFXIVTool.ViewModel;
using FFXIVTool.Windows;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

namespace FFXIVTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public int Processcheck = 0;
        Version version = Assembly.GetExecutingAssembly().GetName().Version;
        public MainWindow()
        {
            List<ProcessLooker.Game> GameList = new List<ProcessLooker.Game>();

            Process[] processlist = Process.GetProcesses();
            Processcheck = 0;
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Contains("ffxiv_dx11")|| theprocess.ProcessName.Contains("ffxiv"))
                {
                    Processcheck++;
                    GameList.Add(new ProcessLooker.Game() { ProcessName = theprocess.ProcessName, ID = theprocess.Id, StartTime=theprocess.StartTime, AppIcon = IconToImageSource(System.Drawing.Icon.ExtractAssociatedIcon(theprocess.MainModule.FileName))});
                }
            }
            if (Processcheck > 1)
            {
                ProcessLooker f = new ProcessLooker(GameList);
                f.ShowDialog();
                if (f.Choice == null)
                {
                    Close();
                    return;
                }
                MainViewModel.gameProcId= f.Choice.ID;
            }
            if (Processcheck == 1)
                MainViewModel.gameProcId = GameList[0].ID;
            if (Processcheck <= 0)
            {
                ProcessLooker f = new ProcessLooker(GameList);
                f.ShowDialog();
                if (f.Choice == null)
                {
                    Close();
                    return;
                }
                MainViewModel.gameProcId = f.Choice.ID;
            }
            InitializeComponent();
        }
        public static ImageSource IconToImageSource(System.Drawing.Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                new Int32Rect(0, 0, icon.Width, icon.Height),
                BitmapSizeOptions.FromEmptyOptions());
        }
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "FFXIV Screenshot Tool - v" + version;
            DataContext = new MainViewModel();
        }

        private void CharacterRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "2");
            Task.Delay(50).Wait();
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "0");
        }

        private void FindProcess_Click(object sender, RoutedEventArgs e)
        {
            List<ProcessLooker.Game> GameList = new List<ProcessLooker.Game>();

            Process[] processlist = Process.GetProcesses();
            Processcheck = 0;
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Contains("ffxiv_dx11") || theprocess.ProcessName.Contains("ffxiv"))
                {
                    Processcheck++;
                    GameList.Add(new ProcessLooker.Game() { ProcessName = theprocess.ProcessName, ID = theprocess.Id, StartTime = theprocess.StartTime, AppIcon = IconToImageSource(System.Drawing.Icon.ExtractAssociatedIcon(theprocess.MainModule.FileName)) });
                }
            }
            if (Processcheck > 1)
            {
                ProcessLooker f = new ProcessLooker(GameList);
                f.ShowDialog();
                if (f.Choice == null)
                    return;
                MainViewModel.ShutDownStuff();
                MainViewModel.gameProcId = f.Choice.ID;
                DataContext = new MainViewModel();
            }
            if (Processcheck == 1)
            {
                MainViewModel.ShutDownStuff();
                MainViewModel.gameProcId = GameList[0].ID;
                DataContext = new MainViewModel();
            }
        }

        private void NPCRefresh_Click(object sender, RoutedEventArgs e)
        {
            var xdad = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EntityType));
            if (xdad == 1)
            {
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EntityType), "byte", "2");
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "2");
                Task.Delay(50).Wait();
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "0");
                Task.Delay(50).Wait();
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EntityType), "byte", "1");
            }
        }
    }
}