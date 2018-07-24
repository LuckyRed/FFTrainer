﻿using System.Windows;
using System.Windows.Controls;
using FFTrainer.ViewModels;

namespace FFTrainer.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView3.xaml
    /// </summary>
    public partial class CharacterDetailsView3 : UserControl
    {
        public CharacterDetailsView3()
        {
            InitializeComponent();
        }

        private void RedP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (RedP.Value.HasValue)
                if (RedP.IsMouseOver || RedP.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedPigment), "float", RedP.Value.ToString());
        }

        private void GreenP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (GreenP.Value.HasValue)
                if (GreenP.IsMouseOver || GreenP.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenPigment), "float", GreenP.Value.ToString());
        }

        private void BlueP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BlueP.Value.HasValue)
                if (BlueP.IsMouseOver || BlueP.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBluePigment), "float", BlueP.Value.ToString());
        }

        private void RedG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (RedG.Value.HasValue)
                if (RedG.IsMouseOver || RedG.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedGloss), "float", RedG.Value.ToString());
        }

        private void GreenG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (GreenG.Value.HasValue)
                if (GreenG.IsMouseOver || GreenG.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenGloss), "float", GreenG.Value.ToString());
        }

        private void BlueG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BlueG.Value.HasValue)
                if (BlueG.IsMouseOver || BlueG.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBlueGloss), "float", BlueG.Value.ToString());
        }

        private void LipsBright_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LipsBright.Value.HasValue)
                if (LipsBright.IsMouseOver || LipsBright.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsBrightness), "float", LipsBright.Value.ToString());
        }

        private void LipsRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LipsRed.Value.HasValue)
               if (LipsRed.IsMouseOver || LipsRed.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsR), "float", LipsRed.Value.ToString());
        }

        private void LipsGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LipsGreen.Value.HasValue)
                if (LipsGreen.IsMouseOver || LipsGreen.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsG), "float", LipsGreen.Value.ToString());
        }

        private void LipsBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LipsBlue.Value.HasValue)
                if (LipsBlue.IsMouseOver || LipsBlue.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsB), "float", LipsBlue.Value.ToString());
        }

        private void HairRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairRed.Value.HasValue)
               if (HairRed.IsMouseOver || HairRed.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairRedPigment), "float", HairRed.Value.ToString());
        }

        private void HairGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairGreen.Value.HasValue)
               if (HairGreen.IsMouseOver || HairGreen.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGreenPigment), "float", HairGreen.Value.ToString());
        }

        private void HairBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairBlue.Value.HasValue)
                if (HairBlue.IsMouseOver || HairBlue.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairBluePigment), "float", HairBlue.Value.ToString());
        }

        private void HairRedGlow_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairRedGlow.Value.HasValue)
                if (HairRedGlow.IsMouseOver || HairRedGlow.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowRed), "float", HairRedGlow.Value.ToString());
        }

        private void HairGreenGlow_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairGreenGlow.Value.HasValue)
                if (HairGreenGlow.IsMouseOver || HairGreenGlow.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowGreen), "float", HairGreenGlow.Value.ToString());
        }

        private void HairBlueGlow_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairBlueGlow.Value.HasValue)
               if (HairBlueGlow.IsMouseOver || HairBlueGlow.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowBlue), "float", HairBlueGlow.Value.ToString());
        }

        private void HRP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HRP.Value.HasValue)
               if (HRP.IsMouseOver || HRP.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightRedPigment), "float", HRP.Value.ToString());
        }

        private void HGP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HGP.Value.HasValue)
               if (HGP.IsMouseOver || HGP.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightGreenPigment), "float", HGP.Value.ToString());
        }

        private void HBP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HBP.Value.HasValue)
             if (HBP.IsMouseOver || HBP.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightBluePigment), "float", HBP.Value.ToString());
        }

        private void LEyeR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LEyeR.Value.HasValue)
               if (LEyeR.IsMouseOver || LEyeR.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeRed), "float", LEyeR.Value.ToString());
        }

        private void LeyeG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LeyeG.Value.HasValue)
               if (LeyeG.IsMouseOver || LeyeG.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeGreen), "float", LeyeG.Value.ToString());
        }

        private void LeyeB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LeyeB.Value.HasValue)
               if (LeyeB.IsMouseOver || LeyeB.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeBlue), "float", LeyeB.Value.ToString());
        }

        private void ReyeR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ReyeR.Value.HasValue)
              if (ReyeR.IsMouseOver || ReyeR.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeRed), "float", ReyeR.Value.ToString());
        }

        private void ReyeG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ReyeG.Value.HasValue)
              if (ReyeG.IsMouseOver || ReyeG.IsKeyboardFocusWithin)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeGreen), "float", ReyeG.Value.ToString());
        }

        private void ReyeB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if(ReyeB.Value.HasValue)
              if (ReyeB.IsMouseOver || ReyeB.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeBlue), "float", ReyeB.Value.ToString());
        }

        private void SkinGreen_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void LR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LR.Value.HasValue)
                if (LR.IsMouseOver || LR.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalR), "float", LR.Value.ToString());
        }

        private void GR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (GR.Value.HasValue)
                if (GR.IsMouseOver || GR.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalG), "float", GR.Value.ToString());
        }

        private void BR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BR.Value.HasValue)
                if (BR.IsMouseOver || BR.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalB), "float", BR.Value.ToString());
        }

        private void ScaleX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ScaleX.Value.HasValue)
                if (ScaleX.IsMouseOver || ScaleX.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.X), "float", ScaleX.Value.ToString());
        }

        private void ScaleY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ScaleY.Value.HasValue)
                if (ScaleY.IsMouseOver || ScaleY.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.Y), "float", ScaleY.Value.ToString());
        }

        private void ScaleZ_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ScaleZ.Value.HasValue)
                if (ScaleZ.IsMouseOver || ScaleZ.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.Z), "float", ScaleZ.Value.ToString());
        }
    }
}
