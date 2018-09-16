using FFXIVTool.Properties;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GearTuple = System.Tuple<int, int, int>;
using WepTuple = System.Tuple<int, int, int, int>;

namespace FFXIVTool.Utility
{
    public class GearSet
    {
        public GearTuple HeadGear { get; set; }
        public GearTuple BodyGear { get; set; }
        public GearTuple HandsGear { get; set; }
        public GearTuple LegsGear { get; set; }
        public GearTuple FeetGear { get; set; }
        public GearTuple EarGear { get; set; }
        public GearTuple NeckGear { get; set; }
        public GearTuple WristGear { get; set; }
        public GearTuple RRingGear { get; set; }
        public GearTuple LRingGear { get; set; }

        public WepTuple MainWep { get; set; }
        public WepTuple OffWep { get; set; }

        public byte[] Customize { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static GearSet FromJson(string json)
        {
            return JsonConvert.DeserializeObject<GearSet>(json);
        }
    }

    public class ExdCsvReader
    {
        public enum ItemType
        {
            Wep,
            Head,
            Body,
            Hands,
            Legs,
            Feet,
            Ears,
            Neck,
            Wrists,
            Ring
        }
        public class Item
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string ModelMain { get; set; }
            public string ModelOff { get; set; }
            public ItemType Type { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
        public class Race
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }
        public class Tribe
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }
        public class CharaMakeCustomizeFeature
        {
            public int Index { get; set; }
            public int FeatureID { get; set; }
            public Image Icon { get; set; }
        }
        public class Dye
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }

        public class Emote
        {
            public int Index { get; set; }
            public bool Realist { get; set; }
            public bool SpeacialReal { get; set; }
            public bool BattleReal { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
        public class Monster
        {
            public int Index { get; set; }
            public bool Real { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
        public static Emote[] Emotesx;
        public static Monster[] MonsterX;
        public static Dye[] DyesX;
        public Dictionary<int, Item> Items = null;
        public Dictionary<int, Dye> Dyes = null;
        public Dictionary<int, Emote> Emotes = null;
        public Dictionary<int, CharaMakeCustomizeFeature> CharaMakeFeatures = null;
        public Dictionary<int, Race> Races = null;
        public Dictionary<int, Tribe> Tribes = null;
        public Dictionary<int, Monster> Monsters = null;


        public void MakeCharaMakeFeatureList()
        {
            CharaMakeFeatures = new Dictionary<int, CharaMakeCustomizeFeature>();

            try
            {
                using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.charamakecustomize_exh)))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int rowCount = 0;
                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        CharaMakeCustomizeFeature feature = new CharaMakeCustomizeFeature();

                        feature.Index = rowCount;
                        //Processing row
                        rowCount++;
                        string[] fields = parser.ReadFields();
                        int fCount = 0;

                        foreach (string field in fields)
                        {
                            fCount++;

                            if (fCount == 2)
                            {
                                feature.FeatureID = int.Parse(field);
                            }

                            if (fCount == 3)
                            {
                                object O = Properties.Resources.ResourceManager.GetObject($"_{field}_tex"); //Return an object from the image chan1.png in the project
                                feature.Icon = (Image)O; //Set the Image property of channelPic to the returned object as Image
                            }
                        }

                   //     Console.WriteLine($"{rowCount} - {feature.FeatureID}");
                        CharaMakeFeatures.Add(rowCount, feature);
                    }

                //    Console.WriteLine($"{rowCount} charaMakeFeatures read");
                }
            }
            catch (Exception exc)
            {
                CharaMakeFeatures = null;
#if DEBUG
                throw exc;
#endif
            }
        }
        public CharaMakeCustomizeFeature GetCharaMakeCustomizeFeature(int index, bool getBitMap)
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.charamakecustomize_exh)))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int rowCount = 0;
                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        if (rowCount != index)
                        {
                            rowCount++;
                            parser.ReadFields();
                            continue;
                        }

                        CharaMakeCustomizeFeature feature = new CharaMakeCustomizeFeature();

                        feature.Index = index;

                        //Processing row
                        rowCount++;
                        string[] fields = parser.ReadFields();
                        int fCount = 0;

                        foreach (string field in fields)
                        {
                            fCount++;

                            if (fCount == 2)
                            {
                                feature.FeatureID = int.Parse(field);
                            }

                            if (fCount == 3)
                            {
                                if (getBitMap)
                                {

                                    object O = Properties.Resources.ResourceManager.GetObject($"_{field}_tex");
                                    feature.Icon = (Image)O;
                                }
                            }
                        }

                        return feature;
                    }
                }
            }
            catch (Exception exc)
            {
#if DEBUG
                throw exc;

#endif
            }

            return null;
        }
        public void TribeList()
        {
            Tribes = new Dictionary<int, Tribe>();
            try
            {
                using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.tribe_exh_en)))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int rowCount = 0;
                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        rowCount++;
                        Tribe tribe = new Tribe();
                        //Processing row
                        string[] fields = parser.ReadFields();
                        int fCount = 0;
                        tribe.Index = int.Parse(fields[0]);

                        foreach (string field in fields)
                        {
                            fCount++;

                            if (fCount == 2)
                            {
                                tribe.Name = field;
                            }
                        }

                  //      Console.WriteLine($"{rowCount} - {tribe.Name}");
                        Tribes.Add(tribe.Index, tribe);
                    }

            //        Console.WriteLine($"{rowCount} Tribes read");
                }
            }

            catch (Exception exc)
            {
                Tribes = null;
#if DEBUG
                throw exc;
#endif
            }
        }
        public void RaceList()
        {
            Races = new Dictionary<int, Race>();
            try
            {
                using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.raceEN)))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int rowCount = 0;
                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        rowCount++;
                        Race race = new Race();
                        //Processing row
                        string[] fields = parser.ReadFields();
                        int fCount = 0;
                        race.Index = int.Parse(fields[0]);

                        foreach (string field in fields)
                        {
                            fCount++;

                            if (fCount == 2)
                            {
                                race.Name = field;
                            }
                        }

                      //  Console.WriteLine($"{rowCount} - {race.Name}");
                        Races.Add(race.Index, race);
                    }

                //    Console.WriteLine($"{rowCount} Races read");
                }
            }

            catch (Exception exc)
            {
                Races = null;
#if DEBUG
                throw exc;
#endif
            }
        }
        public void EmoteList()
        {
            Emotes = new Dictionary<int, Emote>();
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.actiontimeline)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Emote emote = new Emote();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            emote.Index = int.Parse(fields[0]);
                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    emote.Name = field;
                                }
                            }
                            if (emote.Name.Contains("normal/")) { emote.Name = emote.Name.Remove(0, 7).ToString(); emote.Realist = true; }
                            if (emote.Name.Contains("mon_sp/")) { emote.Name = emote.Name.Remove(0, 7).ToString(); emote.SpeacialReal = true; }
                            if (emote.Name.Contains("battle/")) { emote.Name = emote.Name.Remove(0, 7).ToString(); emote.BattleReal = true; }
                            if (emote.Name.Contains("human_sp/")) { emote.Name = emote.Name.Remove(0, 9).ToString(); emote.SpeacialReal = true; }
                        //    Console.WriteLine($"{rowCount} - {emote.Name}");
                            Emotes.Add(emote.Index, emote);
                        }
                    //    Console.WriteLine($"{rowCount} Emotes read");
                    }
                }

                catch (Exception exc)
                {
                    Emotes = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
        }
        public void MonsterList()
        {
            Monsters = new Dictionary<int, Monster>();
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.MonsterList)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Monster monster = new Monster();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            monster.Index = int.Parse(fields[0]);
                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    monster.Name = field;
                                }
                            }
                            if (monster.Name.Length >= 1) monster.Real = true;
                           // Console.WriteLine($"{rowCount} - {monster.Name}");
                            Monsters.Add(monster.Index, monster);
                        }
                        //Console.WriteLine($"{rowCount} Monsters read");
                    }
                }

                catch (Exception exc)
                {
                    Emotes = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
        }
        public void DyeList()
        {
            Dyes = new Dictionary<int, Dye>();
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.stain_exh_en)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Dye dye = new Dye();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            dye.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 4)
                                {
                                    dye.Name = field;
                                }
                            }

                            //Console.WriteLine($"{rowCount} - {dye.Name}");
                            Dyes.Add(dye.Index, dye);
                        }

                        //Console.WriteLine($"{rowCount} Dyes read");
                    }
                }

                catch (Exception exc)
                {
                    Dyes = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
        }
        public void MakeItemList()
        {
            Items = new Dictionary<int, Item>();
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.Item)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        while (!parser.EndOfData)
                        {
                            //Processing row
                            rowCount++;

                            var item = new Item();
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            int index = 0;

                            if (rowCount == 1)
                                continue;

                            foreach (string field in fields)
                            {
                                fCount++;


                                if (fCount == 1)
                                {
                                    int.TryParse(field, out index);
                                }

                                if (fCount == 2)
                                {
                                    item.Name = field;
                                }

                                if (fCount == 3)
                                {
                                    int cat = int.Parse(field);
                                    switch (cat)
                                    {
                                        case 34:
                                            item.Type = ItemType.Head;
                                            break;
                                        case 35:
                                            item.Type = ItemType.Body;
                                            break;
                                        case 37:
                                            item.Type = ItemType.Hands;
                                            break;
                                        case 36:
                                            item.Type = ItemType.Legs;
                                            break;
                                        case 38:
                                            item.Type = ItemType.Feet;
                                            break;
                                        case 41:
                                            item.Type = ItemType.Ears;
                                            break;
                                        case 40:
                                            item.Type = ItemType.Neck;
                                            break;
                                        case 42:
                                            item.Type = ItemType.Wrists;
                                            break;
                                        case 43:
                                            item.Type = ItemType.Ring;
                                            break;
                                        default:
                                            item.Type = ItemType.Wep;
                                            break;
                                    }
                                }

                                if (fCount == 4)
                                {
                                    var tfield = field.Replace(" ", "");
                                    if (item.Type == ItemType.Wep)
                                    {
                                        item.ModelMain = tfield;
                                    }
                                    else
                                    {
                                        item.ModelMain = tfield;
                                    }
                                }

                                if (fCount == 5)
                                {
                                    var tfield = field.Replace(" ", "");
                                    if (item.Type == ItemType.Wep)
                                    {
                                        item.ModelOff = tfield;
                                    }
                                    else
                                    {
                                        item.ModelOff = tfield;
                                    }
                                }
                            }
                         //   Debug.WriteLine(item.Name + " - " + item.Type);
                            Items.Add(index, item);
                        }
                    //    Debug.WriteLine($"ExdCsvReader: {rowCount} items read");
                    }
                }
                catch (Exception exc)
                {
                    Items = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
        }
    }
}