using FFXIVTool.Models;
using FFXIVTool.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FFXIVTool.Utility
{
    public class ThreadWriting
    {
        public BackgroundWorker worker;
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public ThreadWriting()
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // no fancy tricks here boi
            while (true)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                var xdad = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EntityType));
                if (CharacterDetails.BodyType.freeze && !CharacterDetails.BodyType.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.BodyType), CharacterDetails.BodyType.GetBytes());
                if (CharacterDetails.Race.freeze && !CharacterDetails.Race.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), CharacterDetails.Race.GetBytes());
                if (CharacterDetails.Clan.freeze && !CharacterDetails.Clan.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan), CharacterDetails.Clan.GetBytes());
                if (CharacterDetails.Gender.freeze && !CharacterDetails.Gender.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Gender), CharacterDetails.Gender.GetBytes());
                if (CharacterDetails.Head.freeze && !CharacterDetails.Head.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Head), CharacterDetails.Head.GetBytes());
                if (CharacterDetails.Hair.freeze && !CharacterDetails.Hair.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Hair), CharacterDetails.Hair.GetBytes());
                if (CharacterDetails.TailType.freeze && !CharacterDetails.TailType.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailType), CharacterDetails.TailType.GetBytes());
                if (CharacterDetails.HairTone.freeze && !CharacterDetails.HairTone.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone), CharacterDetails.HairTone.GetBytes());
                if (CharacterDetails.HighlightTone.freeze && !CharacterDetails.HighlightTone.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), CharacterDetails.HighlightTone.GetBytes());
                if (CharacterDetails.Skintone.freeze && !CharacterDetails.Skintone.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone), CharacterDetails.Skintone.GetBytes());
                if (CharacterDetails.Lips.freeze && !CharacterDetails.Lips.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips), CharacterDetails.Lips.GetBytes());
                if (CharacterDetails.LipsTone.freeze && !CharacterDetails.LipsTone.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), CharacterDetails.LipsTone.GetBytes());
                if (CharacterDetails.Nose.freeze && !CharacterDetails.Nose.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Nose), CharacterDetails.Nose.GetBytes());
                if (CharacterDetails.FacePaintColor.freeze && !CharacterDetails.FacePaintColor.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.FacePaintColor.GetBytes());
                if (CharacterDetails.FacePaint.freeze && !CharacterDetails.FacePaint.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), CharacterDetails.FacePaint.GetBytes());
                if (CharacterDetails.LeftEye.freeze && !CharacterDetails.LeftEye.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), CharacterDetails.LeftEye.GetBytes());
                if (CharacterDetails.RightEye.freeze && !CharacterDetails.RightEye.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), CharacterDetails.RightEye.GetBytes());
                if (CharacterDetails.Eye.freeze && !CharacterDetails.Eye.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Eye), CharacterDetails.Eye.GetBytes());
                if (CharacterDetails.EyeBrowType.freeze && !CharacterDetails.EyeBrowType.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EyeBrowType), CharacterDetails.EyeBrowType.GetBytes());
                if (CharacterDetails.FacialFeatures.freeze && !CharacterDetails.FacialFeatures.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), CharacterDetails.FacialFeatures.GetBytes());
                if (CharacterDetails.RHeight.freeze && !CharacterDetails.RHeight.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RHeight), CharacterDetails.RHeight.GetBytes());
                if (CharacterDetails.RBust.freeze && !CharacterDetails.RBust.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RBust), CharacterDetails.RBust.GetBytes());
                if (CharacterDetails.Jaw.freeze && !CharacterDetails.Jaw.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Jaw), CharacterDetails.Jaw.GetBytes());
                if (CharacterDetails.TailorMuscle.freeze && !CharacterDetails.TailorMuscle.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailorMuscle), CharacterDetails.TailorMuscle.GetBytes());
                if (CharacterDetails.FreezeFacial.Activated) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.FreezeFacial), "float", "0");
                if (CharacterDetails.Name.freeze)
                {
                    CharacterDetails.Name.value = CharacterDetails.Name.value.Replace("\0", string.Empty);
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Name), "string", CharacterDetails.Name.value + "\0\0\0\0");
                }
                if (CharacterDetails.BustZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), CharacterDetails.BustZ.GetBytes());
                if (CharacterDetails.BustY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), CharacterDetails.BustY.GetBytes());
                if (CharacterDetails.BustX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), CharacterDetails.BustX.GetBytes());
                if (CharacterDetails.Rotation4.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation4), CharacterDetails.Rotation4.GetBytes());
                if (CharacterDetails.Rotation3.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation3), CharacterDetails.Rotation3.GetBytes());
                if (CharacterDetails.Rotation2.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation2), CharacterDetails.Rotation2.GetBytes());
                if (CharacterDetails.Rotation.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation), CharacterDetails.Rotation.GetBytes());
                if (CharacterDetails.Z.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Z), CharacterDetails.Z.GetBytes());
                if (CharacterDetails.Y.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Y), CharacterDetails.Y.GetBytes());
                if (CharacterDetails.X.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.X), CharacterDetails.X.GetBytes());
                if (CharacterDetails.MuscleTone.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), CharacterDetails.MuscleTone.GetBytes());
                if (CharacterDetails.TailSize.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), CharacterDetails.TailSize.GetBytes());
                if (CharacterDetails.Transparency.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Transparency), CharacterDetails.Transparency.GetBytes());
                if (xdad != 2 && CharacterDetails.ModelType.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ModelType), CharacterDetails.ModelType.GetBytes());
                if (CharacterDetails.CameraHeight.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CameraHeight), CharacterDetails.CameraHeight.GetBytes());
                if (CharacterDetails.CamX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamX), CharacterDetails.CamX.GetBytes());
                if (CharacterDetails.CamY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamY), CharacterDetails.CamY.GetBytes());
                if (CharacterDetails.CamZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamZ), CharacterDetails.CamZ.GetBytes());
                if (CharacterDetails.Job.freeze && !CharacterDetails.Job.Activated)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job), CharacterDetails.Job.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBase), CharacterDetails.WeaponBase.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponV), CharacterDetails.WeaponV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponDye), CharacterDetails.WeaponDye.GetBytes());
                }
                if (CharacterDetails.Offhand.freeze && !CharacterDetails.Offhand.Activated)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Offhand), CharacterDetails.Offhand.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBase), CharacterDetails.OffhandBase.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandV), CharacterDetails.OffhandV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandDye), CharacterDetails.OffhandDye.GetBytes());
                }
                if (CharacterDetails.HeadPiece.freeze && !CharacterDetails.HeadPiece.Activated)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece), CharacterDetails.HeadPiece.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadV), CharacterDetails.HeadV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadDye), CharacterDetails.HeadDye.GetBytes());
                }
                if (CharacterDetails.Chest.freeze && !CharacterDetails.Chest.Activated)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Chest), CharacterDetails.Chest.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestV), CharacterDetails.ChestV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestDye), CharacterDetails.ChestDye.GetBytes());
                }
                if (CharacterDetails.Arms.freeze && !CharacterDetails.Arms.Activated)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Arms), CharacterDetails.Arms.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsV), CharacterDetails.ArmsV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsDye), CharacterDetails.ArmsDye.GetBytes());
                }
                if (CharacterDetails.Legs.freeze && !CharacterDetails.Legs.Activated)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Legs), CharacterDetails.Legs.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsV), CharacterDetails.LegsV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsDye), CharacterDetails.LegsDye.GetBytes());
                }
                if (CharacterDetails.Feet.freeze && !CharacterDetails.Feet.Activated)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Feet), CharacterDetails.Feet.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetVa), CharacterDetails.FeetVa.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetDye), CharacterDetails.FeetDye.GetBytes());
                }
                if (CharacterDetails.LFinger.freeze && !CharacterDetails.LFinger.Activated)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFinger), CharacterDetails.LFinger.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFingerVa), CharacterDetails.LFingerVa.GetBytes());
                }
                if (CharacterDetails.RFinger.freeze && !CharacterDetails.RFinger.Activated)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFinger), CharacterDetails.RFinger.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFingerVa), CharacterDetails.RFingerVa.GetBytes());
                }
                if (CharacterDetails.Wrist.freeze && !CharacterDetails.Wrist.Activated)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Wrist), CharacterDetails.Wrist.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WristVa), CharacterDetails.WristVa.GetBytes());
                }
                if (CharacterDetails.Neck.freeze && !CharacterDetails.Neck.Activated)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Neck), CharacterDetails.Neck.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.NeckVa), CharacterDetails.NeckVa.GetBytes());
                }
                if (CharacterDetails.Ear.freeze && !CharacterDetails.Ear.Activated)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Ear), CharacterDetails.Ear.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EarVa), CharacterDetails.EarVa.GetBytes());
                }
                if (CharacterDetails.EmoteSpeed1.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.EmoteSpeed1), CharacterDetails.EmoteSpeed1.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.EmoteSpeed2), CharacterDetails.EmoteSpeed1.GetBytes());
                }
                if (CharacterDetails.Emote.freeze)
                {
                    if (CharacterDetails.Emote.value > 6558) CharacterDetails.Emote.value = 6558;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.Emote), CharacterDetails.Emote.GetBytes());
                }
                if (CharacterDetails.EmoteX.freeze)
                {
                    if (CharacterDetails.EmoteX.value > 6558) CharacterDetails.EmoteX.value = 6558;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Emote), CharacterDetails.EmoteX.GetBytes());
                }

                Thread.Sleep(10);
            }
        }
    }
}
