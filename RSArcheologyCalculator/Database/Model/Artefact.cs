using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSArcheologyCalculator.Database.Model
{
    internal class Artefact
    {
        public string Name;
        public int Level;
        public string Faction;
        public string DigSite;
        public string Section;
        public string Hotspot;
        public double Exp;
        public int Chronotes;

        public static Artefact CreateArtefact(string[] fields)
        {
            string Name = fields[0];
            string DigSite = fields[1];
            string Faction = fields[2];
            int Level = int.Parse(fields[3]);
            int Chronotes = int.Parse(fields[4]);

            Artefact artefact = new Artefact()
            {
                Name = Name,
                DigSite = DigSite,
                Faction = Faction,
                Level = Level,
                Chronotes = Chronotes
            };
            return artefact;
        }
    }

}
