﻿using FFXIVTool.Commands;
using FFXIVTool.Models;
using FFXIVTool.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVTool.ViewModel
{
    public class CharacterDetailsViewModel : BaseViewModel
    {

        public CharacterDetails CharacterDetails { get => (CharacterDetails)model; set => model = value; }
        private RefreshEntitiesCommand refreshEntitiesCommand;
        public static string eOffset = "8";
        public static bool NotAllowed = false;
        public static bool CheckAble = true;
        HashSet<int> ZoneBlacklist = new HashSet<int> { 691, 692, 693, 694, 695, 696, 697, 698, 733, 734, 725, 748, 749, 750, 751, 752, 753, 754, 755, 758, 765, 766, 767, 777, 791 };
        public static string baseAddr = MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset);
        public RefreshEntitiesCommand RefreshEntitiesCommand
        {
            get => refreshEntitiesCommand;
        }
        public CharacterDetailsViewModel(Mediator mediator) : base(mediator)
        {
            model = new CharacterDetails();
            model.PropertyChanged += Model_PropertyChanged;
            refreshEntitiesCommand = new RefreshEntitiesCommand(this);
            // refresh the list initially
            this.Refresh();
            mediator.Work += Work;

            mediator.EntitySelection += (offset) => eOffset = offset;
        }
        /// <summary>
        /// Model property changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedIndex")
                mediator.SendEntitySelection(((CharacterDetails.SelectedIndex + 1) * 8).ToString("X"));
        }
        public void Refresh()
        {
            try
            {
                // get the array size
                CharacterDetails.Size = MemoryManager.Instance.MemLib.readLong(MemoryManager.Instance.BaseAddress);

                // clear the entity list
                CharacterDetails.Names.Clear();

                // loop over entity list size
                for (var i = 0; i < CharacterDetails.Size; i++)
                {
                    var addr = MemoryManager.GetAddressString(MemoryManager.Add(MemoryManager.Instance.BaseAddress, ((i + 1) * 8).ToString("X")), Settings.Instance.Character.Name);
                    var name = MemoryManager.Instance.MemLib.readString(addr);
                    if (name.IndexOf('\0') != -1)
                        name = name.Substring(0, name.IndexOf('\0'));
                    CharacterDetails.Names.Add(name);
                }

                // set the enable state
                CharacterDetails.IsEnabled = true;
                // set the index if its under 0
                if (CharacterDetails.SelectedIndex < 0)
                    CharacterDetails.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
        private void Work()
        {
            CharacterDetails.Territoryxd.value = MemoryManager.Instance.MemLib.readInt(MemoryManager.GetAddressString(MemoryManager.Instance.TerritoryAddress, Settings.Instance.Character.Territory));
            if (ZoneBlacklist.Contains(CharacterDetails.Territoryxd.value))
            {
                if (CharacterDetails.Max.value > (float)20.00) // Maximum Zoom limit is 20.00
                {
                    CharacterDetails.Max.freeze = false;
                    CharacterDetails.Max.value = (float)20.00;
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Max), "float", "20");
                }
                if (CharacterDetails.Min.value < (float)1.50) // Minimum Zoom limit is 1.50
                {
                    CharacterDetails.Min.freeze = false;
                    CharacterDetails.Min.value = (float)1.50;
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Min), "float", "1.50");
                }
                if (CharacterDetails.CZoom.value > (float)20.00) // Camera's current zoom 
                {
                    CharacterDetails.CZoom.freeze = false;
                    CharacterDetails.CZoom.value = (float)19.50;
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom), "float", "20");
                }
                if (CheckAble == true)
                {
                    NotAllowed = true;
                    CheckAble = false;
                    CharacterDetails.Max.freeze = false;
                    CharacterDetails.CZoom.freeze = false;
                    CharacterDetails.Min.freeze = false;
                    //These are the checkbox to freeze addresses
                    CharacterDetails.Max.Checker = false;
                    CharacterDetails.Min.Checker = false;
                    CharacterDetails.CZoom.Checker = false;
                }
            }
            else
            {
                if (CheckAble == false)
                {
                    CheckAble = true;
                    NotAllowed = false;
                    CharacterDetails.Max.Checker = true;
                    CharacterDetails.Min.Checker = true;
                    CharacterDetails.CZoom.Checker = true;
                }
            }
            try
            {
                baseAddr = MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset);
                var nameAddr = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Name);
                if (!CharacterDetails.Name.freeze)
                {
                    var name = MemoryManager.Instance.MemLib.readString(nameAddr);
                    if (name.IndexOf('\0') != -1)
                        name = name.Substring(0, name.IndexOf('\0'));
                    CharacterDetails.Name.value = name;
                }

                if (!CharacterDetails.Voices.freeze) CharacterDetails.Voices.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Voices));

                if (!CharacterDetails.Height.freeze) CharacterDetails.Height.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height));

                if (!CharacterDetails.Race.freeze) CharacterDetails.Race.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Race));

                if (!CharacterDetails.Clan.freeze) CharacterDetails.Clan.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Clan));

                if (!CharacterDetails.Gender.freeze) CharacterDetails.Gender.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Gender));

                if (!CharacterDetails.Head.freeze) CharacterDetails.Head.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Head));

                if (!CharacterDetails.Hair.freeze) CharacterDetails.Hair.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Hair));

                if (!CharacterDetails.TailType.freeze) CharacterDetails.TailType.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.TailType));

                if (!CharacterDetails.HairTone.freeze) CharacterDetails.HairTone.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairTone));

                if (!CharacterDetails.Highlights.freeze)
                {
                    CharacterDetails.Highlights.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Highlights));
                    if (CharacterDetails.Highlights.value >= 80) CharacterDetails.Highlights.SpecialActivate = true;
                    else CharacterDetails.Highlights.SpecialActivate = false;
                }

                if (!CharacterDetails.HighlightTone.freeze) CharacterDetails.HighlightTone.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HighlightTone));

                if (!CharacterDetails.Skintone.freeze) CharacterDetails.Skintone.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Skintone));

                if (!CharacterDetails.Lips.freeze) CharacterDetails.Lips.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Lips));

                if (!CharacterDetails.LipsTone.freeze) CharacterDetails.LipsTone.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LipsTone));

                if (!CharacterDetails.Nose.freeze) CharacterDetails.Nose.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Nose));

                if (!CharacterDetails.TailorMuscle.freeze) CharacterDetails.TailorMuscle.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.TailorMuscle));

                if (!CharacterDetails.FacePaintColor.freeze) CharacterDetails.FacePaintColor.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.FacePaintColor));

                if (!CharacterDetails.FacePaint.freeze) CharacterDetails.FacePaint.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.FacePaint));

                if (!CharacterDetails.LeftEye.freeze) CharacterDetails.LeftEye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LeftEye));

                if (!CharacterDetails.RightEye.freeze) CharacterDetails.RightEye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RightEye));

                if (!CharacterDetails.Eye.freeze) CharacterDetails.Eye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Eye));

                if (!CharacterDetails.EyeBrowType.freeze) CharacterDetails.EyeBrowType.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.EyeBrowType));

                if (!CharacterDetails.FacialFeatures.freeze) CharacterDetails.FacialFeatures.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.FacialFeatures));

                if (!CharacterDetails.Jaw.freeze) CharacterDetails.Jaw.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Jaw));

                if (!CharacterDetails.RHeight.freeze) CharacterDetails.RHeight.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RHeight));

                if (!CharacterDetails.TestArray.freeze) CharacterDetails.TestArray.value = MemoryManager.ByteArrayToString(MemoryManager.Instance.MemLib.readBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Race), 26));

                if (!CharacterDetails.BustX.freeze) CharacterDetails.BustX.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X));

                if (!CharacterDetails.BustY.freeze) CharacterDetails.BustY.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y));

                if (!CharacterDetails.BustZ.freeze) CharacterDetails.BustZ.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z));

                if (!CharacterDetails.Rotation.freeze) CharacterDetails.Rotation.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation));

                if (!CharacterDetails.Rotation2.freeze) CharacterDetails.Rotation2.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation2));

                if (!CharacterDetails.Rotation3.freeze) CharacterDetails.Rotation3.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation3));

                if (!CharacterDetails.Rotation4.freeze) CharacterDetails.Rotation4.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation4));

                if (!CharacterDetails.X.freeze) CharacterDetails.X.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.X));

                if (!CharacterDetails.Y.freeze) CharacterDetails.Y.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Y));

                if (!CharacterDetails.Z.freeze) CharacterDetails.Z.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Z));

                if (!CharacterDetails.TailSize.freeze) CharacterDetails.TailSize.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize));

                if (!CharacterDetails.MuscleTone.freeze) CharacterDetails.MuscleTone.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone));

                if (!CharacterDetails.Transparency.freeze) CharacterDetails.Transparency.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Transparency));

                if (!CharacterDetails.ModelType.freeze) CharacterDetails.ModelType.value = (int)MemoryManager.Instance.MemLib.read2Byte((MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ModelType)));

                if (!CharacterDetails.Emote.freeze) CharacterDetails.Emote.value = (int)MemoryManager.Instance.MemLib.read2Byte((MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.Emote)));

                if (!CharacterDetails.EmoteX.freeze) CharacterDetails.EmoteX.value = (int)MemoryManager.Instance.MemLib.read2Byte((MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Emote)));

                if (!CharacterDetails.EmoteSpeed1.freeze) CharacterDetails.EmoteSpeed1.value = (float)MemoryManager.Instance.MemLib.readFloat((MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.EmoteSpeed1)));

                if (!CharacterDetails.CamZ.freeze) CharacterDetails.CamZ.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamZ));

                if (!CharacterDetails.CamY.freeze) CharacterDetails.CamY.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamY));

                if (!CharacterDetails.CamX.freeze) CharacterDetails.CamX.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamX));

                if (!CharacterDetails.CameraHeight.freeze) CharacterDetails.CameraHeight.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CameraHeight));
                if (!CharacterDetails.Job.freeze && !CharacterDetails.Job.Activated)
                {
                    CharacterDetails.Job.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Job));
                    CharacterDetails.WeaponBase.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponBase));
                    CharacterDetails.WeaponV.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponV));
                    CharacterDetails.WeaponDye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponDye));
                }
                if (!CharacterDetails.Offhand.freeze && !CharacterDetails.Offhand.Activated)
                {
                    CharacterDetails.Offhand.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Offhand));
                    CharacterDetails.OffhandBase.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandBase));
                    CharacterDetails.OffhandV.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandV));
                    CharacterDetails.OffhandDye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandDye));
                }
                if (!CharacterDetails.HeadPiece.freeze && !CharacterDetails.HeadPiece.Activated)
                {
                    CharacterDetails.HeadPiece.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HeadPiece));
                    CharacterDetails.HeadV.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HeadV));
                    CharacterDetails.HeadDye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HeadDye));
                }
                if (!CharacterDetails.Chest.freeze && !CharacterDetails.Chest.Activated)
                {
                    CharacterDetails.Chest.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Chest));
                    CharacterDetails.ChestV.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ChestV));
                    CharacterDetails.ChestDye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ChestDye));
                }
                if (!CharacterDetails.Arms.freeze && !CharacterDetails.Arms.Activated)
                {
                    CharacterDetails.Arms.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Arms));
                    CharacterDetails.ArmsV.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ArmsV));
                    CharacterDetails.ArmsDye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ArmsDye));
                }
                if (!CharacterDetails.Legs.freeze && !CharacterDetails.Legs.Activated)
                {
                    CharacterDetails.Legs.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Legs));
                    CharacterDetails.LegsV.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LegsV));
                    CharacterDetails.LegsDye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LegsDye));
                }
                if (!CharacterDetails.Feet.freeze && !CharacterDetails.Feet.Activated)
                {
                    CharacterDetails.Feet.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Feet));
                    CharacterDetails.FeetVa.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.FeetVa));
                    CharacterDetails.FeetDye.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.FeetDye));
                }

                if (!CharacterDetails.LFinger.freeze && !CharacterDetails.LFinger.Activated)
                {
                    CharacterDetails.LFinger.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LFinger));
                    CharacterDetails.LFingerVa.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LFingerVa));
                }
                if (!CharacterDetails.RFinger.freeze && !CharacterDetails.RFinger.Activated)
                {
                    CharacterDetails.RFinger.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RFinger));
                    CharacterDetails.RFingerVa.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RFingerVa));
                }
                if (!CharacterDetails.Wrist.freeze && !CharacterDetails.Wrist.Activated)
                {
                    CharacterDetails.Wrist.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Wrist));
                    CharacterDetails.WristVa.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WristVa));
                }
                if (!CharacterDetails.Neck.freeze && !CharacterDetails.Neck.Activated)
                {
                    CharacterDetails.Neck.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Neck));
                    CharacterDetails.NeckVa.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.NeckVa));
                }
                if (!CharacterDetails.Ear.freeze && !CharacterDetails.Ear.Activated)
                {
                    CharacterDetails.Ear.value = (int)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Ear));
                    CharacterDetails.EarVa.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.EarVa));
                }
                if (!CharacterDetails.WeaponRed.freeze) CharacterDetails.WeaponRed.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponRed));

                if (!CharacterDetails.WeaponGreen.freeze) CharacterDetails.WeaponGreen.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponGreen));

                if (!CharacterDetails.WeaponBlue.freeze) CharacterDetails.WeaponBlue.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponBlue));

                if (!CharacterDetails.WeaponZ.freeze) CharacterDetails.WeaponZ.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponZ));

                if (!CharacterDetails.WeaponY.freeze) CharacterDetails.WeaponY.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponY));

                if (!CharacterDetails.WeaponX.freeze) CharacterDetails.WeaponX.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponX));

                if (!CharacterDetails.OffhandZ.freeze) CharacterDetails.OffhandZ.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandZ));

                if (!CharacterDetails.OffhandY.freeze) CharacterDetails.OffhandY.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandY));

                if (!CharacterDetails.OffhandX.freeze) CharacterDetails.OffhandX.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandX));

                if (!CharacterDetails.OffhandBlue.freeze) CharacterDetails.OffhandBlue.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandBlue));

                if (!CharacterDetails.OffhandGreen.freeze) CharacterDetails.OffhandGreen.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandGreen));

                if (!CharacterDetails.OffhandRed.freeze) CharacterDetails.OffhandRed.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandRed));
                if (!CharacterDetails.CameraHeight2.freeze) CharacterDetails.CameraHeight2.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraHeight));

                if (!CharacterDetails.CameraYAMin.freeze) CharacterDetails.CameraYAMin.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMin));

                if (!CharacterDetails.CameraYAMax.freeze) CharacterDetails.CameraYAMax.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMax));

                if (!CharacterDetails.FOV2.freeze) CharacterDetails.FOV2.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2));

                if (!CharacterDetails.CameraUpDown.freeze) CharacterDetails.CameraUpDown.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraUpDown));

                if (!CharacterDetails.FOVMAX.freeze)
                {
                    CharacterDetails.FOVMAX.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVMAX));
                    CharacterDetails.FOVC.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVC));
                }

                if (!CharacterDetails.CZoom.freeze) CharacterDetails.CZoom.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom));

                if (!CharacterDetails.Min.freeze) CharacterDetails.Min.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Min));

                if (!CharacterDetails.Max.freeze) CharacterDetails.Max.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Max));

                if (!CharacterDetails.CamZ.freeze) CharacterDetails.CamZ.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamZ));

                if (!CharacterDetails.CamY.freeze) CharacterDetails.CamY.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamY));

                if (!CharacterDetails.CamX.freeze) CharacterDetails.CamX.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamX));

                if (!CharacterDetails.CameraHeight.freeze) CharacterDetails.CameraHeight.value = MemoryManager.Instance.MemLib.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CameraHeight));

                if (!CharacterDetails.Weather.freeze) CharacterDetails.Weather.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather));
                CharacterDetails.TimeControl.value = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.TimeAddress, Settings.Instance.Character.TimeControl));
                if (!CharacterDetails.HeadPiece.Activated) CharacterDetails.HeadSlot.value = CharacterDetails.HeadPiece.value + "," + CharacterDetails.HeadV.value + "," + CharacterDetails.HeadDye.value;
                if (!CharacterDetails.Chest.Activated) CharacterDetails.BodySlot.value = CharacterDetails.Chest.value + "," + CharacterDetails.ChestV.value + "," + CharacterDetails.ChestDye.value;
                if (!CharacterDetails.Arms.Activated) CharacterDetails.ArmSlot.value = CharacterDetails.Arms.value + "," + CharacterDetails.ArmsV.value + "," + CharacterDetails.ArmsDye.value;
                if (!CharacterDetails.Legs.Activated) CharacterDetails.LegSlot.value = CharacterDetails.Legs.value + "," + CharacterDetails.LegsV.value + "," + CharacterDetails.LegsDye.value;
                if (!CharacterDetails.Feet.Activated) CharacterDetails.FeetSlot.value = CharacterDetails.Feet.value + "," + CharacterDetails.FeetVa.value + "," + CharacterDetails.FeetDye.value;
                if (!CharacterDetails.Job.Activated) CharacterDetails.WeaponSlot.value = CharacterDetails.Job.value + "," + CharacterDetails.WeaponBase.value + "," + CharacterDetails.WeaponV.value + "," + CharacterDetails.WeaponDye.value;
                if (!CharacterDetails.Offhand.Activated) CharacterDetails.OffhandSlot.value = CharacterDetails.Offhand.value + "," + CharacterDetails.OffhandBase.value + "," + CharacterDetails.OffhandV.value + "," + CharacterDetails.OffhandDye.value;
                if (!CharacterDetails.Ear.Activated) CharacterDetails.EarSlot.value = CharacterDetails.Ear.value + "," + CharacterDetails.EarVa.value + ",0";
                if (!CharacterDetails.Neck.Activated) CharacterDetails.NeckSlot.value = CharacterDetails.Neck.value + "," + CharacterDetails.NeckVa.value + ",0";
                if (!CharacterDetails.Wrist.Activated) CharacterDetails.WristSlot.value = CharacterDetails.Wrist.value + "," + CharacterDetails.WristVa.value + ",0";
                if (!CharacterDetails.LFinger.Activated) CharacterDetails.LFingerSlot.value = CharacterDetails.LFinger.value + "," + CharacterDetails.LFingerVa.value + ",0";
                if (!CharacterDetails.RFinger.Activated) CharacterDetails.RFingerSlot.value = CharacterDetails.RFinger.value + "," + CharacterDetails.RFingerVa.value + ",0";
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Oh no!");
                mediator.Work -= Work;
            }
        }
    }
}