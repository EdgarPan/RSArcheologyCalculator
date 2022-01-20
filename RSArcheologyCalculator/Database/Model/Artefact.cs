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
        public string Faction_Name;
        public string DigSite_Name;
        //public string Section_Name;
        public string Hotspot_Name;
        public double Exp;
        public int Chronotes;
        public List <ArtefactMaterialJoin> ArtefactMaterialJoins = new List<ArtefactMaterialJoin>(); //Which will be updated at a later time within join.

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
                DigSite_Name = DigSite,
                Faction_Name = Faction,
                Level = Level,
                Chronotes = Chronotes
            };
            return artefact;
        }

        
        public string GetName()
        {
            return Name;
        }
        public int getLevel()
        {
            return Level;
        }
        public string getFaction()
        {
            return Faction_Name;
        }
        public string getDigsite()
        {
            return DigSite_Name;
        }
        public string getHotspot()
        {
            return Hotspot_Name;
        }
        public double getExp()
        {
            return Exp;
        }
        public int getChronotes()
        {
            return Chronotes;
        }
        
        public static void AddArtefact(Artefact artefact, List<Artefact> Artefacts)
        {
            //Purpose of this function is to catch any incident of duplicate artefacts being added into the list.
        }
        public static Artefact GetArtefact(string Artefact_Name, List<Artefact> Artefacts)
        {
            //This function should search within the List for an Artefact of matching name and return that object.
            //It should also verify that there aren't multiple instances of the same artefact in the list.

            Artefacts.FindAll(i => string.Equals(i.Name,Artefact_Name));
                //Or something along these lines...? Try to find something to also recognize when multiple instances of the same artefact would occur.


            return Artefacts[i];
        }

        public static void ClearDupeArtefact(List<Artefact> Artefacts)
        {
            //The purpose of this function is to give a way to search through the List and remove any cases of Artefacts with the same name.

            //ToDo, once I find out how.

        }

    }

}
