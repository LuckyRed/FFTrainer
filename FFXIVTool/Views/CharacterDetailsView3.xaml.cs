using FFXIVTool.Models;
using FFXIVTool.Utility;
using FFXIVTool.ViewModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FFXIVTool.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView3.xaml
    /// </summary>
    public partial class CharacterDetailsView3 : UserControl
    {
        private List<ExdCsvReader.Weather> AllowedWeathers;
        private bool isUserInteraction;
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public CharacterDetailsView3()
        {
            InitializeComponent();
        }
        private void MaxZoomXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (MaxZoom.Value.HasValue && CharacterDetailsViewModel.NotAllowed == false)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Max), "float", MaxZoom.Value.ToString());
            MaxZoom.ValueChanged -= MaxZoomXD;
        }

        private void MaxZoom_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (MaxZoom.IsMouseOver || MaxZoom.IsKeyboardFocusWithin)
            {
                MaxZoom.ValueChanged -= MaxZoomXD;
                MaxZoom.ValueChanged += MaxZoomXD;
            }
        }

        private void MinZoomXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Min_Zoom.Value.HasValue && CharacterDetailsViewModel.NotAllowed == false)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Min), "float", Min_Zoom.Value.ToString());
            Min_Zoom.ValueChanged -= MinZoomXD;
        }

        private void Min_Zoom_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Min_Zoom.IsMouseOver || Min_Zoom.IsKeyboardFocusWithin)
            {
                Min_Zoom.ValueChanged -= MinZoomXD;
                Min_Zoom.ValueChanged += MinZoomXD;
            }
        }

        private void CurrentZoomxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CurrentZoom.Value.HasValue && CharacterDetailsViewModel.NotAllowed == false)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom), "float", CurrentZoom.Value.ToString());
            CurrentZoom.ValueChanged -= CurrentZoomxD;
        }
        private void CurrentZoomxD(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (CurrentZoom.Value.HasValue && CharacterDetailsViewModel.NotAllowed == false)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom), "float", CZoom2.Value.ToString());
            CZoom2.ValueChanged -= CurrentZoomxD;
        }
        private void CurrentZoom_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CurrentZoom.IsMouseOver || CurrentZoom.IsKeyboardFocusWithin)
            {
                CurrentZoom.ValueChanged -= CurrentZoomxD;
                CurrentZoom.ValueChanged += CurrentZoomxD;
            }
            if (CZoom2.IsMouseOver || CZoom2.IsKeyboardFocusWithin)
            {
                CZoom2.ValueChanged -= CurrentZoomxD;
                CZoom2.ValueChanged += CurrentZoomxD;
            }
        }

        private void CurrentFOVXD(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (CurrentFOV.Value.HasValue)
            {
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVC), "float", CurrentFOV.Value.ToString());
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVMAX), "float", CurrentFOV.Value.ToString());
            }
            CurrentFOV.ValueChanged -= CurrentFOVXA;
        }
        private void CurrentFOVXA(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CurrentFOV.Value.HasValue)
            {
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVC), "float", CurrentFOV.Value.ToString());
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVMAX), "float", CurrentFOV.Value.ToString());
            }
            FOV1S.ValueChanged -= CurrentFOVXD;
        }
        private void CurrentFOV_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CurrentFOV.IsMouseOver || CurrentFOV.IsKeyboardFocusWithin)
            {
                CurrentFOV.ValueChanged -= CurrentFOVXA;
                CurrentFOV.ValueChanged += CurrentFOVXA;
            }
            if (FOV1S.IsMouseOver || FOV1S.IsKeyboardFocusWithin)
            {
                FOV1S.ValueChanged -= CurrentFOVXD;
                FOV1S.ValueChanged += CurrentFOVXD;
            }
        }

        private void CamHeightxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CameraHeight2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraHeight), "float", CameraHeight2.Value.ToString());
            CameraHeight2.ValueChanged -= CamHeightxd;
        }

        private void CameraHeight2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CameraHeight2.IsMouseOver || CameraHeight2.IsKeyboardFocusWithin)
            {
                CameraHeight2.ValueChanged -= CamHeightxd;
                CameraHeight2.ValueChanged += CamHeightxd;
            }
        }

        private void CamYMinxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamYMin.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMin), "float", CamYMin.Value.ToString());
            CamYMin.ValueChanged -= CamYMinxD;
        }

        private void CamYMin_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamYMin.IsMouseOver || CamYMin.IsKeyboardFocusWithin)
            {
                CamYMin.ValueChanged -= CamYMinxD;
                CamYMin.ValueChanged += CamYMinxD;
            }
        }

        private void CamYMaxxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamYMax.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMax), "float", CamYMax.Value.ToString());
            CamYMax.ValueChanged -= CamYMaxxD;
        }


        private void CamYMax_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamYMax.IsMouseOver || CamYMax.IsKeyboardFocusWithin)
            {
                CamYMax.ValueChanged -= CamYMaxxD;
                CamYMax.ValueChanged += CamYMaxxD;
            }
        }

        private void FOV2XD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (FOV2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2), "float", FOV2.Value.ToString());
            FOV2.ValueChanged -= FOV2XD;
        }
        private void FOV2Ax(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (FOV2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2), "float", FOV2.Value.ToString());
            FOV2S.ValueChanged -= FOV2Ax;
        }
        private void FOV2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (FOV2.IsMouseOver || FOV2.IsKeyboardFocusWithin)
            {
                FOV2.ValueChanged -= FOV2XD;
                FOV2.ValueChanged += FOV2XD;
            }
            if (FOV2S.IsMouseOver || FOV2S.IsKeyboardFocusWithin)
            {
                FOV2S.ValueChanged -= FOV2Ax;
                FOV2S.ValueChanged += FOV2Ax;
            }
        }
        private void CamUpDownXd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamUpDown.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraUpDown), "float", CamUpDown.Value.ToString());
            CamUpDown.ValueChanged -= CamUpDownXd;
        }

        private void CamUpDown_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamUpDown.IsMouseOver || CamUpDown.IsKeyboardFocusWithin)
            {
                CamUpDown.ValueChanged -= CamUpDownXd;
                CamUpDown.ValueChanged += CamUpDownXd;
            }
        }

        private void Weather_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Weather.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather), "byte", Weather.Value.ToString());
            Weather.ValueChanged -= Weather_ValueChanged;
        }

        private void Weather_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Weather.IsMouseOver || Weather.IsKeyboardFocusWithin)
            {
                Weather.ValueChanged -= Weather_ValueChanged;
                Weather.ValueChanged += Weather_ValueChanged;
            }
        }

        private void Timexd_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.TimeAddress, Settings.Instance.Character.TimeControl), "byte", Timexd.Value.ToString());
            Timexd.ValueChanged -= Timexd_ValueChanged_1;
        }

        private void Timexd_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Timexd.IsMouseOver || Timexd.IsKeyboardFocusWithin)
            {
                Timexd.ValueChanged -= Timexd_ValueChanged_1;
                Timexd.ValueChanged += Timexd_ValueChanged_1;
            }
        }
        public void WeatherSelector(List<ExdCsvReader.Weather> allowedWeathers, int currentWeather)
        {

            AllowedWeathers = allowedWeathers;
            WeatherBox.Items.Clear();
            for (int i = 0; i < allowedWeathers.Count; i++)
            {
                WeatherBox.Items.Add(allowedWeathers[i].Name);

                if (allowedWeathers[i].Index == currentWeather)
                    WeatherBox.SelectedIndex = i;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int territory = MemoryManager.Instance.MemLib.readInt(MemoryManager.GetAddressString(MemoryManager.Instance.TerritoryAddress, Settings.Instance.Character.Territory));

            if (!CharacterDetailsView._exdProvider.TerritoryTypes.ContainsKey(territory))
            {
                MessageBox.Show("Could not find your current zone. Make sure you are using the latest version.", "Oh no!");
                return;
            }

            if (CharacterDetailsView._exdProvider.TerritoryTypes[territory].WeatherRate == null)
            {
                MessageBox.Show("Setting weather is not supported for your current zone.", "Oh no!");
                return;
            }
            WeatherSelector(CharacterDetailsView._exdProvider.TerritoryTypes[territory].WeatherRate.AllowedWeathers, MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather)));
        }
        public ExdCsvReader.Weather Choice = null;
        private void WeatherBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (isUserInteraction)
            {
                if (WeatherBox.SelectedItem == null) return;

                Choice = AllowedWeathers[WeatherBox.SelectedIndex];
                CharacterDetails.Weather.value = (byte)AllowedWeathers[WeatherBox.SelectedIndex].Index;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather), "byte", Choice.Index.ToString());

            }
            isUserInteraction = false;
        }

        private void WeatherBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isUserInteraction = true;
        }
    }
}
