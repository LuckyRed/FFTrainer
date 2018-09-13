using FFXIVTool.Properties;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVTool.Utility
{
    public class ExdCsvReader
    {
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
        public static Emote[] Emotesx;
        public Dictionary<int, Emote> Emotes = null;
        public Dictionary<int, Race> Races = null;
        public Dictionary<int, Tribe> Tribes = null;
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

                        Console.WriteLine($"{rowCount} - {tribe.Name}");
                        Tribes.Add(tribe.Index, tribe);
                    }

                    Console.WriteLine($"{rowCount} Tribes read");
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

                        Console.WriteLine($"{rowCount} - {race.Name}");
                        Races.Add(race.Index, race);
                    }

                    Console.WriteLine($"{rowCount} Races read");
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
                            Console.WriteLine($"{rowCount} - {emote.Name}");
                            Emotes.Add(emote.Index, emote);
                        }
                        Console.WriteLine($"{rowCount} Emotes read");
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
    }
}